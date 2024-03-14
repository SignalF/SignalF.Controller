using SignalF.Datamodel.Hardware;

namespace SignalF.Configuration.Hardware.Tcp;

public interface ITcpChannelGroupBuilder
    : IChannelGroupBuilder<ITcpChannelGroupBuilder, ITcpChannelGroupConfiguration, ITcpChannelConfigurationBuilder, ITcpChannelConfiguration>
{
    ITcpChannelGroupBuilder SetIpAddress(string ipAddress);
}
