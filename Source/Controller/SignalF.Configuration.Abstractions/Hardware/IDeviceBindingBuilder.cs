using SignalF.Controller.Configuration;
using SignalF.Datamodel.Hardware;

namespace SignalF.Configuration.Hardware;

public interface IDeviceBindingBuilder
    : IDeviceBindingBuilder<IDeviceBindingBuilder, IDeviceBindingConfiguration, SignalFConfigurationOptions>
{
}

public interface IDeviceBindingBuilder<out TBuilder, in TConfiguration>
    : IDeviceBindingBuilder<TBuilder, TConfiguration, SignalFConfigurationOptions>
    where TBuilder : IDeviceBindingBuilder<TBuilder, TConfiguration, SignalFConfigurationOptions>
    where TConfiguration : IDeviceBindingConfiguration
{
}

public interface IDeviceBindingBuilder<out TBuilder, in TConfiguration, in TOptions>
    : ISignalFConfigurationBuilder<TBuilder, TConfiguration, TOptions>
    where TBuilder : IDeviceBindingBuilder<TBuilder, TConfiguration, TOptions>
    where TConfiguration : IDeviceBindingConfiguration
    where TOptions : SignalFConfigurationOptions
{
}
