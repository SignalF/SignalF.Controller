using Microsoft.Extensions.DependencyInjection;
using SignalF.Configuration.SignalConfiguration;
using SignalF.Controller.Configuration;
using SignalF.Controller.Signals.SignalProcessor;
using SignalF.Datamodel.Signals;

namespace SignalF.Configuration;

public partial class SignalFConfiguration : ISignalFConfiguration
{
    public ISignalFConfiguration AddSignalProcessorConfiguration<TBuilder, TOptions>(Action<TBuilder> action)
        where TBuilder : ISignalProcessorConfigurationBuilder
        where TOptions : SignalFConfigurationOptions
    {
        _signalProcessorConfigurations.Add(configuration =>
        {
            var builder = _serviceProvider.GetRequiredService<TBuilder>();
            action(builder);
            builder.Build(configuration.SignalProcessorConfigurations.Create<ISignalProcessorConfiguration>());
        });
        return this;
    }

    public ISignalFConfiguration AddSignalProcessorConfiguration<TBuilder, TOptions, TType>(Action<TBuilder> action)
        where TBuilder : ISignalProcessorConfigurationBuilder
        where TOptions : SignalFConfigurationOptions
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

    public ISignalFConfiguration AddSignalProcessorDefinition<TBuilder, TOptions>(Action<TBuilder> action)
        where TBuilder : ISignalProcessorDefinitionBuilder
        where TOptions : SignalFConfigurationOptions
    {
        _signalProcessorDefinitions.Add(configuration =>
        {
            var builder = _serviceProvider.GetRequiredService<TBuilder>();
            action(builder);
            builder.Build(configuration.SignalProcessorDefinitions.Create<ISignalProcessorDefinition>());
        });
        return this;
    }

    public ISignalFConfiguration AddSignalProcessorDefinition<TBuilder, TOptions, TType>(Action<TBuilder> action)
        where TBuilder : ISignalProcessorDefinitionBuilder
        where TOptions : SignalFConfigurationOptions
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

    public ISignalFConfiguration AddSignalProcessorTemplate<TBuilder, TOptions>(Action<TBuilder> action)
        where TBuilder : ISignalProcessorTemplateBuilder
        where TOptions : SignalFConfigurationOptions
    {
        _signalProcessorTemplates.Add(configuration =>
        {
            var builder = _serviceProvider.GetRequiredService<TBuilder>();
            action(builder);
            builder.Build(configuration.SignalProcessorTemplates.Create<ISignalProcessorTemplate>());
        });
        return this;
    }

    public ISignalFConfiguration AddSignalProcessorTemplate<TBuilder, TOptions, TType>(Action<TBuilder> action)
        where TBuilder : ISignalProcessorTemplateBuilder
        where TOptions : SignalFConfigurationOptions
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
