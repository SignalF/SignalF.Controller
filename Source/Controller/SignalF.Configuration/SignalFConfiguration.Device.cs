using Microsoft.Extensions.DependencyInjection;
using SignalF.Configuration.Devices;
using SignalF.Controller.Signals.Devices;
using SignalF.Datamodel.Hardware;

namespace SignalF.Configuration;

public partial class SignalFConfiguration : ISignalFConfiguration
{
    public ISignalFConfiguration AddDeviceConfiguration<TBuilder, TOptions>(Action<TBuilder> action)
        where TBuilder : IDeviceConfigurationBuilder<TBuilder, IDeviceConfiguration, TOptions>
        where TOptions : DeviceOptions
    {
        _signalProcessorConfigurations.Add(configuration =>
        {
            var builder = _serviceProvider.GetRequiredService<TBuilder>();
            action(builder);
            builder.Build(configuration.SignalProcessorConfigurations.Create<IDeviceConfiguration>());
        });
        return this;
    }

    public ISignalFConfiguration AddDeviceConfiguration<TBuilder, TOptions, TType>(Action<TBuilder> action)
        where TBuilder : IDeviceConfigurationBuilder<TBuilder, IDeviceConfiguration, TOptions>
        where TOptions : DeviceOptions
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

    public ISignalFConfiguration AddDeviceDefinition<TBuilder, TOptions>(Action<TBuilder> action)
        where TBuilder : IDeviceDefinitionBuilder<TBuilder, IDeviceDefinition, TOptions>
        where TOptions : DeviceOptions
    {
        _signalProcessorDefinitions.Add(configuration =>
        {
            var builder = _serviceProvider.GetRequiredService<TBuilder>();
            action(builder);
            builder.Build(configuration.SignalProcessorDefinitions.Create<IDeviceDefinition>());
        });
        return this;
    }

    public ISignalFConfiguration AddDeviceDefinition<TBuilder, TOptions, TType>(Action<TBuilder> action)
        where TBuilder : IDeviceDefinitionBuilder<TBuilder, IDeviceDefinition, TOptions>
        where TOptions : DeviceOptions
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

    public ISignalFConfiguration AddDeviceTemplate<TBuilder, TOptions>(Action<TBuilder> action)
        where TBuilder : IDeviceTemplateBuilder<TBuilder, IDeviceTemplate, TOptions>
        where TOptions : DeviceOptions
    {
        _signalProcessorTemplates.Add(configuration =>
        {
            var builder = _serviceProvider.GetRequiredService<TBuilder>();
            action(builder);
            builder.Build(configuration.SignalProcessorTemplates.Create<IDeviceTemplate>());
        });
        return this;
    }

    public ISignalFConfiguration AddDeviceTemplate<TBuilder, TOptions, TType>(Action<TBuilder> action)
        where TBuilder : IDeviceTemplateBuilder<TBuilder, IDeviceTemplate, TOptions>
        where TOptions : DeviceOptions
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
