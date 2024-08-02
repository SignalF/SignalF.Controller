using SignalF.Controller;
using SignalF.Controller.Configuration;
using SignalF.Datamodel.Hardware;

namespace SignalF.Configuration.Hardware.Gpio;

public class GpioChannelConfigurationBuilder : ChannelConfigurationBuilder<GpioChannelConfigurationBuilder, IGpioChannelConfigurationBuilder,
                                                   IGpioChannelConfiguration, SignalFConfigurationOptions>
                                               , IGpioChannelConfigurationBuilder
{
    private GpioChannelOptions _options;
    protected override IGpioChannelConfigurationBuilder This => this;

    public override void Build(IGpioChannelConfiguration configuration)
    {
        base.Build(configuration);

        configuration.DriveMode = _options.DriveMode;
        configuration.PinNumber = _options.PinNumber;
        configuration.SharingMode = _options.SharingMode;
        configuration.InitialValue = _options.InitialValue;
    }

    public IGpioChannelConfigurationBuilder SetChannelOptions(GpioChannelOptions options)
    {
        _options = options;
        return this;
    }
}
