using SignalF.Configuration.SignalConfiguration;
using SignalF.Controller;
using SignalF.Controller.Configuration;
using SignalF.Datamodel.Signals;

namespace SignalF.Configuration.StaticSignalProvider;

public interface IStaticSignalProviderTemplateBuilder : IStaticSignalProviderTemplateBuilder<IStaticSignalProviderTemplateBuilder, IStaticSignalProviderTemplate
    , StaticSignalProviderOptions>
{
}

public interface
    IStaticSignalProviderTemplateBuilder<out TBuilder, in TConfiguration, in TOptions> : ISignalProcessorTemplateBuilder<TBuilder, TConfiguration, TOptions>
    where TBuilder : IStaticSignalProviderTemplateBuilder<TBuilder, TConfiguration, TOptions>
    where TConfiguration : IStaticSignalProviderTemplate
    where TOptions : StaticSignalProviderOptions
{
}
