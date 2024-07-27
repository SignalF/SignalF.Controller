using SignalF.Configuration.Hardware;
using SignalF.Controller.Configuration;
using SignalF.Controller.Hardware.Channels;
using SignalF.Datamodel.Hardware;

namespace SignalF.Configuration;

public partial interface ISignalFConfiguration
{
    ISignalFConfiguration AddChannelGroup<TBuilder, TConfiguration, TChannelBuilder, TChannel, TOptions>(Action<TBuilder> builder)
        where TBuilder : IChannelGroupBuilder<TBuilder, TConfiguration, TChannelBuilder, TChannel, TOptions>
        where TConfiguration : IChannelGroupConfiguration
        where TChannelBuilder : IChannelConfigurationBuilder<TChannelBuilder, TChannel, SignalFConfigurationOptions>
        where TChannel : IChannelConfiguration
        where TOptions : SignalFConfigurationOptions;

    ISignalFConfiguration AddChannelGroup<TBuilder, TConfiguration, TChannelBuilder, TChannel, TOptions, TType>(Action<TBuilder> builder)
        where TBuilder : IChannelGroupBuilder<TBuilder, TConfiguration, TChannelBuilder, TChannel, TOptions>
        where TConfiguration : IChannelGroupConfiguration
        where TChannelBuilder : IChannelConfigurationBuilder<TChannelBuilder, TChannel, SignalFConfigurationOptions>
        where TChannel : IChannelConfiguration
        where TOptions : SignalFConfigurationOptions
        where TType : class, IChannelGroup;

    ISignalFConfiguration AddChannelToDeviceMapping(Action<IChannelToDeviceMappingBuilder> builder);

    ISignalFConfiguration AddChannelToSignalEndpointMapping(Action<IChannelToSignalEndpointMappingBuilder> builder);
}
