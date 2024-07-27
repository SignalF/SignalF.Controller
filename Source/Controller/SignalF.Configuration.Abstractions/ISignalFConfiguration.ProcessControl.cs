using SignalF.Configuration.ProcessControl;
using SignalF.Controller.Configuration;
using SignalF.Controller.Signals.ProcessControl;

namespace SignalF.Configuration;

public partial interface ISignalFConfiguration
{
    ISignalFConfiguration AddProcessControlConfiguration<TBuilder, TOptions>(Action<TBuilder> builder)
        where TBuilder : IProcessControlConfigurationBuilder
        where TOptions : SignalFConfigurationOptions;

    ISignalFConfiguration AddProcessControlConfiguration<TBuilder, TOptions, TType>(Action<TBuilder> builder)
        where TBuilder : IProcessControlConfigurationBuilder
        where TOptions : SignalFConfigurationOptions
        where TType : class, IProcessControlAdapter;

    ISignalFConfiguration AddProcessControlDefinition<TBuilder, TOptions>(Action<TBuilder> builder)
        where TBuilder : IProcessControlDefinitionBuilder
        where TOptions : SignalFConfigurationOptions;

    ISignalFConfiguration AddProcessControlDefinition<TBuilder, TOptions, TType>(Action<TBuilder> builder)
        where TBuilder : IProcessControlDefinitionBuilder
        where TOptions : SignalFConfigurationOptions
        where TType : class, IProcessControlAdapter;

    ISignalFConfiguration AddProcessControlTemplate<TBuilder, TOptions>(Action<TBuilder> builder)
        where TBuilder : IProcessControlTemplateBuilder
        where TOptions : SignalFConfigurationOptions;

    ISignalFConfiguration AddProcessControlTemplate<TBuilder, TOptions, TType>(Action<TBuilder> builder)
        where TBuilder : IProcessControlTemplateBuilder
        where TOptions : SignalFConfigurationOptions
        where TType : class, IProcessControlAdapter;
}
