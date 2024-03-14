using SignalF.Controller.Configuration;
using SignalF.Controller.Hardware.Channels;
using SignalF.Datamodel.Configuration;
using SignalF.Datamodel.Hardware;

namespace SignalF.Configuration.Hardware;

public class ChannelGroupBuilder : ChannelGroupBuilder<ChannelGroupBuilder, IChannelGroupBuilder, IChannelGroupConfiguration, IChannelConfigurationBuilder,
                                       IChannelConfiguration, CoreConfigurationOptions>, IChannelGroupBuilder
{
    public ChannelGroupBuilder(Func<IChannelConfigurationBuilder> channelBuilderFactory) : base(channelBuilderFactory)
    {
    }

    protected override IChannelGroupBuilder This => this;
}

public abstract class ChannelGroupBuilder<TImpl, TBuilder, TConfiguration, TChannelBuilder, TChannel, TOptions>
    : CoreConfigurationBuilder<TImpl, TBuilder, TConfiguration, TOptions>,
      IChannelGroupBuilder<TBuilder, TConfiguration, TChannelBuilder, TChannel, TOptions>
    where TImpl : ChannelGroupBuilder<TImpl, TBuilder, TConfiguration, TChannelBuilder, TChannel, TOptions>
    where TBuilder : IChannelGroupBuilder<TBuilder, TConfiguration, TChannelBuilder, TChannel, TOptions>
    where TConfiguration : IChannelGroupConfiguration
    where TChannelBuilder : IChannelConfigurationBuilder<TChannelBuilder, TChannel, CoreConfigurationOptions>
    where TChannel : IChannelConfiguration
    where TOptions : CoreConfigurationOptions
{
    private readonly List<Tuple<Action<TChannelBuilder>, Type>> _channels = new();
    private string _deviceBinding;

    protected ChannelGroupBuilder(Func<TChannelBuilder> channelBuilderFactory)
    {
        ChannelBuilderFactory = channelBuilderFactory;
    }

    protected Func<TChannelBuilder> ChannelBuilderFactory { get; }

    public TBuilder AddChannel(Action<TChannelBuilder> channel)
    {
        _channels.Add(new Tuple<Action<TChannelBuilder>, Type>(channel, null));
        return This;
    }

    public TBuilder AddChannel<TType>(Action<TChannelBuilder> channel)
        where TType : IChannel
    {
        _channels.Add(new Tuple<Action<TChannelBuilder>, Type>(channel, typeof(TType)));
        return This;
    }

    public TBuilder SetDeviceBinding(string deviceBinding)
    {
        _deviceBinding = deviceBinding;
        return This;
    }

    public override void Build(TConfiguration configuration)
    {
        base.Build(configuration);

        var deviceBinding = configuration.FindParent<IControllerConfiguration>()
                                         .DeviceBindings
                                         .FirstOrDefault(item => item.Name == _deviceBinding);

        if (deviceBinding == null)
        {
            throw new ConfigurationBuilderException($"Could not find device binding '{_deviceBinding}' for channel group '{Name}'.");
        }

        configuration.DeviceBinding = deviceBinding;

        foreach (var (channel, type) in _channels)
        {
            var channelBuilder = ChannelBuilderFactory();
            channelBuilder.SetType(type);
            channel.Invoke(channelBuilder);
            channelBuilder.Build(configuration.Channels.Create<TChannel>());
        }

        ;
    }
}
