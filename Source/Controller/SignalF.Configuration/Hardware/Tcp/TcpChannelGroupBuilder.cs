using SignalF.Datamodel.Hardware;

namespace SignalF.Configuration.Hardware.Tcp;

public class TcpChannelGroupBuilder
    : ChannelGroupBuilder<TcpChannelGroupBuilder, ITcpChannelGroupBuilder, ITcpChannelGroupConfiguration, ITcpChannelConfigurationBuilder,
          ITcpChannelConfiguration,
          TcpChannelOptions>
      , ITcpChannelGroupBuilder
{
    private string _ipAddress = "127.0.0.1";

    public TcpChannelGroupBuilder(Func<ITcpChannelConfigurationBuilder> channelBuilderFactory) : base(channelBuilderFactory)
    {
    }

    protected override ITcpChannelGroupBuilder This => this;

    public ITcpChannelGroupBuilder SetIpAddress(string ipAddress)
    {
        _ipAddress = ipAddress;
        return this;
    }

    public override void Build(ITcpChannelGroupConfiguration configuration)
    {
        base.Build(configuration);
        configuration.IpAddress = _ipAddress;
    }
}
