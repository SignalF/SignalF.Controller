using System;
using SignalF.Configuration.SignalConfiguration;
using SignalF.Controller.Configuration;
using SignalF.Controller.Signals.SignalProcessor;

namespace SignalF.Configuration;

public partial interface ICoreConfiguration
{
    ICoreConfiguration AddSignalProcessorConfiguration<TBuilder, TOptions>(Action<TBuilder> builder)
        where TBuilder : ISignalProcessorConfigurationBuilder
        where TOptions : CoreConfigurationOptions;

    ICoreConfiguration AddSignalProcessorConfiguration<TBuilder, TOptions, TType>(Action<TBuilder> builder)
        where TBuilder : ISignalProcessorConfigurationBuilder
        where TOptions : CoreConfigurationOptions
        where TType : class, ISignalProcessor;

    ICoreConfiguration AddSignalProcessorDefinition<TBuilder, TOptions>(Action<TBuilder> builder)
        where TBuilder : ISignalProcessorDefinitionBuilder
        where TOptions : CoreConfigurationOptions;

    ICoreConfiguration AddSignalProcessorDefinition<TBuilder, TOptions, TType>(Action<TBuilder> builder)
        where TBuilder : ISignalProcessorDefinitionBuilder
        where TOptions : CoreConfigurationOptions
        where TType : class, ISignalProcessor;

    ICoreConfiguration AddSignalProcessorTemplate<TBuilder, TOptions>(Action<TBuilder> builder)
        where TBuilder : ISignalProcessorTemplateBuilder
        where TOptions : CoreConfigurationOptions;

    ICoreConfiguration AddSignalProcessorTemplate<TBuilder, TOptions, TType>(Action<TBuilder> builder)
        where TBuilder : ISignalProcessorTemplateBuilder
        where TOptions : CoreConfigurationOptions
        where TType : class, ISignalProcessor;
}
