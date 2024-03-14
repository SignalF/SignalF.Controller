using Microsoft.Extensions.DependencyInjection;
using SignalF.Configuration.Hardware;
using SignalF.Controller.Configuration;
using SignalF.Controller.Hardware.Channels;
using SignalF.Datamodel.Hardware;

namespace SignalF.Configuration;

public partial class CoreConfiguration : ICoreConfiguration
{
    //TODO: Add additional generic parameter "TChannelOptions" to AddChannelGroup<>(), Currently fixed type "CoreConfigurationOptions" is used.
    public ICoreConfiguration AddChannelGroup<TBuilder, TConfiguration, TChannelBuilder, TChannel, TOptions>(Action<TBuilder> builder)
        where TBuilder : IChannelGroupBuilder<TBuilder, TConfiguration, TChannelBuilder, TChannel, TOptions>
        where TConfiguration : IChannelGroupConfiguration
        where TChannelBuilder : IChannelConfigurationBuilder<TChannelBuilder, TChannel, CoreConfigurationOptions>
        where TChannel : IChannelConfiguration
        where TOptions : CoreConfigurationOptions
    {
        _channelGroups.Add(configuration =>
        {
            var channelGroupBuilder = _serviceProvider.GetRequiredService<TBuilder>();
            builder(channelGroupBuilder);
            channelGroupBuilder.Build(configuration.HardwareConfiguration.ChannelGroups.Create<TConfiguration>());
        });
        return this;
    }

    //TODO: Add additional generic parameter "TChannelOptions" to AddChannelGroup<>(), Currently fixed type "CoreConfigurationOptions" is used.
    public ICoreConfiguration AddChannelGroup<TBuilder, TConfiguration, TChannelBuilder, TChannel, TOptions, TType>(Action<TBuilder> builder)
        where TBuilder : IChannelGroupBuilder<TBuilder, TConfiguration, TChannelBuilder, TChannel, TOptions>
        where TConfiguration : IChannelGroupConfiguration
        where TChannelBuilder : IChannelConfigurationBuilder<TChannelBuilder, TChannel, CoreConfigurationOptions>
        where TChannel : IChannelConfiguration
        where TOptions : CoreConfigurationOptions
        where TType : class, IChannelGroup
    {
        _channelGroups.Add(configuration =>
        {
            var channelGroupBuilder = _serviceProvider.GetRequiredService<TBuilder>();
            channelGroupBuilder.SetType<TType>();
            builder(channelGroupBuilder);
            channelGroupBuilder.Build(configuration.HardwareConfiguration.ChannelGroups.Create<TConfiguration>());
        });
        return this;
    }

    public ICoreConfiguration AddChannelToDeviceMapping(Action<IChannelToDeviceMappingBuilder> builder)
    {
        _channelToDeviceMappings.Add(configuration =>
        {
            var mappingBuilder = _serviceProvider.GetRequiredService<IChannelToDeviceMappingBuilder>();
            builder(mappingBuilder);
            mappingBuilder.Build(configuration);
        });
        return this;
    }

    public ICoreConfiguration AddChannelToSignalEndpointMapping(Action<IChannelToSignalEndpointMappingBuilder> builder)
    {
        _channelToSignalEndpointMappings.Add(configuration =>
        {
            var mappingBuilder = _serviceProvider.GetRequiredService<IChannelToSignalEndpointMappingBuilder>();
            builder(mappingBuilder);
            mappingBuilder.Build(configuration);
        });
        return this;
    }
}
