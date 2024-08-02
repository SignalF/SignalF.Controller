using SignalF.Controller;
using SignalF.Datamodel.Hardware;

namespace SignalF.Configuration.Hardware.Gpio;

public interface IGpioChannelConfigurationBuilder : IChannelConfigurationBuilder<IGpioChannelConfigurationBuilder, IGpioChannelConfiguration, SignalFConfigurationOptions>
{
    IGpioChannelConfigurationBuilder SetChannelOptions(GpioChannelOptions options);
}

public class GpioChannelOptions
{
    public int PinNumber { get; set; }
    public EGpioPinValue? InitialValue { get; set; }
    public EGpioPinDriveMode DriveMode { get; set; }
    public EGpioSharingMode SharingMode { get; set; }
}