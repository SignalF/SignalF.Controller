#region

using System.Device.Spi;
using SignalF.Datamodel.Hardware;

#endregion

namespace SignalF.Controller.Hardware.Channels.Spi;

public sealed class SpiChannelGroup : ChannelGroup<ISpiChannelGroupConfiguration>, ISpiChannelGroup
{
    private const int RaspberryPi3SpiBusId = 0;
    private readonly object _deviceLock = new();

    private readonly List<SpiDeviceSettings> _deviceSettings = new();

    public override void Open()
    {
        throw new NotImplementedException();
    }

    public override void Close()
    {
        throw new NotImplementedException();
    }

    public void Read(int chipSelectLine, Span<byte> buffer)
    {
        throw new NotImplementedException();
    }

    public byte ReadByte(int chipSelectLine)
    {
        throw new NotImplementedException();
    }

    public void TransferFullDuplex(int chipSelectLine, ReadOnlySpan<byte> writeBuffer, Span<byte> readBuffer)
    {
        throw new NotImplementedException();
    }

    public void Write(int chipSelectLine, ReadOnlySpan<byte> buffer)
    {
        throw new NotImplementedException();
    }

    public void WriteByte(int chipSelectLine, byte value)
    {
        throw new NotImplementedException();
    }

    public byte[] ReadBytes(byte address, int length, int chipSelectPin = -1)
    {
        var writeBuffer = new byte[length + 1];
        var readBuffer = new byte[length + 1];

        writeBuffer[0] = address;

        // Note: FullDuplex might cause issues with some devices
        //ReadBytes(device, writeBuffer, readBuffer, chipSelectPin);

        // discard first received byte
        var strippedBuffer = new byte[length];
        Array.Copy(readBuffer, 1, strippedBuffer, 0, length);

        return strippedBuffer;
    }

    public void ReadBytes(Span<byte> writeBuffer, Span<byte> readBuffer, int chipSelectPin = -1)
    {
        lock (_deviceLock)
        {
            //_gpioController.WritePinValue(chipSelectPin, EGpioPinValue.Low);
            //(device).TransferFullDuplex(writeBuffer, readBuffer);
            //_gpioController.WritePinValue(chipSelectPin, EGpioPinValue.High);
        }
    }

    public void WriteBytes(Span<byte> writeBuffer, int chipSelectPin = -1)
    {
        lock (_deviceLock)
        {
            //_gpioController.WritePinValue(chipSelectPin, EGpioPinValue.Low);
            //(device).Write(writeBuffer);
            //_gpioController.WritePinValue(chipSelectPin, EGpioPinValue.High);
        }
    }

    protected override void OnConfigure(ISpiChannelGroupConfiguration configuration)
    {
        throw new NotImplementedException();
    }

    //public override void DistributeDeviceBindings()
    //{
    //    // group devices by hardware Spi protocol
    //    var deviceSettings = _deviceSettings.GroupBy(s => s.Controllername).Select(x => x.Distinct());

    //    foreach (var spiDeviceSettings in deviceSettings)
    //    {
    //        var spiDeviceSetting = spiDeviceSettings.ToList();

    //        // get minimal frequency
    //        var minFrequency = spiDeviceSetting.Min(s => s.ClockFrequency);

    //        // check that all spiModes are equal
    //        var spiMode = spiDeviceSetting.First().SpiMode;
    //        var areEqual = spiDeviceSetting.All(s => s.SpiMode == spiMode);
    //        if (!areEqual)
    //            throw new Exception("Spi devices use different SpiModes!");

    //        var device = CreateSpiDevice(RaspberryPi3SpiBusId, 0, minFrequency, spiMode);

    //        spiDeviceSetting.ForEach(settings => settings.Device.AssignDeviceBinding(device));
    //    }
    //}

    //public override void ReportDeviceChannel(ISpiDevice device, ISpiChannel channel)
    //{
    //    var configuration = channel;

    //    //var settings = new SpiDeviceSettings(device, configuration.ChannelGroup.Name, configuration.ChipSelectPin.PinNumber,
    //    //    configuration.ClockFrequency,
    //    //    configuration.SpiMode.Convert());
    //    //_deviceSettings.Add(settings);
    //}

    //private ISpiDeviceBinding CreateSpiDevice(int busId, int chipSelectLine, int clockFrequency, SpiMode spiMode)
    //{
    //    var settings = new SpiConnectionSettings(busId, chipSelectLine) { Mode = spiMode, ClockFrequency = clockFrequency };
    //    var spiDevice = SpiDevice.Create(settings);

    //    // check if device was found
    //    if (spiDevice == null)
    //        throw new Exception("Device not found or runtime not supported.");

    //    // TODO: Use IOC-Controller or factory.
    //    //return new SpiDeviceBinding(spiDevice);
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
