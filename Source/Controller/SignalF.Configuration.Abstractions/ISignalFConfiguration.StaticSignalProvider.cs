using System;
using SignalF.Configuration.StaticSignalProvider;
using SignalF.Controller.Configuration;
using SignalF.Controller.Signals.SignalProcessor;

namespace SignalF.Configuration;

public partial interface ISignalFConfiguration
{
    ISignalFConfiguration AddStaticSignalProviderConfiguration<TBuilder, TOptions>(Action<TBuilder> builder)
        where TBuilder : IStaticSignalProviderConfigurationBuilder
        where TOptions : SignalFConfigurationOptions;

    ISignalFConfiguration AddStaticSignalProviderConfiguration<TBuilder, TOptions, TType>(Action<TBuilder> builder)
        where TBuilder : IStaticSignalProviderConfigurationBuilder
        where TOptions : SignalFConfigurationOptions
        where TType : class, IStaticSignalProvider;

    ISignalFConfiguration AddStaticSignalProviderDefinition<TBuilder, TOptions>(Action<TBuilder> builder)
        where TBuilder : IStaticSignalProviderDefinitionBuilder
        where TOptions : SignalFConfigurationOptions;

    ISignalFConfiguration AddStaticSignalProviderDefinition<TBuilder, TOptions, TType>(Action<TBuilder> builder)
        where TBuilder : IStaticSignalProviderDefinitionBuilder
        where TOptions : SignalFConfigurationOptions
        where TType : class, IStaticSignalProvider;

    ISignalFConfiguration AddStaticSignalProviderTemplate<TBuilder, TOptions>(Action<TBuilder> builder)
        where TBuilder : IStaticSignalProviderTemplateBuilder
        where TOptions : SignalFConfigurationOptions;

    ISignalFConfiguration AddStaticSignalProviderTemplate<TBuilder, TOptions, TType>(Action<TBuilder> acbuildertion)
        where TBuilder : IStaticSignalProviderTemplateBuilder
        where TOptions : SignalFConfigurationOptions
        where TType : class, IStaticSignalProvider;
}
