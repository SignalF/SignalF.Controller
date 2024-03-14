using SignalF.Controller.Configuration;
using SignalF.Datamodel.Hardware;

namespace SignalF.Configuration.Hardware;

public interface IDeviceBindingBuilder
    : IDeviceBindingBuilder<IDeviceBindingBuilder, IDeviceBindingConfiguration, CoreConfigurationOptions>
{
}

public interface IDeviceBindingBuilder<out TBuilder, in TConfiguration>
    : IDeviceBindingBuilder<TBuilder, TConfiguration, CoreConfigurationOptions>
    where TBuilder : IDeviceBindingBuilder<TBuilder, TConfiguration, CoreConfigurationOptions>
    where TConfiguration : IDeviceBindingConfiguration
{
}

public interface IDeviceBindingBuilder<out TBuilder, in TConfiguration, in TOptions>
    : ICoreConfigurationBuilder<TBuilder, TConfiguration, TOptions>
    where TBuilder : IDeviceBindingBuilder<TBuilder, TConfiguration, TOptions>
    where TConfiguration : IDeviceBindingConfiguration
    where TOptions : CoreConfigurationOptions
{
}
