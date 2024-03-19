using SignalF.Controller.Configuration;
using SignalF.Datamodel.Hardware;

namespace SignalF.Configuration.Hardware.OneWire;

public interface
    IOneWireChannelConfigurationBuilder : IChannelConfigurationBuilder<IOneWireChannelConfigurationBuilder, IOneWireChannelConfiguration,
        SignalFConfigurationOptions>
{
}
