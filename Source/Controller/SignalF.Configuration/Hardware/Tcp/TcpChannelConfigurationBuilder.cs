using SignalF.Controller;
using SignalF.Controller.Configuration;
using SignalF.Datamodel.Hardware;

namespace SignalF.Configuration.Hardware.Tcp;

public class TcpChannelConfigurationBuilder :
    ChannelConfigurationBuilder<TcpChannelConfigurationBuilder, ITcpChannelConfigurationBuilder, ITcpChannelConfiguration, SignalFConfigurationOptions>,
    ITcpChannelConfigurationBuilder
{
    private int _port;

    protected override ITcpChannelConfigurationBuilder This => this;

    public ITcpChannelConfigurationBuilder SetPort(int port)
    {
        _port = port;
        return this;
    }

    public override void Build(ITcpChannelConfiguration configuration)
    {
        base.Build(configuration);

        configuration.Port = _port;
    }
}
