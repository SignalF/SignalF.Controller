#region

using System.Device.I2c;
using Scotec.Extensions.Linq;
using SignalF.Controller.Hardware.DeviceBindings;
using SignalF.Datamodel.Hardware;

#endregion

namespace SignalF.Controller.Hardware.Channels.I2c;

public class I2cDeviceBinding : DeviceBinding<II2cDeviceBindingConfiguration>, II2cDeviceBinding
{
    private int _busId;

    private int[] _deviceAddresses;
    private IDictionary<int, System.Device.I2c.I2cDevice> _devices;

    public void Read(int deviceAddress, Span<byte> buffer)
    {
        _devices[deviceAddress].Read(buffer);
    }

    public byte ReadByte(int deviceAddress)
    {
        return _devices[deviceAddress].ReadByte();
    }

    public void Write(int deviceAddress, ReadOnlySpan<byte> buffer)
    {
        _devices[deviceAddress].Write(buffer);
    }

    public void WriteByte(int deviceAddress, byte data)
    {
        _devices[deviceAddress].WriteByte(data);
    }

    public void WriteRead(int deviceAddress, ReadOnlySpan<byte> writeBuffer, Span<byte> readBuffer)
    {
        _devices[deviceAddress].WriteRead(writeBuffer, readBuffer);
    }

    public I2cBus I2cBus { get; private set; }

    public void ConfigureDevices(int[] deviceAddresses)
    {
        _deviceAddresses = deviceAddresses;
    }

    public override void Open()
    {
        I2cBus = I2cBus.Create(_busId);
        _devices = _deviceAddresses.ToDictionary(address => address, address => I2cBus.CreateDevice(address));
    }

    public override void Close()
    {
        _deviceAddresses.ForAll(I2cBus.RemoveDevice);
        I2cBus?.Dispose();
        I2cBus = null;
        _deviceAddresses = null;
    }

    protected override void OnConfigure(II2cDeviceBindingConfiguration configuration)
    {
        _busId = configuration.BusId;
    }

    protected override void Dispose(bool disposing)
    {
        if (disposing)
        {
            I2cBus?.Dispose();
        }
    }
}
