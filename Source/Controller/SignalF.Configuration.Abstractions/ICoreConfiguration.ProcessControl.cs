using System;
using SignalF.Configuration.ProcessControl;
using SignalF.Controller.Configuration;
using SignalF.Controller.Signals.ProcessControl;

namespace SignalF.Configuration;

public partial interface ICoreConfiguration
{
    ICoreConfiguration AddProcessControlConfiguration<TBuilder, TOptions>(Action<TBuilder> builder)
        where TBuilder : IProcessControlConfigurationBuilder
        where TOptions : CoreConfigurationOptions;

    ICoreConfiguration AddProcessControlConfiguration<TBuilder, TOptions, TType>(Action<TBuilder> builder)
        where TBuilder : IProcessControlConfigurationBuilder
        where TOptions : CoreConfigurationOptions
        where TType : class, IProcessControlAdapter;

    ICoreConfiguration AddProcessControlDefinition<TBuilder, TOptions>(Action<TBuilder> builder)
        where TBuilder : IProcessControlDefinitionBuilder
        where TOptions : CoreConfigurationOptions;

    ICoreConfiguration AddProcessControlDefinition<TBuilder, TOptions, TType>(Action<TBuilder> builder)
        where TBuilder : IProcessControlDefinitionBuilder
        where TOptions : CoreConfigurationOptions
        where TType : class, IProcessControlAdapter;

    ICoreConfiguration AddProcessControlTemplate<TBuilder, TOptions>(Action<TBuilder> builder)
        where TBuilder : IProcessControlTemplateBuilder
        where TOptions : CoreConfigurationOptions;

    ICoreConfiguration AddProcessControlTemplate<TBuilder, TOptions, TType>(Action<TBuilder> builder)
        where TBuilder : IProcessControlTemplateBuilder
        where TOptions : CoreConfigurationOptions
        where TType : class, IProcessControlAdapter;
}
