using SignalF.Controller.Hardware.Channels;
using SignalF.Datamodel.Hardware;

namespace SignalF.Configuration.Hardware;

public interface
    IChannelGroupBuilder : IChannelGroupBuilder<IChannelGroupBuilder, IChannelGroupConfiguration, IChannelConfigurationBuilder, IChannelConfiguration>
{
}

public interface IChannelGroupBuilder<out TBuilder, in TConfiguration, out TChannelBuilder, TChannel>
    : IChannelGroupBuilder<TBuilder, TConfiguration, TChannelBuilder, TChannel, ChannelOptions>
    where TBuilder : IChannelGroupBuilder<TBuilder, TConfiguration, TChannelBuilder, TChannel, ChannelOptions>
    where TChannelBuilder : IChannelConfigurationBuilder<TChannelBuilder, TChannel, ChannelOptions>
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
    where TOptions : ChannelOptions
{
    TBuilder AddChannel(Action<TChannelBuilder> channel);

    TBuilder AddChannel<TType>(Action<TChannelBuilder> channel)
        where TType : IChannel;

    TBuilder SetDeviceBinding(string deviceBinding);
}
