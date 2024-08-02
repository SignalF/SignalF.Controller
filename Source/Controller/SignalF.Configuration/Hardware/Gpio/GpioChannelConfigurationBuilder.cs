using SignalF.Datamodel.Hardware;

namespace SignalF.Configuration.Hardware.Gpio;

public class GpioChannelConfigurationBuilder : ChannelConfigurationBuilder<GpioChannelConfigurationBuilder, IGpioChannelConfigurationBuilder,
                                                   IGpioChannelConfiguration, GpioChannelOptions>
                                               , IGpioChannelConfigurationBuilder
{
    //private GpioChannelOptions _options;
    protected override IGpioChannelConfigurationBuilder This => this;

    public override void Build(IGpioChannelConfiguration configuration)
    {
        base.Build(configuration);

        configuration.DriveMode = Options.DriveMode;
        configuration.PinNumber = Options.PinNumber;
        configuration.SharingMode = Options.SharingMode;
        configuration.InitialValue = Options.InitialValue;
    }

    //public IGpioChannelConfigurationBuilder SetChannelOptions(GpioChannelOptions2 options)
    //{
    //    _options = options;
    //    return this;
    //}
}
