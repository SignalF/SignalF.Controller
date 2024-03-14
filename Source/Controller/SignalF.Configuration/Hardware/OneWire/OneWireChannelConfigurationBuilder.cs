using SignalF.Controller.Configuration;
using SignalF.Datamodel.Hardware;

namespace SignalF.Configuration.Hardware.OneWire;

public class OneWireChannelConfigurationBuilder : ChannelConfigurationBuilder<OneWireChannelConfigurationBuilder, IOneWireChannelConfigurationBuilder,
                                                      IOneWireChannelConfiguration, CoreConfigurationOptions>
                                                  , IOneWireChannelConfigurationBuilder
{
    protected override IOneWireChannelConfigurationBuilder This => this;
}
