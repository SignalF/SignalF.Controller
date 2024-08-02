using SignalF.Configuration.SignalConfiguration;
using SignalF.Datamodel.Hardware;

namespace SignalF.Configuration.Devices;

public class DeviceConfigurationBuilder
    : DeviceConfigurationBuilder<DeviceConfigurationBuilder, IDeviceConfigurationBuilder, IDeviceConfiguration, DeviceOptions>,
      IDeviceConfigurationBuilder
{
    protected override IDeviceConfigurationBuilder This => this;
}

public abstract class DeviceConfigurationBuilder<TImpl, TBuilder, TConfiguration, TOptions>
    : SignalProcessorConfigurationBuilder<TImpl, TBuilder, TConfiguration, TOptions>, IDeviceConfigurationBuilder<TBuilder, TConfiguration, TOptions>
    where TBuilder : IDeviceConfigurationBuilder<TBuilder, TConfiguration, TOptions>
    where TImpl : DeviceConfigurationBuilder<TImpl, TBuilder, TConfiguration, TOptions>
    where TConfiguration : IDeviceConfiguration
    where TOptions : DeviceOptions
{
}
