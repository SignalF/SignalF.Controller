using Microsoft.Extensions.DependencyInjection;
using SignalF.Configuration.Devices;
using SignalF.Configuration.Devices.Gpio;
using SignalF.Controller;
using SignalF.Controller.Configuration;
using SignalF.Controller.Signals.Devices;
using SignalF.Datamodel.DataOutput;
using SignalF.Datamodel.Devices;

namespace SignalF.Configuration;

public partial class SignalFConfiguration : ISignalFConfiguration
{
    public ISignalFConfiguration AddGenericDeviceConfiguration<TBuilder, TOptions>(Action<TBuilder> action)
        where TBuilder : IGenericDeviceConfigurationBuilder<TBuilder, IGenericDeviceConfiguration, TOptions>
        where TOptions : GenericDeviceOptions
    {
        _signalProcessorConfigurations.Add(configuration =>
        {
            var builder = _serviceProvider.GetRequiredService<TBuilder>();
            action(builder);
            builder.Build(configuration.SignalProcessorConfigurations.Create<IGenericDeviceConfiguration>());
        });
        return this;
    }

    public ISignalFConfiguration AddGenericDeviceConfiguration<TBuilder, TOptions, TType>(Action<TBuilder> action)
        where TBuilder : IGenericDeviceConfigurationBuilder<TBuilder, IGenericDeviceConfiguration, TOptions>
        where TOptions : GenericDeviceOptions
        where TType : class, IGenericDevice
    {
        _signalProcessorConfigurations.Add(configuration =>
        {
            var builder = _serviceProvider.GetRequiredService<TBuilder>();
            builder.SetType<TType>();
            action(builder);
            builder.Build(configuration.SignalProcessorConfigurations.Create<IGenericDeviceConfiguration>());
        });
        return this;
    }

    public ISignalFConfiguration AddGenericDeviceDefinition<TBuilder, TOptions>(Action<TBuilder> action)
        where TBuilder : IGenericDeviceDefinitionBuilder<TBuilder, IGenericDeviceDefinition, TOptions>
        where TOptions : GenericDeviceOptions
    {
        _signalProcessorDefinitions.Add(configuration =>
        {
            var builder = _serviceProvider.GetRequiredService<TBuilder>();
            action(builder);
            builder.Build(configuration.SignalProcessorDefinitions.Create<IGenericDeviceDefinition>());
        });
        return this;
    }

    public ISignalFConfiguration AddGenericDeviceDefinition<TBuilder, TOptions, TType>(Action<TBuilder> action)
        where TBuilder : IGenericDeviceDefinitionBuilder<TBuilder, IGenericDeviceDefinition, TOptions>
        where TOptions : GenericDeviceOptions
        where TType : class, IGenericDevice
    {
        _signalProcessorDefinitions.Add(configuration =>
        {
            var builder = _serviceProvider.GetRequiredService<TBuilder>();
            builder.SetType<TType>();
            action(builder);
            builder.Build(configuration.SignalProcessorDefinitions.Create<IGenericDeviceDefinition>());
        });
        return this;
    }

    public ISignalFConfiguration AddGenericDeviceTemplate<TBuilder, TOptions>(Action<TBuilder> action)
        where TBuilder : IGenericDeviceTemplateBuilder<TBuilder, IGenericDeviceTemplate, TOptions>
        where TOptions : SignalFConfigurationOptions
    {
        _signalProcessorTemplates.Add(configuration =>
        {
            var builder = _serviceProvider.GetRequiredService<TBuilder>();
            action(builder);
            builder.Build(configuration.SignalProcessorTemplates.Create<IGenericDeviceTemplate>());
        });
        return this;
    }

    public ISignalFConfiguration AddGenericDeviceTemplate<TBuilder, TOptions, TType>(Action<TBuilder> action)
        where TBuilder : IGenericDeviceTemplateBuilder<TBuilder, IGenericDeviceTemplate, TOptions>
        where TOptions : SignalFConfigurationOptions
        where TType : class, IGenericDevice
    {
        _signalProcessorTemplates.Add(configuration =>
        {
            var builder = _serviceProvider.GetRequiredService<TBuilder>();
            builder.SetType<TType>();
            action(builder);
            builder.Build(configuration.SignalProcessorTemplates.Create<IGenericDeviceTemplate>());
        });
        return this;
    }
}
