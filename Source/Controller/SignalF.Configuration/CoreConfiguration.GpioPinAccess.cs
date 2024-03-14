using Microsoft.Extensions.DependencyInjection;
using SignalF.Configuration.Devices.Gpio;
using SignalF.Controller.Configuration;
using SignalF.Controller.Signals.Devices;
using SignalF.Datamodel.Hardware;

namespace SignalF.Configuration;

public partial class CoreConfiguration : ICoreConfiguration
{
    public ICoreConfiguration AddGpioPinAccessConfiguration<TBuilder, TOptions>(Action<TBuilder> action)
        where TBuilder : IGpioPinAccessConfigurationBuilder
        where TOptions : CoreConfigurationOptions
    {
        _signalProcessorConfigurations.Add(configuration =>
        {
            var builder = _serviceProvider.GetRequiredService<TBuilder>();
            action(builder);
            builder.Build(configuration.SignalProcessorConfigurations.Create<IGpioPinAccessConfiguration>());
        });
        return this;
    }

    public ICoreConfiguration AddGpioPinAccessConfiguration<TBuilder, TOptions, TType>(Action<TBuilder> action)
        where TBuilder : IGpioPinAccessConfigurationBuilder
        where TOptions : CoreConfigurationOptions
        where TType : class, IGpioPinAccess
    {
        _signalProcessorConfigurations.Add(configuration =>
        {
            var builder = _serviceProvider.GetRequiredService<TBuilder>();
            builder.SetType<TType>();
            action(builder);
            builder.Build(configuration.SignalProcessorConfigurations.Create<IGpioPinAccessConfiguration>());
        });
        return this;
    }

    public ICoreConfiguration AddGpioPinAccessDefinition<TBuilder, TOptions>(Action<TBuilder> action)
        where TBuilder : IGpioPinAccessDefinitionBuilder
        where TOptions : CoreConfigurationOptions
    {
        _signalProcessorDefinitions.Add(configuration =>
        {
            var builder = _serviceProvider.GetRequiredService<TBuilder>();
            action(builder);
            builder.Build(configuration.SignalProcessorDefinitions.Create<IGpioPinAccessDefinition>());
        });
        return this;
    }

    public ICoreConfiguration AddGpioPinAccessDefinition<TBuilder, TOptions, TType>(Action<TBuilder> action)
        where TBuilder : IGpioPinAccessDefinitionBuilder
        where TOptions : CoreConfigurationOptions
        where TType : class, IGpioPinAccess
    {
        _signalProcessorDefinitions.Add(configuration =>
        {
            var builder = _serviceProvider.GetRequiredService<TBuilder>();
            builder.SetType<TType>();
            action(builder);
            builder.Build(configuration.SignalProcessorDefinitions.Create<IGpioPinAccessDefinition>());
        });
        return this;
    }

    public ICoreConfiguration AddGpioPinAccessTemplate<TBuilder, TOptions>(Action<TBuilder> action)
        where TBuilder : IGpioPinAccessTemplateBuilder
        where TOptions : CoreConfigurationOptions
    {
        _signalProcessorTemplates.Add(configuration =>
        {
            var builder = _serviceProvider.GetRequiredService<TBuilder>();
            action(builder);
            builder.Build(configuration.SignalProcessorTemplates.Create<IGpioPinAccessTemplate>());
        });
        return this;
    }

    public ICoreConfiguration AddGpioPinAccessTemplate<TBuilder, TOptions, TType>(Action<TBuilder> action)
        where TBuilder : IGpioPinAccessTemplateBuilder
        where TOptions : CoreConfigurationOptions
        where TType : class, IGpioPinAccess
    {
        _signalProcessorTemplates.Add(configuration =>
        {
            var builder = _serviceProvider.GetRequiredService<TBuilder>();
            builder.SetType<TType>();
            action(builder);
            builder.Build(configuration.SignalProcessorTemplates.Create<IGpioPinAccessTemplate>());
        });
        return this;
    }
}
