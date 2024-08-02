using SignalF.Datamodel.Devices;

namespace SignalF.Configuration.Devices;

public class GenericDeviceConfigurationBuilder
    : GenericDeviceConfigurationBuilder<GenericDeviceConfigurationBuilder, IGenericDeviceConfigurationBuilder, IGenericDeviceConfiguration,
          GenericDeviceOptions>, IGenericDeviceConfigurationBuilder
{
    protected override IGenericDeviceConfigurationBuilder This => this;
}

public abstract class GenericDeviceConfigurationBuilder<TImpl, TBuilder, TConfiguration, TOptions>
    : DeviceConfigurationBuilder<TImpl, TBuilder, TConfiguration, TOptions>, IGenericDeviceConfigurationBuilder<TBuilder, TConfiguration, TOptions>
    where TBuilder : IGenericDeviceConfigurationBuilder<TBuilder, TConfiguration, TOptions>
    where TImpl : GenericDeviceConfigurationBuilder<TImpl, TBuilder, TConfiguration, TOptions>
    where TConfiguration : IGenericDeviceConfiguration
    where TOptions : GenericDeviceOptions
{
}
