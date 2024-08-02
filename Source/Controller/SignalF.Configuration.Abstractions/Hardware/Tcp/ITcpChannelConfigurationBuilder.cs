using SignalF.Controller;
using SignalF.Controller.Configuration;
using SignalF.Datamodel.Hardware;

namespace SignalF.Configuration.Hardware.Tcp;

public interface
    ITcpChannelConfigurationBuilder : IChannelConfigurationBuilder<ITcpChannelConfigurationBuilder, ITcpChannelConfiguration, SignalFConfigurationOptions>
{
    ITcpChannelConfigurationBuilder SetPort(int port);
}
