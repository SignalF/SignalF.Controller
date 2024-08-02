using SignalF.Datamodel.Hardware;

namespace SignalF.Configuration.Hardware.Tcp;

public interface ITcpChannelGroupBuilder
    : IChannelGroupBuilder<ITcpChannelGroupBuilder, ITcpChannelGroupConfiguration, ITcpChannelConfigurationBuilder, ITcpChannelConfiguration, TcpChannelOptions>
{
    ITcpChannelGroupBuilder SetIpAddress(string ipAddress);
}
