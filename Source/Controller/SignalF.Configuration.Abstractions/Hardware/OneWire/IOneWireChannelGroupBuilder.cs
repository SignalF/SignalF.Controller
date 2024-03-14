using SignalF.Datamodel.Hardware;

namespace SignalF.Configuration.Hardware.OneWire;

public interface IOneWireChannelGroupBuilder : IChannelGroupBuilder<IOneWireChannelGroupBuilder, IOneWireChannelGroupConfiguration,
    IOneWireChannelConfigurationBuilder,
    IOneWireChannelConfiguration>
{
}
