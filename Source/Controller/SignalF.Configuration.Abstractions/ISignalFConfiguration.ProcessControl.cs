using SignalF.Configuration.ProcessControl;
using SignalF.Controller.Signals.ProcessControl;
using SignalF.Datamodel.Workflow;

namespace SignalF.Configuration;

public partial interface ISignalFConfiguration
{
    ISignalFConfiguration AddProcessControlConfiguration<TBuilder, TOptions>(Action<TBuilder> builder)
        where TBuilder : IProcessControlConfigurationBuilder<TBuilder, IProcessControlConfiguration, TOptions>
        where TOptions : ProcessControlOptions;

    ISignalFConfiguration AddProcessControlConfiguration<TBuilder, TOptions, TType>(Action<TBuilder> builder)
        where TBuilder : IProcessControlConfigurationBuilder<TBuilder, IProcessControlConfiguration, TOptions>
        where TOptions : ProcessControlOptions
        where TType : class, IProcessControlAdapter;

    ISignalFConfiguration AddProcessControlDefinition<TBuilder, TOptions>(Action<TBuilder> builder)
        where TBuilder : IProcessControlDefinitionBuilder<TBuilder, IProcessControlDefinition, TOptions>
        where TOptions : ProcessControlOptions;

    ISignalFConfiguration AddProcessControlDefinition<TBuilder, TOptions, TType>(Action<TBuilder> builder)
        where TBuilder : IProcessControlDefinitionBuilder<TBuilder, IProcessControlDefinition, TOptions>
        where TOptions : ProcessControlOptions
        where TType : class, IProcessControlAdapter;

    ISignalFConfiguration AddProcessControlTemplate<TBuilder, TOptions>(Action<TBuilder> builder)
        where TBuilder : IProcessControlTemplateBuilder<TBuilder, IProcessControlTemplate, TOptions>
        where TOptions : ProcessControlOptions;

    ISignalFConfiguration AddProcessControlTemplate<TBuilder, TOptions, TType>(Action<TBuilder> builder)
        where TBuilder : IProcessControlTemplateBuilder<TBuilder, IProcessControlTemplate, TOptions>
        where TOptions : ProcessControlOptions
        where TType : class, IProcessControlAdapter;
}
