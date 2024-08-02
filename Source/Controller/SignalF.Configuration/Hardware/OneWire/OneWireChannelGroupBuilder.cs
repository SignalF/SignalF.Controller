using SignalF.Datamodel.Hardware;

namespace SignalF.Configuration.Hardware.OneWire;

public class OneWireChannelGroupBuilder
    : ChannelGroupBuilder<OneWireChannelGroupBuilder, IOneWireChannelGroupBuilder, IOneWireChannelGroupConfiguration, IOneWireChannelConfigurationBuilder,
          IOneWireChannelConfiguration, OneWireChannelOptions>, IOneWireChannelGroupBuilder
{
    public OneWireChannelGroupBuilder(Func<IOneWireChannelConfigurationBuilder> channelBuilderFactory) : base(channelBuilderFactory)
    {
    }

    protected override IOneWireChannelGroupBuilder This => this;
}
