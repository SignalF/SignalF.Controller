using SignalF.Configuration.SignalConfiguration;
using SignalF.Controller.Configuration;
using SignalF.Controller.Signals.SignalProcessor;

namespace SignalF.Configuration;

public partial interface ISignalFConfiguration
{
    ISignalFConfiguration AddSignalProcessorConfiguration<TBuilder, TOptions>(Action<TBuilder> builder)
        where TBuilder : ISignalProcessorConfigurationBuilder
        where TOptions : SignalFConfigurationOptions;

    ISignalFConfiguration AddSignalProcessorConfiguration<TBuilder, TOptions, TType>(Action<TBuilder> builder)
        where TBuilder : ISignalProcessorConfigurationBuilder
        where TOptions : SignalFConfigurationOptions
        where TType : class, ISignalProcessor;

    ISignalFConfiguration AddSignalProcessorDefinition<TBuilder, TOptions>(Action<TBuilder> builder)
        where TBuilder : ISignalProcessorDefinitionBuilder
        where TOptions : SignalFConfigurationOptions;

    ISignalFConfiguration AddSignalProcessorDefinition<TBuilder, TOptions, TType>(Action<TBuilder> builder)
        where TBuilder : ISignalProcessorDefinitionBuilder
        where TOptions : SignalFConfigurationOptions
        where TType : class, ISignalProcessor;

    ISignalFConfiguration AddSignalProcessorTemplate<TBuilder, TOptions>(Action<TBuilder> builder)
        where TBuilder : ISignalProcessorTemplateBuilder
        where TOptions : SignalFConfigurationOptions;

    ISignalFConfiguration AddSignalProcessorTemplate<TBuilder, TOptions, TType>(Action<TBuilder> builder)
        where TBuilder : ISignalProcessorTemplateBuilder
        where TOptions : SignalFConfigurationOptions
        where TType : class, ISignalProcessor;
}
