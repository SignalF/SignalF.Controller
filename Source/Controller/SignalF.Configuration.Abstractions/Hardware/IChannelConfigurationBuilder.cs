using SignalF.Datamodel.Hardware;

namespace SignalF.Configuration.Hardware;

public interface IChannelConfigurationBuilder : IChannelConfigurationBuilder<IChannelConfigurationBuilder, IChannelConfiguration, ChannelOptions>
{
}

public interface IChannelConfigurationBuilder<out TBuilder, in TConfiguration, in TOptions>
    : ISignalFConfigurationBuilder<TBuilder, TConfiguration, TOptions>
    where TBuilder : IChannelConfigurationBuilder<TBuilder, TConfiguration, TOptions>
    where TConfiguration : IChannelConfiguration
    where TOptions : ChannelOptions
{
}
