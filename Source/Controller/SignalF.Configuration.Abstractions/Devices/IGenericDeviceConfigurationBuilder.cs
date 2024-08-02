using SignalF.Datamodel.Devices;

namespace SignalF.Configuration.Devices;

public interface IGenericDeviceConfigurationBuilder : IGenericDeviceConfigurationBuilder<IGenericDeviceConfigurationBuilder, IGenericDeviceConfiguration,
    GenericDeviceOptions>
{
}

public interface
    IGenericDeviceConfigurationBuilder<out TBuilder, in TConfiguration, in TOptions> : IDeviceConfigurationBuilder<TBuilder, TConfiguration, TOptions>
    where TBuilder : IGenericDeviceConfigurationBuilder<TBuilder, TConfiguration, TOptions>
    where TConfiguration : IGenericDeviceConfiguration
    where TOptions : GenericDeviceOptions
{
}
