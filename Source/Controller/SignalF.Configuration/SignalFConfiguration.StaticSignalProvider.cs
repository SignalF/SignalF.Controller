using Microsoft.Extensions.DependencyInjection;
using SignalF.Configuration.StaticSignalProvider;
using SignalF.Controller;
using SignalF.Controller.Configuration;
using SignalF.Controller.Signals.SignalProcessor;
using SignalF.Datamodel.Signals;

namespace SignalF.Configuration;

public partial class SignalFConfiguration : ISignalFConfiguration
{
    public ISignalFConfiguration AddStaticSignalProviderConfiguration<TBuilder, TOptions>(Action<TBuilder> action)
        where TBuilder : IStaticSignalProviderConfigurationBuilder<TBuilder, IStaticSignalProviderConfiguration, TOptions>
        where TOptions : StaticSignalProviderOptions
    {
        _signalProcessorConfigurations.Add(configuration =>
        {
            var builder = _serviceProvider.GetRequiredService<TBuilder>();
            action(builder);
            builder.Build(configuration.SignalProcessorConfigurations.Create<IStaticSignalProviderConfiguration>());
        });
        return this;
    }

    public ISignalFConfiguration AddStaticSignalProviderConfiguration<TBuilder, TOptions, TType>(Action<TBuilder> action)
        where TBuilder : IStaticSignalProviderConfigurationBuilder<TBuilder, IStaticSignalProviderConfiguration, TOptions>
        where TOptions : StaticSignalProviderOptions
        where TType : class, IStaticSignalProvider
    {
        _signalProcessorConfigurations.Add(configuration =>
        {
            var builder = _serviceProvider.GetRequiredService<TBuilder>();
            builder.SetType<TType>();
            action(builder);
            builder.Build(configuration.SignalProcessorConfigurations.Create<IStaticSignalProviderConfiguration>());
        });
        return this;
    }

    public ISignalFConfiguration AddStaticSignalProviderDefinition<TBuilder, TOptions>(Action<TBuilder> action)
        where TBuilder : IStaticSignalProviderDefinitionBuilder<TBuilder, IStaticSignalProviderDefinition, TOptions>
        where TOptions : StaticSignalProviderOptions
    {
        _signalProcessorDefinitions.Add(configuration =>
        {
            var builder = _serviceProvider.GetRequiredService<TBuilder>();
            action(builder);
            builder.Build(configuration.SignalProcessorDefinitions.Create<IStaticSignalProviderDefinition>());
        });
        return this;
    }

    public ISignalFConfiguration AddStaticSignalProviderDefinition<TBuilder, TOptions, TType>(Action<TBuilder> action)
        where TBuilder : IStaticSignalProviderDefinitionBuilder<TBuilder, IStaticSignalProviderDefinition, TOptions>
        where TOptions : StaticSignalProviderOptions
        where TType : class, IStaticSignalProvider
    {
        _signalProcessorDefinitions.Add(configuration =>
        {
            var builder = _serviceProvider.GetRequiredService<TBuilder>();
            builder.SetType<TType>();
            action(builder);
            builder.Build(configuration.SignalProcessorDefinitions.Create<IStaticSignalProviderDefinition>());
        });
        return this;
    }

    public ISignalFConfiguration AddStaticSignalProviderTemplate<TBuilder, TOptions>(Action<TBuilder> action)
        where TBuilder : IStaticSignalProviderTemplateBuilder<TBuilder, IStaticSignalProviderTemplate, TOptions>
        where TOptions : StaticSignalProviderOptions
    {
        _signalProcessorTemplates.Add(configuration =>
        {
            var builder = _serviceProvider.GetRequiredService<TBuilder>();
            action(builder);
            builder.Build(configuration.SignalProcessorTemplates.Create<IStaticSignalProviderTemplate>());
        });
        return this;
    }

    public ISignalFConfiguration AddStaticSignalProviderTemplate<TBuilder, TOptions, TType>(Action<TBuilder> action)
        where TBuilder : IStaticSignalProviderTemplateBuilder<TBuilder, IStaticSignalProviderTemplate, TOptions>
        where TOptions : StaticSignalProviderOptions
        where TType : class, IStaticSignalProvider
    {
        _signalProcessorTemplates.Add(configuration =>
        {
            var builder = _serviceProvider.GetRequiredService<TBuilder>();
            builder.SetType<TType>();
            action(builder);
            builder.Build(configuration.SignalProcessorTemplates.Create<IStaticSignalProviderTemplate>());
        });
        return this;
    }
}
