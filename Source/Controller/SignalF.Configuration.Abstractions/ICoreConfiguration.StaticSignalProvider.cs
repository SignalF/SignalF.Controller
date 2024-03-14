using System;
using SignalF.Configuration.StaticSignalProvider;
using SignalF.Controller.Configuration;
using SignalF.Controller.Signals.SignalProcessor;

namespace SignalF.Configuration;

public partial interface ICoreConfiguration
{
    ICoreConfiguration AddStaticSignalProviderConfiguration<TBuilder, TOptions>(Action<TBuilder> builder)
        where TBuilder : IStaticSignalProviderConfigurationBuilder
        where TOptions : CoreConfigurationOptions;

    ICoreConfiguration AddStaticSignalProviderConfiguration<TBuilder, TOptions, TType>(Action<TBuilder> builder)
        where TBuilder : IStaticSignalProviderConfigurationBuilder
        where TOptions : CoreConfigurationOptions
        where TType : class, IStaticSignalProvider;

    ICoreConfiguration AddStaticSignalProviderDefinition<TBuilder, TOptions>(Action<TBuilder> builder)
        where TBuilder : IStaticSignalProviderDefinitionBuilder
        where TOptions : CoreConfigurationOptions;

    ICoreConfiguration AddStaticSignalProviderDefinition<TBuilder, TOptions, TType>(Action<TBuilder> builder)
        where TBuilder : IStaticSignalProviderDefinitionBuilder
        where TOptions : CoreConfigurationOptions
        where TType : class, IStaticSignalProvider;

    ICoreConfiguration AddStaticSignalProviderTemplate<TBuilder, TOptions>(Action<TBuilder> builder)
        where TBuilder : IStaticSignalProviderTemplateBuilder
        where TOptions : CoreConfigurationOptions;

    ICoreConfiguration AddStaticSignalProviderTemplate<TBuilder, TOptions, TType>(Action<TBuilder> acbuildertion)
        where TBuilder : IStaticSignalProviderTemplateBuilder
        where TOptions : CoreConfigurationOptions
        where TType : class, IStaticSignalProvider;
}
