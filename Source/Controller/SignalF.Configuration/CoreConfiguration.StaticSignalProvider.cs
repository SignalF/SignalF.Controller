using Microsoft.Extensions.DependencyInjection;
using SignalF.Configuration.StaticSignalProvider;
using SignalF.Controller.Configuration;
using SignalF.Controller.Signals.SignalProcessor;
using SignalF.Datamodel.Signals;

namespace SignalF.Configuration;

public partial class CoreConfiguration : ICoreConfiguration
{
    public ICoreConfiguration AddStaticSignalProviderConfiguration<TBuilder, TOptions>(Action<TBuilder> action)
        where TBuilder : IStaticSignalProviderConfigurationBuilder
        where TOptions : CoreConfigurationOptions
    {
        _signalProcessorConfigurations.Add(configuration =>
        {
            var builder = _serviceProvider.GetRequiredService<TBuilder>();
            action(builder);
            builder.Build(configuration.SignalProcessorConfigurations.Create<IStaticSignalProviderConfiguration>());
        });
        return this;
    }

    public ICoreConfiguration AddStaticSignalProviderConfiguration<TBuilder, TOptions, TType>(Action<TBuilder> action)
        where TBuilder : IStaticSignalProviderConfigurationBuilder
        where TOptions : CoreConfigurationOptions
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

    public ICoreConfiguration AddStaticSignalProviderDefinition<TBuilder, TOptions>(Action<TBuilder> action)
        where TBuilder : IStaticSignalProviderDefinitionBuilder
        where TOptions : CoreConfigurationOptions
    {
        _signalProcessorDefinitions.Add(configuration =>
        {
            var builder = _serviceProvider.GetRequiredService<TBuilder>();
            action(builder);
            builder.Build(configuration.SignalProcessorDefinitions.Create<IStaticSignalProviderDefinition>());
        });
        return this;
    }

    public ICoreConfiguration AddStaticSignalProviderDefinition<TBuilder, TOptions, TType>(Action<TBuilder> action)
        where TBuilder : IStaticSignalProviderDefinitionBuilder
        where TOptions : CoreConfigurationOptions
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

    public ICoreConfiguration AddStaticSignalProviderTemplate<TBuilder, TOptions>(Action<TBuilder> action)
        where TBuilder : IStaticSignalProviderTemplateBuilder
        where TOptions : CoreConfigurationOptions
    {
        _signalProcessorTemplates.Add(configuration =>
        {
            var builder = _serviceProvider.GetRequiredService<TBuilder>();
            action(builder);
            builder.Build(configuration.SignalProcessorTemplates.Create<IStaticSignalProviderTemplate>());
        });
        return this;
    }

    public ICoreConfiguration AddStaticSignalProviderTemplate<TBuilder, TOptions, TType>(Action<TBuilder> action)
        where TBuilder : IStaticSignalProviderTemplateBuilder
        where TOptions : CoreConfigurationOptions
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
