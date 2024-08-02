using SignalF.Configuration.StaticSignalProvider;
using SignalF.Controller;
using SignalF.Controller.Configuration;
using SignalF.Controller.Signals.SignalProcessor;
using SignalF.Datamodel.Signals;

namespace SignalF.Configuration;

public partial interface ISignalFConfiguration
{
    ISignalFConfiguration AddStaticSignalProviderConfiguration<TBuilder, TOptions>(Action<TBuilder> builder)
        where TBuilder : IStaticSignalProviderConfigurationBuilder<TBuilder, IStaticSignalProviderConfiguration, TOptions>
        where TOptions : StaticSignalProviderOptions;

    ISignalFConfiguration AddStaticSignalProviderConfiguration<TBuilder, TOptions, TType>(Action<TBuilder> builder)
        where TBuilder : IStaticSignalProviderConfigurationBuilder<TBuilder, IStaticSignalProviderConfiguration, TOptions>
        where TOptions : StaticSignalProviderOptions
        where TType : class, IStaticSignalProvider;

    ISignalFConfiguration AddStaticSignalProviderDefinition<TBuilder, TOptions>(Action<TBuilder> builder)
        where TBuilder : IStaticSignalProviderDefinitionBuilder<TBuilder, IStaticSignalProviderDefinition, TOptions>
        where TOptions : StaticSignalProviderOptions;

    ISignalFConfiguration AddStaticSignalProviderDefinition<TBuilder, TOptions, TType>(Action<TBuilder> builder)
        where TBuilder : IStaticSignalProviderDefinitionBuilder<TBuilder, IStaticSignalProviderDefinition, TOptions>
        where TOptions : StaticSignalProviderOptions
        where TType : class, IStaticSignalProvider;

    ISignalFConfiguration AddStaticSignalProviderTemplate<TBuilder, TOptions>(Action<TBuilder> builder)
        where TBuilder : IStaticSignalProviderTemplateBuilder<TBuilder, IStaticSignalProviderTemplate, TOptions>
        where TOptions : StaticSignalProviderOptions;

    ISignalFConfiguration AddStaticSignalProviderTemplate<TBuilder, TOptions, TType>(Action<TBuilder> acbuildertion)
        where TBuilder : IStaticSignalProviderTemplateBuilder<TBuilder, IStaticSignalProviderTemplate, TOptions>
        where TOptions : StaticSignalProviderOptions
        where TType : class, IStaticSignalProvider;
}
