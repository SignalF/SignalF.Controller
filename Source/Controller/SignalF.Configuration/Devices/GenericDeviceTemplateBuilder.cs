using SignalF.Controller.Configuration;
using SignalF.Datamodel.Devices;

namespace SignalF.Configuration.Devices;

public class GenericDeviceTemplateBuilder
    : GenericDeviceTemplateBuilder<GenericDeviceTemplateBuilder, IGenericDeviceTemplateBuilder, IGenericDeviceTemplate, SignalFConfigurationOptions>,
      IGenericDeviceTemplateBuilder
{
    protected override IGenericDeviceTemplateBuilder This => this;
}

public abstract class GenericDeviceTemplateBuilder<TImpl, TBuilder, TConfiguration, TOptions>
    : DeviceTemplateBuilder<TImpl, TBuilder, TConfiguration, TOptions>, IGenericDeviceTemplateBuilder<TBuilder, TConfiguration, TOptions>
    where TBuilder : IGenericDeviceTemplateBuilder<TBuilder, TConfiguration, TOptions>
    where TImpl : GenericDeviceTemplateBuilder<TImpl, TBuilder, TConfiguration, TOptions>
    where TConfiguration : IGenericDeviceTemplate
    where TOptions : SignalFConfigurationOptions
{
}
