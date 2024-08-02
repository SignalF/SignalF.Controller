using SignalF.Datamodel.Hardware;

namespace SignalF.Configuration.Hardware.Tcp;

public interface
    ITcpChannelConfigurationBuilder : IChannelConfigurationBuilder<ITcpChannelConfigurationBuilder, ITcpChannelConfiguration, TcpChannelOptions>
{
    ITcpChannelConfigurationBuilder SetPort(int port);
}
