using SignalF.Configuration.Hardware;
using SignalF.Configuration.SignalConfiguration;
using SignalF.Datamodel.Configuration;
using SignalF.Datamodel.Hardware;

namespace SignalF.Configuration.Devices.Gpio;

public class GpioPinAccessConfigurationBuilder
    : GpioPinAccessConfigurationBuilder<GpioPinAccessConfigurationBuilder, IGpioPinAccessConfigurationBuilder, IGpioPinAccessConfiguration,
          GpioPinAccessOptions>, IGpioPinAccessConfigurationBuilder
{
    public GpioPinAccessConfigurationBuilder(IChannelToSignalEndpointMappingBuilder channelMappingBuilder)
        : base(channelMappingBuilder)
    {
    }

    protected override IGpioPinAccessConfigurationBuilder This => this;
}

public abstract class GpioPinAccessConfigurationBuilder<TImpl, TBuilder, TConfiguration, TOptions>
    : SignalProcessorConfigurationBuilder<TImpl, TBuilder, TConfiguration, TOptions>, IGpioPinAccessConfigurationBuilder<TBuilder, TConfiguration, TOptions>
    where TBuilder : IGpioPinAccessConfigurationBuilder<TBuilder, TConfiguration, TOptions>
    where TImpl : GpioPinAccessConfigurationBuilder<TImpl, TBuilder, TConfiguration, TOptions>
    where TConfiguration : IGpioPinAccessConfiguration
    where TOptions : GpioPinAccessOptions
{
    private readonly IChannelToSignalEndpointMappingBuilder _channelMappingBuilder;
    private readonly List<SignalToChannelMapping> _mappings = new();

    protected GpioPinAccessConfigurationBuilder(IChannelToSignalEndpointMappingBuilder channelMappingBuilder)
    {
        _channelMappingBuilder = channelMappingBuilder;
    }

    public TBuilder AddSignalToChannelMapping(string signalName, string channel)
    {
        _mappings.Add(new SignalToChannelMapping(signalName, channel));
        return This;
    }

    public override void Build(TConfiguration configuration)
    {
        base.Build(configuration);
        var controllerConfiguration = configuration.FindParent<IControllerConfiguration>();

        _mappings.ForEach(mapping => _channelMappingBuilder.AddMapping($"{Name}.{mapping.SignalName}", mapping.Channel));
        _channelMappingBuilder.Build(controllerConfiguration);
    }

    //private ISignalEndpointConfiguration GetEndPoint(string name, TConfiguration configuration)
    //{
    //    return (ISignalEndpointConfiguration)configuration.SignalSinks.FirstOrDefault(signal => signal.Name == name)
    //           ?? configuration.SignalSources.First(signal => signal.Name == name);
    //}

    private class SignalToChannelMapping
    {
        public SignalToChannelMapping(string signalName, string channel)
        {
            SignalName = signalName;
            Channel = channel;
        }

        public string Channel { get; }
        public string SignalName { get; }
    }
}
