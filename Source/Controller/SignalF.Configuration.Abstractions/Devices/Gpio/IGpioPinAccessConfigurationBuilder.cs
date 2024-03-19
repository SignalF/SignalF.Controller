using SignalF.Configuration.SignalConfiguration;
using SignalF.Controller.Configuration;
using SignalF.Datamodel.Hardware;

namespace SignalF.Configuration.Devices.Gpio;

public interface IGpioPinAccessConfigurationBuilder : IGpioPinAccessConfigurationBuilder<IGpioPinAccessConfigurationBuilder, IGpioPinAccessConfiguration,
    SignalFConfigurationOptions>
{
}

public interface
    IGpioPinAccessConfigurationBuilder<out TBuilder, in TConfiguration, in TOptions> : ISignalProcessorConfigurationBuilder<TBuilder, TConfiguration, TOptions>
    where TBuilder : IGpioPinAccessConfigurationBuilder<TBuilder, TConfiguration, TOptions>
    where TConfiguration : IGpioPinAccessConfiguration
    where TOptions : SignalFConfigurationOptions
{
    TBuilder AddSignalToChannelMapping(string signalName, string channel);
}
