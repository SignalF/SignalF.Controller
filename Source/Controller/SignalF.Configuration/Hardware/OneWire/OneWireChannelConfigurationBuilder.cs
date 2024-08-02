using SignalF.Datamodel.Hardware;

namespace SignalF.Configuration.Hardware.OneWire;

public class OneWireChannelConfigurationBuilder : ChannelConfigurationBuilder<OneWireChannelConfigurationBuilder, IOneWireChannelConfigurationBuilder,
                                                      IOneWireChannelConfiguration, OneWireChannelOptions>
                                                  , IOneWireChannelConfigurationBuilder
{
    protected override IOneWireChannelConfigurationBuilder This => this;
}
