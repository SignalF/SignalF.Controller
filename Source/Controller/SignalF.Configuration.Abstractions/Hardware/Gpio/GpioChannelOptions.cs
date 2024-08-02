using SignalF.Datamodel.Hardware;

namespace SignalF.Configuration.Hardware.Gpio;

public class GpioChannelOptions : ChannelOptions
{
    public int PinNumber { get; set; }
    public EGpioPinValue? InitialValue { get; set; }
    public EGpioPinDriveMode DriveMode { get; set; }
    public EGpioSharingMode SharingMode { get; set; }
}
