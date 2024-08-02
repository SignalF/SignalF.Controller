using SignalF.Configuration.Devices;
using SignalF.Controller;
using SignalF.Controller.Configuration;
using SignalF.Datamodel.Hardware;

namespace SignalF.Configuration.Hardware;

public interface IDeviceBindingBuilder
    : IDeviceBindingBuilder<IDeviceBindingBuilder, IDeviceBindingConfiguration, DeviceOptions>
{
}

public interface IDeviceBindingBuilder<out TBuilder, in TConfiguration>
    : IDeviceBindingBuilder<TBuilder, TConfiguration, DeviceOptions>
    where TBuilder : IDeviceBindingBuilder<TBuilder, TConfiguration, DeviceOptions>
    where TConfiguration : IDeviceBindingConfiguration
{
}

public interface IDeviceBindingBuilder<out TBuilder, in TConfiguration, in TOptions>
    : ISignalFConfigurationBuilder<TBuilder, TConfiguration, TOptions>
    where TBuilder : IDeviceBindingBuilder<TBuilder, TConfiguration, TOptions>
    where TConfiguration : IDeviceBindingConfiguration
    where TOptions : DeviceOptions
{
}
