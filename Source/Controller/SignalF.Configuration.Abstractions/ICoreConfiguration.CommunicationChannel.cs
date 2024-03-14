using System;
using SignalF.Configuration.Hardware;
using SignalF.Controller.Configuration;
using SignalF.Controller.Hardware.Channels;
using SignalF.Datamodel.Hardware;

namespace SignalF.Configuration;

public partial interface ICoreConfiguration
{
    ICoreConfiguration AddChannelGroup<TBuilder, TConfiguration, TChannelBuilder, TChannel, TOptions>(Action<TBuilder> builder)
        where TBuilder : IChannelGroupBuilder<TBuilder, TConfiguration, TChannelBuilder, TChannel, TOptions>
        where TConfiguration : IChannelGroupConfiguration
        where TChannelBuilder : IChannelConfigurationBuilder<TChannelBuilder, TChannel, CoreConfigurationOptions>
        where TChannel : IChannelConfiguration
        where TOptions : CoreConfigurationOptions;

    ICoreConfiguration AddChannelGroup<TBuilder, TConfiguration, TChannelBuilder, TChannel, TOptions, TType>(Action<TBuilder> builder)
        where TBuilder : IChannelGroupBuilder<TBuilder, TConfiguration, TChannelBuilder, TChannel, TOptions>
        where TConfiguration : IChannelGroupConfiguration
        where TChannelBuilder : IChannelConfigurationBuilder<TChannelBuilder, TChannel, CoreConfigurationOptions>
        where TChannel : IChannelConfiguration
        where TOptions : CoreConfigurationOptions
        where TType : class, IChannelGroup;

    ICoreConfiguration AddChannelToDeviceMapping(Action<IChannelToDeviceMappingBuilder> builder);

    ICoreConfiguration AddChannelToSignalEndpointMapping(Action<IChannelToSignalEndpointMappingBuilder> builder);
}
