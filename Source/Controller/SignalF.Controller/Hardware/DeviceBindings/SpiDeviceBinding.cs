#region

using System.Device.Spi;
using Scotec.Extensions.Linq;
using SignalF.Controller.Hardware.Channels.Spi;
using SignalF.Datamodel.Hardware;

#endregion

namespace SignalF.Controller.Hardware.DeviceBindings;

public class SpiDeviceBinding : DeviceBinding<ISpiDeviceBindingConfiguration>, ISpiDeviceBinding
{
    private int _busId;
    private IDictionary<int, SpiDevice> _devices;
    private ICollection<SpiDeviceSettings> _deviceSettings;

    public override void Open()
    {
        _devices = _deviceSettings.ToDictionary(settings => settings.ChipSelectLine
            , settings => SpiDevice.Create(new SpiConnectionSettings(_busId, settings.ChipSelectLine)
            {
                Mode = settings.Mode.Convert(),
                DataFlow = settings.DataFlow.Convert(),
                ChipSelectLineActiveState = settings.ChipSelectLineActiveState.Convert(),
                DataBitLength = settings.DataBitLength,
                ClockFrequency = settings.ClockFrequency
            }));
    }

    public override void Close()
    {
        _devices.Values.ForAll(device => device.Dispose());
        _devices = null;
    }

    public void ConfigureDevices(ICollection<SpiDeviceSettings> deviceSettings)
    {
        _deviceSettings = deviceSettings;
    }

    public void Read(int chipSelectLine, Span<byte> buffer)
    {
        _devices[chipSelectLine].Read(buffer);
    }

    public byte ReadByte(int chipSelectLine)
    {
        return _devices[chipSelectLine].ReadByte();
    }

    public void TransferFullDuplex(int chipSelectLine, ReadOnlySpan<byte> writeBuffer, Span<byte> readBuffer)
    {
        _devices[chipSelectLine].TransferFullDuplex(writeBuffer, readBuffer);
    }

    public void Write(int chipSelectLine, ReadOnlySpan<byte> buffer)
    {
        _devices[chipSelectLine].Write(buffer);
    }

    public void WriteByte(int chipSelectLine, byte data)
    {
        _devices[chipSelectLine].WriteByte(data);
    }

    protected override void OnConfigure(ISpiDeviceBindingConfiguration configuration)
    {
        _busId = configuration.BusId;
    }
}
