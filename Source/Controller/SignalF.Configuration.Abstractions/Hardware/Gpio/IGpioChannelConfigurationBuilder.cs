using SignalF.Datamodel.Hardware;

namespace SignalF.Configuration.Hardware.Gpio;

public interface
    IGpioChannelConfigurationBuilder : IChannelConfigurationBuilder<IGpioChannelConfigurationBuilder, IGpioChannelConfiguration, GpioChannelOptions>
{
    //IGpioChannelConfigurationBuilder SetChannelOptions(GpioChannelOptions options);
}

//public class GpioChannelOptionsX
//{
//    public int PinNumber { get; set; }
//    public EGpioPinValue? InitialValue { get; set; }
//    public EGpioPinDriveMode DriveMode { get; set; }
//    public EGpioSharingMode SharingMode { get; set; }
//}
