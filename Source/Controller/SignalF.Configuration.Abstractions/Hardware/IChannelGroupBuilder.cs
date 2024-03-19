using System;
using SignalF.Controller.Configuration;
using SignalF.Controller.Hardware.Channels;
using SignalF.Datamodel.Hardware;

namespace SignalF.Configuration.Hardware;

public interface
    IChannelGroupBuilder : IChannelGroupBuilder<IChannelGroupBuilder, IChannelGroupConfiguration, IChannelConfigurationBuilder, IChannelConfiguration>
{
}

public interface IChannelGroupBuilder<out TBuilder, in TConfiguration, out TChannelBuilder, TChannel>
    : IChannelGroupBuilder<TBuilder, TConfiguration, TChannelBuilder, TChannel, SignalFConfigurationOptions>
    where TBuilder : IChannelGroupBuilder<TBuilder, TConfiguration, TChannelBuilder, TChannel, SignalFConfigurationOptions>
    where TChannelBuilder : IChannelConfigurationBuilder<TChannelBuilder, TChannel, SignalFConfigurationOptions>
    where TConfiguration : IChannelGroupConfiguration
    where TChannel : IChannelConfiguration
{
}

public interface IChannelGroupBuilder<out TBuilder, in TConfiguration, out TChannelBuilder, TChannel, in TOptions>
    : ISignalFConfigurationBuilder<TBuilder, TConfiguration, TOptions>
    where TBuilder : IChannelGroupBuilder<TBuilder, TConfiguration, TChannelBuilder, TChannel, TOptions>
    where TChannelBuilder : IChannelConfigurationBuilder<TChannelBuilder, TChannel, TOptions>
    where TConfiguration : IChannelGroupConfiguration
    where TChannel : IChannelConfiguration
    where TOptions : SignalFConfigurationOptions
{
    TBuilder AddChannel(Action<TChannelBuilder> channel);

    TBuilder AddChannel<TType>(Action<TChannelBuilder> channel)
        where TType : IChannel;

    TBuilder SetDeviceBinding(string deviceBinding);
}
