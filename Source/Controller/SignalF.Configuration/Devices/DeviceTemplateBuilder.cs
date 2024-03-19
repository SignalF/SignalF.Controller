using SignalF.Configuration.SignalConfiguration;
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
    public override void Build(TConfiguration configuration)
    {
        base.Build(configuration);
    }
}

//public class DeviceTemplate
//    : DeviceTemplate<DeviceTemplate, Datamodel.Hardware.IDeviceTemplate, IDeviceTemplate>
//      , IDeviceTemplate
//{
//    protected override IDeviceTemplate This => this;
//}

//public abstract class DeviceTemplate<TElement, TConfigElement, TInterface>
//    : SignalProcessorTemplate<TElement, TConfigElement, TInterface>
//      , IDeviceTemplate<TInterface>
//    where TInterface : IDeviceTemplate<TInterface>
//    where TConfigElement : Datamodel.Hardware.IDeviceTemplate
//    where TElement : DeviceTemplate<TElement, TConfigElement, TInterface>
//{
//    //protected override TConfigElement CreateConfiguration(IControllerConfiguration configuration)
//    //{
//    //    return configuration.SignalProcessorTemplates.Create<TConfigElement>();
//    //}
//}
