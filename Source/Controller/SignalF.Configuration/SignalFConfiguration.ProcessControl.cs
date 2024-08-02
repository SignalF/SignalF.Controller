using Microsoft.Extensions.DependencyInjection;
using SignalF.Configuration.ProcessControl;
using SignalF.Controller.Signals.ProcessControl;
using SignalF.Datamodel.Workflow;

namespace SignalF.Configuration;

public partial class SignalFConfiguration : ISignalFConfiguration
{
    public ISignalFConfiguration AddProcessControlConfiguration<TBuilder, TOptions>(Action<TBuilder> action)
        where TBuilder : IProcessControlConfigurationBuilder<TBuilder, IProcessControlConfiguration, TOptions>
        where TOptions : ProcessControlOptions
    {
        _signalProcessorConfigurations.Add(configuration =>
        {
            var builder = _serviceProvider.GetRequiredService<TBuilder>();
            action(builder);
            builder.Build(configuration.SignalProcessorConfigurations.Create<IProcessControlConfiguration>());
        });
        return this;
    }

    public ISignalFConfiguration AddProcessControlConfiguration<TBuilder, TOptions, TType>(Action<TBuilder> action)
        where TBuilder : IProcessControlConfigurationBuilder<TBuilder, IProcessControlConfiguration, TOptions>
        where TOptions : ProcessControlOptions
        where TType : class, IProcessControlAdapter
    {
        _signalProcessorConfigurations.Add(configuration =>
        {
            var builder = _serviceProvider.GetRequiredService<TBuilder>();
            builder.SetType<TType>();
            action(builder);
            builder.Build(configuration.SignalProcessorConfigurations.Create<IProcessControlConfiguration>());
        });
        return this;
    }

    public ISignalFConfiguration AddProcessControlDefinition<TBuilder, TOptions>(Action<TBuilder> action)
        where TBuilder : IProcessControlDefinitionBuilder<TBuilder, IProcessControlDefinition, TOptions>
        where TOptions : ProcessControlOptions
    {
        _signalProcessorDefinitions.Add(configuration =>
        {
            var builder = _serviceProvider.GetRequiredService<TBuilder>();
            action(builder);
            builder.Build(configuration.SignalProcessorDefinitions.Create<IProcessControlDefinition>());
        });
        return this;
    }

    public ISignalFConfiguration AddProcessControlDefinition<TBuilder, TOptions, TType>(Action<TBuilder> action)
        where TBuilder : IProcessControlDefinitionBuilder<TBuilder, IProcessControlDefinition, TOptions>
        where TOptions : ProcessControlOptions
        where TType : class, IProcessControlAdapter
    {
        _signalProcessorDefinitions.Add(configuration =>
        {
            var builder = _serviceProvider.GetRequiredService<TBuilder>();
            builder.SetType<TType>();
            action(builder);
            builder.Build(configuration.SignalProcessorDefinitions.Create<IProcessControlDefinition>());
        });
        return this;
    }

    public ISignalFConfiguration AddProcessControlTemplate<TBuilder, TOptions>(Action<TBuilder> action)
        where TBuilder : IProcessControlTemplateBuilder<TBuilder, IProcessControlTemplate, TOptions>
        where TOptions : ProcessControlOptions
    {
        _signalProcessorTemplates.Add(configuration =>
        {
            var builder = _serviceProvider.GetRequiredService<TBuilder>();
            action(builder);
            builder.Build(configuration.SignalProcessorTemplates.Create<IProcessControlTemplate>());
        });
        return this;
    }

    public ISignalFConfiguration AddProcessControlTemplate<TBuilder, TOptions, TType>(Action<TBuilder> action)
        where TBuilder : IProcessControlTemplateBuilder<TBuilder, IProcessControlTemplate, TOptions>
        where TOptions : ProcessControlOptions
        where TType : class, IProcessControlAdapter
    {
        _signalProcessorTemplates.Add(configuration =>
        {
            var builder = _serviceProvider.GetRequiredService<TBuilder>();
            builder.SetType<TType>();
            action(builder);
            builder.Build(configuration.SignalProcessorTemplates.Create<IProcessControlTemplate>());
        });
        return this;
    }
}
