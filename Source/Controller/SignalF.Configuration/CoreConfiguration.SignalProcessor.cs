using Microsoft.Extensions.DependencyInjection;
using SignalF.Configuration.SignalConfiguration;
using SignalF.Controller.Configuration;
using SignalF.Controller.Signals.SignalProcessor;
using SignalF.Datamodel.Signals;

namespace SignalF.Configuration;

public partial class CoreConfiguration : ICoreConfiguration
{
    public ICoreConfiguration AddSignalProcessorConfiguration<TBuilder, TOptions>(Action<TBuilder> action)
        where TBuilder : ISignalProcessorConfigurationBuilder
        where TOptions : CoreConfigurationOptions
    {
        _signalProcessorConfigurations.Add(configuration =>
        {
            var builder = _serviceProvider.GetRequiredService<TBuilder>();
            action(builder);
            builder.Build(configuration.SignalProcessorConfigurations.Create<ISignalProcessorConfiguration>());
        });
        return this;
    }

    public ICoreConfiguration AddSignalProcessorConfiguration<TBuilder, TOptions, TType>(Action<TBuilder> action)
        where TBuilder : ISignalProcessorConfigurationBuilder
        where TOptions : CoreConfigurationOptions
        where TType : class, ISignalProcessor
    {
        _signalProcessorConfigurations.Add(configuration =>
        {
            var builder = _serviceProvider.GetRequiredService<TBuilder>();
            builder.SetType<TType>();
            action(builder);
            builder.Build(configuration.SignalProcessorConfigurations.Create<ISignalProcessorConfiguration>());
        });
        return this;
    }

    public ICoreConfiguration AddSignalProcessorDefinition<TBuilder, TOptions>(Action<TBuilder> action)
        where TBuilder : ISignalProcessorDefinitionBuilder
        where TOptions : CoreConfigurationOptions
    {
        _signalProcessorDefinitions.Add(configuration =>
        {
            var builder = _serviceProvider.GetRequiredService<TBuilder>();
            action(builder);
            builder.Build(configuration.SignalProcessorDefinitions.Create<ISignalProcessorDefinition>());
        });
        return this;
    }

    public ICoreConfiguration AddSignalProcessorDefinition<TBuilder, TOptions, TType>(Action<TBuilder> action)
        where TBuilder : ISignalProcessorDefinitionBuilder
        where TOptions : CoreConfigurationOptions
        where TType : class, ISignalProcessor
    {
        _signalProcessorDefinitions.Add(configuration =>
        {
            var builder = _serviceProvider.GetRequiredService<TBuilder>();
            builder.SetType<TType>();
            action(builder);
            builder.Build(configuration.SignalProcessorDefinitions.Create<ISignalProcessorDefinition>());
        });
        return this;
    }

    public ICoreConfiguration AddSignalProcessorTemplate<TBuilder, TOptions>(Action<TBuilder> action)
        where TBuilder : ISignalProcessorTemplateBuilder
        where TOptions : CoreConfigurationOptions
    {
        _signalProcessorTemplates.Add(configuration =>
        {
            var builder = _serviceProvider.GetRequiredService<TBuilder>();
            action(builder);
            builder.Build(configuration.SignalProcessorTemplates.Create<ISignalProcessorTemplate>());
        });
        return this;
    }

    public ICoreConfiguration AddSignalProcessorTemplate<TBuilder, TOptions, TType>(Action<TBuilder> action)
        where TBuilder : ISignalProcessorTemplateBuilder
        where TOptions : CoreConfigurationOptions
        where TType : class, ISignalProcessor
    {
        {
            _signalProcessorTemplates.Add(configuration =>
            {
                var builder = _serviceProvider.GetRequiredService<TBuilder>();
                builder.SetType<TType>();
                action(builder);
                builder.Build(configuration.SignalProcessorTemplates.Create<ISignalProcessorTemplate>());
            });
            return this;
        }
    }
}
