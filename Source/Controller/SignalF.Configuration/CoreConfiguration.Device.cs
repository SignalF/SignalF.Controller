﻿using Microsoft.Extensions.DependencyInjection;
using SignalF.Configuration.Devices;
using SignalF.Controller.Configuration;
using SignalF.Controller.Signals.Devices;
using SignalF.Datamodel.Hardware;

namespace SignalF.Configuration;

public partial class CoreConfiguration : ICoreConfiguration
{
    public ICoreConfiguration AddDeviceConfiguration<TBuilder, TOptions>(Action<TBuilder> action)
        where TBuilder : IDeviceConfigurationBuilder
        where TOptions : CoreConfigurationOptions
    {
        _signalProcessorConfigurations.Add(configuration =>
        {
            var builder = _serviceProvider.GetRequiredService<TBuilder>();
            action(builder);
            builder.Build(configuration.SignalProcessorConfigurations.Create<IDeviceConfiguration>());
        });
        return this;
    }

    public ICoreConfiguration AddDeviceConfiguration<TBuilder, TOptions, TType>(Action<TBuilder> action)
        where TBuilder : IDeviceConfigurationBuilder
        where TOptions : CoreConfigurationOptions
        where TType : class, IDevice
    {
        _signalProcessorConfigurations.Add(configuration =>
        {
            var builder = _serviceProvider.GetRequiredService<TBuilder>();
            builder.SetType<TType>();
            action(builder);
            builder.Build(configuration.SignalProcessorConfigurations.Create<IDeviceConfiguration>());
        });
        return this;
    }

    public ICoreConfiguration AddDeviceDefinition<TBuilder, TOptions>(Action<TBuilder> action)
        where TBuilder : IDeviceDefinitionBuilder
        where TOptions : CoreConfigurationOptions
    {
        _signalProcessorDefinitions.Add(configuration =>
        {
            var builder = _serviceProvider.GetRequiredService<TBuilder>();
            action(builder);
            builder.Build(configuration.SignalProcessorDefinitions.Create<IDeviceDefinition>());
        });
        return this;
    }

    public ICoreConfiguration AddDeviceDefinition<TBuilder, TOptions, TType>(Action<TBuilder> action)
        where TBuilder : IDeviceDefinitionBuilder
        where TOptions : CoreConfigurationOptions
        where TType : class, IDevice
    {
        _signalProcessorDefinitions.Add(configuration =>
        {
            var builder = _serviceProvider.GetRequiredService<TBuilder>();
            builder.SetType<TType>();
            action(builder);
            builder.Build(configuration.SignalProcessorDefinitions.Create<IDeviceDefinition>());
        });
        return this;
    }

    public ICoreConfiguration AddDeviceTemplate<TBuilder, TOptions>(Action<TBuilder> action)
        where TBuilder : IDeviceTemplateBuilder
        where TOptions : CoreConfigurationOptions
    {
        _signalProcessorTemplates.Add(configuration =>
        {
            var builder = _serviceProvider.GetRequiredService<TBuilder>();
            action(builder);
            builder.Build(configuration.SignalProcessorTemplates.Create<IDeviceTemplate>());
        });
        return this;
    }

    public ICoreConfiguration AddDeviceTemplate<TBuilder, TOptions, TType>(Action<TBuilder> action)
        where TBuilder : IDeviceTemplateBuilder
        where TOptions : CoreConfigurationOptions
        where TType : class, IDevice
    {
        _signalProcessorTemplates.Add(configuration =>
        {
            var builder = _serviceProvider.GetRequiredService<TBuilder>();
            builder.SetType<TType>();
            action(builder);
            builder.Build(configuration.SignalProcessorTemplates.Create<IDeviceTemplate>());
        });
        return this;
    }
}
