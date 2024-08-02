using SignalF.Configuration.SignalConfiguration;
using SignalF.Datamodel.Hardware;

namespace SignalF.Configuration.Devices.Gpio;

public interface IGpioPinAccessConfigurationBuilder : IGpioPinAccessConfigurationBuilder<IGpioPinAccessConfigurationBuilder, IGpioPinAccessConfiguration,
    GpioPinAccessOptions>
{
}

public interface
    IGpioPinAccessConfigurationBuilder<out TBuilder, in TConfiguration, in TOptions> : ISignalProcessorConfigurationBuilder<TBuilder, TConfiguration, TOptions>
    where TBuilder : IGpioPinAccessConfigurationBuilder<TBuilder, TConfiguration, TOptions>
    where TConfiguration : IGpioPinAccessConfiguration
    where TOptions : GpioPinAccessOptions
{
    TBuilder AddSignalToChannelMapping(string signalName, string channel);
}
