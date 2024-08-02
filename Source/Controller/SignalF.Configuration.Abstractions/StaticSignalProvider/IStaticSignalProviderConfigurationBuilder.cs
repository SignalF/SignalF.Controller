using SignalF.Configuration.SignalConfiguration;
using SignalF.Controller;
using SignalF.Controller.Configuration;
using SignalF.Datamodel.Signals;

namespace SignalF.Configuration.StaticSignalProvider;

public interface
    IStaticSignalProviderConfigurationBuilder : IStaticSignalProviderConfigurationBuilder<IStaticSignalProviderConfigurationBuilder,
        IStaticSignalProviderConfiguration, StaticSignalProviderOptions>
{
}

public interface
    IStaticSignalProviderConfigurationBuilder<out TBuilder, in TConfiguration, in TOptions> : ISignalProcessorConfigurationBuilder<TBuilder, TConfiguration,
        TOptions>
    where TBuilder : IStaticSignalProviderConfigurationBuilder<TBuilder, TConfiguration, TOptions>
    where TConfiguration : IStaticSignalProviderConfiguration
    where TOptions : StaticSignalProviderOptions
{
}
