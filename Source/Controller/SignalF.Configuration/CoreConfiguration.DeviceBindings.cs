using Microsoft.Extensions.DependencyInjection;
using SignalF.Configuration.Hardware;
using SignalF.Controller.Configuration;
using SignalF.Controller.Hardware.DeviceBindings;
using SignalF.Datamodel.Hardware;

namespace SignalF.Configuration;

public partial class CoreConfiguration : ICoreConfiguration
{
    public ICoreConfiguration AddDeviceBinding<TBuilder, TConfiguration, TOptions>(Action<TBuilder> builder)
        where TBuilder : IDeviceBindingBuilder<TBuilder, TConfiguration, TOptions>
        where TConfiguration : IDeviceBindingConfiguration
        where TOptions : CoreConfigurationOptions
    {
        _deviceBindings.Add(configuration =>
        {
            var configurationBuilder = _serviceProvider.GetRequiredService<TBuilder>();
            builder(configurationBuilder);
            configurationBuilder.Build(configuration.DeviceBindings.Create<TConfiguration>());
        });
        return this;
    }

    public ICoreConfiguration AddDeviceBinding<TBuilder, TConfiguration, TOptions, TType>(Action<TBuilder> builder)
        where TBuilder : IDeviceBindingBuilder<TBuilder, TConfiguration, TOptions>
        where TConfiguration : IDeviceBindingConfiguration
        where TOptions : CoreConfigurationOptions
        where TType : class, IDeviceBinding
    {
        _deviceBindings.Add(configuration =>
        {
            var configurationBuilder = _serviceProvider.GetRequiredService<TBuilder>();
            configurationBuilder.SetType<TType>();
            builder(configurationBuilder);
            configurationBuilder.Build(configuration.DeviceBindings.Create<TConfiguration>());
        });
        return this;
    }
}
