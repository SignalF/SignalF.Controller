using SignalF.Configuration.SignalConfiguration;
using SignalF.Controller;
using SignalF.Controller.Configuration;
using SignalF.Datamodel.Hardware;

namespace SignalF.Configuration.Devices;

public class DeviceTemplateBuilder
    : DeviceTemplateBuilder<DeviceTemplateBuilder, IDeviceTemplateBuilder, IDeviceTemplate, SignalFConfigurationOptions>,
      IDeviceTemplateBuilder
{
    protected override IDeviceTemplateBuilder This => this;
}

public abstract class DeviceTemplateBuilder<TImpl, TBuilder, TConfiguration, TOptions>
    : SignalProcessorTemplateBuilder<TImpl, TBuilder, TConfiguration, TOptions>, IDeviceTemplateBuilder<TBuilder, TConfiguration, TOptions>
    where TBuilder : IDeviceTemplateBuilder<TBuilder, TConfiguration, TOptions>
    where TImpl : DeviceTemplateBuilder<TImpl, TBuilder, TConfiguration, TOptions>
    where TConfiguration : IDeviceTemplate
    where TOptions : SignalFConfigurationOptions
{
}
