using SignalF.Configuration.Hardware;
using SignalF.Controller.Configuration;
using SignalF.Datamodel.Hardware;

public interface
    IGpioChannelConfigurationBuilder : IChannelConfigurationBuilder<IGpioChannelConfigurationBuilder, IGpioChannelConfiguration, CoreConfigurationOptions>
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
