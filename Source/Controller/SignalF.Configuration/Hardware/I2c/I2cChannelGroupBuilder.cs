using SignalF.Controller.Configuration;
using SignalF.Datamodel.Hardware;

namespace SignalF.Configuration.Hardware.I2c;

public class I2cChannelGroupBuilder
    : ChannelGroupBuilder<I2cChannelGroupBuilder, II2cChannelGroupBuilder, II2cChannelGroupConfiguration, II2CChannelConfigurationBuilder,
          II2cChannelConfiguration,
          SignalFConfigurationOptions>
      , II2cChannelGroupBuilder
{
    private readonly List<Action<II2CChannelConfigurationBuilder>> _channels = new();

    public I2cChannelGroupBuilder(Func<II2CChannelConfigurationBuilder> channelBuilderFactory) : base(channelBuilderFactory)
    {
    }

    protected override II2cChannelGroupBuilder This => this;

    public override void Build(II2cChannelGroupConfiguration configuration)
    {
        base.Build(configuration);
    }
}
