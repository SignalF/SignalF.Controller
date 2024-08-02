using SignalF.Configuration.SignalConfiguration;
using SignalF.Controller;
using SignalF.Controller.Configuration;
using SignalF.Datamodel.Hardware;

namespace SignalF.Configuration.Devices;

public class DeviceDefinitionBuilder
    : DeviceDefinitionBuilder<DeviceDefinitionBuilder, IDeviceDefinitionBuilder, IDeviceDefinition, SignalFConfigurationOptions>,
      IDeviceDefinitionBuilder
{
    protected override IDeviceDefinitionBuilder This => this;
}

public abstract class DeviceDefinitionBuilder<TImpl, TBuilder, TConfiguration, TOptions>
    : SignalProcessorDefinitionBuilder<TImpl, TBuilder, TConfiguration, TOptions>, IDeviceDefinitionBuilder<TBuilder, TConfiguration, TOptions>
    where TBuilder : IDeviceDefinitionBuilder<TBuilder, TConfiguration, TOptions>
    where TImpl : DeviceDefinitionBuilder<TImpl, TBuilder, TConfiguration, TOptions>
    where TConfiguration : IDeviceDefinition
    where TOptions : SignalFConfigurationOptions
{
}
