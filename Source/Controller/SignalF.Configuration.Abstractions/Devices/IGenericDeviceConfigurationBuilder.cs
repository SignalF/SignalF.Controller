using SignalF.Controller.Configuration;
using SignalF.Datamodel.Devices;

namespace SignalF.Configuration.Devices;

public interface IGenericDeviceConfigurationBuilder : IGenericDeviceConfigurationBuilder<IGenericDeviceConfigurationBuilder, IGenericDeviceConfiguration,
    SignalFConfigurationOptions>
{
}

public interface
    IGenericDeviceConfigurationBuilder<out TBuilder, in TConfiguration, in TOptions> : IDeviceConfigurationBuilder<TBuilder, TConfiguration, TOptions>
    where TBuilder : IGenericDeviceConfigurationBuilder<TBuilder, TConfiguration, TOptions>
    where TConfiguration : IGenericDeviceConfiguration
    where TOptions : SignalFConfigurationOptions
{
}
