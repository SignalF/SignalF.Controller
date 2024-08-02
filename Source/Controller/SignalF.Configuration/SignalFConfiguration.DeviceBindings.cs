using Microsoft.Extensions.DependencyInjection;
using SignalF.Configuration.Hardware;
using SignalF.Controller.Hardware.DeviceBindings;
using SignalF.Datamodel.Hardware;

namespace SignalF.Configuration;

public partial class SignalFConfiguration : ISignalFConfiguration
{
    public ISignalFConfiguration AddDeviceBinding<TBuilder, TConfiguration, TOptions>(Action<TBuilder> builder)
        where TBuilder : IDeviceBindingBuilder<TBuilder, TConfiguration, TOptions>
        where TConfiguration : IDeviceBindingConfiguration
        where TOptions : DeviceBindingOptions
    {
        _deviceBindings.Add(configuration =>
        {
            var configurationBuilder = _serviceProvider.GetRequiredService<TBuilder>();
            builder(configurationBuilder);
            configurationBuilder.Build(configuration.DeviceBindings.Create<TConfiguration>());
        });
        return this;
    }

    public ISignalFConfiguration AddDeviceBinding<TBuilder, TConfiguration, TOptions, TType>(Action<TBuilder> builder)
        where TBuilder : IDeviceBindingBuilder<TBuilder, TConfiguration, TOptions>
        where TConfiguration : IDeviceBindingConfiguration
        where TOptions : DeviceBindingOptions
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
