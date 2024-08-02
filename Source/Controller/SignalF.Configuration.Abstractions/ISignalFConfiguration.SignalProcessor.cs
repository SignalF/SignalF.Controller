using SignalF.Configuration.SignalConfiguration;
using SignalF.Controller;
using SignalF.Controller.Configuration;
using SignalF.Controller.Signals.SignalProcessor;
using SignalF.Datamodel.Signals;
using SignalF.Datamodel.Workflow;

namespace SignalF.Configuration;

public partial interface ISignalFConfiguration
{
    ISignalFConfiguration AddSignalProcessorConfiguration<TBuilder, TOptions>(Action<TBuilder> builder)
        where TBuilder : ISignalProcessorConfigurationBuilder<TBuilder, ISignalProcessorConfiguration, TOptions>
        where TOptions : SignalProcessorOptions;

    ISignalFConfiguration AddSignalProcessorConfiguration<TBuilder, TOptions, TType>(Action<TBuilder> builder)
        where TBuilder : ISignalProcessorConfigurationBuilder<TBuilder, ISignalProcessorConfiguration, TOptions>
        where TOptions : SignalProcessorOptions
        where TType : class, ISignalProcessor;

    ISignalFConfiguration AddSignalProcessorDefinition<TBuilder, TOptions>(Action<TBuilder> builder)
        where TBuilder : ISignalProcessorDefinitionBuilder<TBuilder, ISignalProcessorDefinition, TOptions>
        where TOptions : SignalProcessorOptions;

    ISignalFConfiguration AddSignalProcessorDefinition<TBuilder, TOptions, TType>(Action<TBuilder> builder)
        where TBuilder : ISignalProcessorDefinitionBuilder<TBuilder, ISignalProcessorDefinition, TOptions>
        where TOptions : SignalFConfigurationOptions
        where TType : class, ISignalProcessor;

    ISignalFConfiguration AddSignalProcessorTemplate<TBuilder, TOptions>(Action<TBuilder> builder)
        where TBuilder : ISignalProcessorTemplateBuilder<TBuilder, ISignalProcessorTemplate, TOptions>
        where TOptions : SignalFConfigurationOptions;

    ISignalFConfiguration AddSignalProcessorTemplate<TBuilder, TOptions, TType>(Action<TBuilder> builder)
        where TBuilder : ISignalProcessorTemplateBuilder<TBuilder, ISignalProcessorTemplate, TOptions>
        where TOptions : SignalFConfigurationOptions
        where TType : class, ISignalProcessor;
}
