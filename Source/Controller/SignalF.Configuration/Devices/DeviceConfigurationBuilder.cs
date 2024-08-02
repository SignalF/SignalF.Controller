using SignalF.Configuration.SignalConfiguration;
using SignalF.Controller;
using SignalF.Controller.Configuration;
using SignalF.Datamodel.Hardware;

namespace SignalF.Configuration.Devices;

public class DeviceConfigurationBuilder
    : DeviceConfigurationBuilder<DeviceConfigurationBuilder, IDeviceConfigurationBuilder, IDeviceConfiguration, SignalFConfigurationOptions>,
      IDeviceConfigurationBuilder
{
    protected override IDeviceConfigurationBuilder This => this;
}

public abstract class DeviceConfigurationBuilder<TImpl, TBuilder, TConfiguration, TOptions>
    : SignalProcessorConfigurationBuilder<TImpl, TBuilder, TConfiguration, TOptions>, IDeviceConfigurationBuilder<TBuilder, TConfiguration, TOptions>
    where TBuilder : IDeviceConfigurationBuilder<TBuilder, TConfiguration, TOptions>
    where TImpl : DeviceConfigurationBuilder<TImpl, TBuilder, TConfiguration, TOptions>
    where TConfiguration : IDeviceConfiguration
    where TOptions : SignalFConfigurationOptions
{
}
