using SignalF.Configuration.SignalConfiguration;
using SignalF.Controller.Configuration;
using SignalF.Datamodel.Hardware;

namespace SignalF.Configuration.Devices;

public interface IDeviceConfigurationBuilder : IDeviceConfigurationBuilder<IDeviceConfigurationBuilder, IDeviceConfiguration, CoreConfigurationOptions>
{
}

public interface
    IDeviceConfigurationBuilder<out TBuilder, in TConfiguration, in TOptions> : ISignalProcessorConfigurationBuilder<TBuilder, TConfiguration, TOptions>
    where TBuilder : IDeviceConfigurationBuilder<TBuilder, TConfiguration, TOptions>
    where TConfiguration : IDeviceConfiguration
    where TOptions : CoreConfigurationOptions
{
}
