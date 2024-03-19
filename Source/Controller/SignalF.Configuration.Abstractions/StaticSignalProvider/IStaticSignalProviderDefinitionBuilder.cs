using SignalF.Configuration.SignalConfiguration;
using SignalF.Controller.Configuration;
using SignalF.Datamodel.Signals;

namespace SignalF.Configuration.StaticSignalProvider;

public interface
    IStaticSignalProviderDefinitionBuilder : IStaticSignalProviderDefinitionBuilder<IStaticSignalProviderDefinitionBuilder, IStaticSignalProviderDefinition,
        SignalFConfigurationOptions>
{
}

public interface
    IStaticSignalProviderDefinitionBuilder<out TBuilder, in TConfiguration, in TOptions> : ISignalProcessorDefinitionBuilder<TBuilder, TConfiguration, TOptions>
    where TBuilder : IStaticSignalProviderDefinitionBuilder<TBuilder, TConfiguration, TOptions>
    where TConfiguration : IStaticSignalProviderDefinition
    where TOptions : SignalFConfigurationOptions
{
}
