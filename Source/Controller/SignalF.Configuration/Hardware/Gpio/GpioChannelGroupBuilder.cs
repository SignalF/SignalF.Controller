using SignalF.Controller.Configuration;
using SignalF.Datamodel.Hardware;

namespace SignalF.Configuration.Hardware.Gpio;

public class GpioChannelGroupBuilder
    : ChannelGroupBuilder<GpioChannelGroupBuilder, IGpioChannelGroupBuilder, IGpioChannelGroupConfiguration, IGpioChannelConfigurationBuilder,
          IGpioChannelConfiguration,
          SignalFConfigurationOptions>
      , IGpioChannelGroupBuilder
{
    public GpioChannelGroupBuilder(Func<IGpioChannelConfigurationBuilder> channelBuilderFactory) : base(channelBuilderFactory)
    {
    }

    protected override IGpioChannelGroupBuilder This => this;
}
