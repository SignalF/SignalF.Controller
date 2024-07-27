#region

using System.Device.Spi;
using SignalF.Controller.Hardware.Channels.Spi;
using SignalF.Datamodel.Hardware;

#endregion

namespace SignalF.Controller.Hardware.Channels.OneWire;

public sealed class OneWireChannelGroup : ChannelGroup<IOneWireChannelGroupConfiguration>, IOneWireChannelGroup
{
    public void Read(int pin, Span<byte> buffer)
    {
        throw new NotImplementedException();
    }

    public void Write(int pin, Span<byte> buffer)
    {
        throw new NotImplementedException();
    }

    public void WriteRead(int pin, Span<byte> writeBuffer, Span<byte> readBuffer)
    {
        throw new NotImplementedException();
    }

    public override void Open()
    {
        throw new NotImplementedException();
    }

    public override void Close()
    {
        throw new NotImplementedException();
    }

    protected override void OnConfigure(IOneWireChannelGroupConfiguration configuration)
    {
        throw new NotImplementedException();
    }

    //public override void DistributeDeviceBindings()
    //{
    //// group devices by hardware Spi protocol
    //var deviceSettings = _deviceSettings.GroupBy(s => s.Controllername).Select(x => x.Distinct());

    //foreach (var spiDeviceSettings in deviceSettings)
    //{
    //    var spiDeviceSetting = spiDeviceSettings.ToList();

    //    // get minimal frequency
    //    var minFrequency = spiDeviceSetting.Min(s => s.ClockFrequency);

    //    // check that all spiModes are equal
    //    var spiMode = spiDeviceSetting.First().SpiMode;
    //    var areEqual = spiDeviceSetting.All(s => s.SpiMode == spiMode);
    //    if (!areEqual)
    //    {
    //        throw new Exception("Spi devices use different SpiModes!");
    //    }

    //    var device = CreateSpiDevice(RaspberryPi3SpiBusId, 0, minFrequency, spiMode);

    //    spiDeviceSetting.ForEach(settings => settings.Device.ReceiveCommunicationDevice(device));
    //}
    //}

    //public override void ReportDeviceChannel(IOneWireDevice device, IOneWireChannel channel)
    //{
    //    //var configuration = channel;

    //    //var settings = new OneWireDeviceSettings(device, configuration.ChannelGroup.Name, configuration.ChipSelectPin.PinNumber,
    //    //    configuration.ClockFrequency,
    //    //    configuration.SpiMode.Convert());
    //    //_deviceSettings.Add(settings);
    //}

    //private IOneWireDeviceBinding CreateOneWireDevice(int busId, int chipSelectLine, int clockFrequency, SpiMode spiMode)
    //{
    //    //var settings = new SpiConnectionSettings(busId, chipSelectLine) { Mode = spiMode, ClockFrequency = clockFrequency };
    //    //var oneWireDevice = OneWireDevice.Create(settings);

    //    //// check if device was found
    //    //if (oneWireDevice == null)
    //    //{
    //    //    throw new Exception("Device not found or runtime not supported.");
    //    //}

    //    //return new OneWireCommunicationDeviceImpl(oneWireDevice);
    //    return null;
    //}

    private struct SpiDeviceSettings
    {
        public SpiDeviceSettings(ISpiDevice device, string controllername, int chipSelectLine, int clockFrequency, SpiMode spiMode)
        {
            Device = device;
            Controllername = controllername;
            ChipSelectLine = chipSelectLine;
            ClockFrequency = clockFrequency;
            SpiMode = spiMode;
        }

        public ISpiDevice Device { get; }
        public string Controllername { get; }
        public int ChipSelectLine { get; }
        public int ClockFrequency { get; }
        public SpiMode SpiMode { get; }
    }
}
