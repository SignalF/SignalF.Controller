using SignalF.Controller.Configuration;
using SignalF.Datamodel.Devices;

namespace SignalF.Configuration.Devices;

public class GenericDeviceTemplateBuilder
    : GenericDeviceTemplateBuilder<GenericDeviceTemplateBuilder, IGenericDeviceTemplateBuilder, IGenericDeviceTemplate, CoreConfigurationOptions>,
      IGenericDeviceTemplateBuilder
{
    protected override IGenericDeviceTemplateBuilder This => this;
}

public abstract class GenericDeviceTemplateBuilder<TImpl, TBuilder, TConfiguration, TOptions>
    : DeviceTemplateBuilder<TImpl, TBuilder, TConfiguration, TOptions>, IGenericDeviceTemplateBuilder<TBuilder, TConfiguration, TOptions>
    where TBuilder : IGenericDeviceTemplateBuilder<TBuilder, TConfiguration, TOptions>
    where TImpl : GenericDeviceTemplateBuilder<TImpl, TBuilder, TConfiguration, TOptions>
    where TConfiguration : IGenericDeviceTemplate
    where TOptions : CoreConfigurationOptions
{
    public override void Build(TConfiguration configuration)
    {
        base.Build(configuration);
    }
}

//public class GenericGenericDeviceTemplateBuilder
//    : GenericGenericDeviceTemplate<GenericGenericDeviceTemplateBuilder, Datamodel.GenericDevices.IGenericGenericDeviceTemplate, IGenericGenericDeviceTemplate>
//      , IGenericGenericDeviceTemplate
//{
//    protected override IGenericGenericDeviceTemplate This => this;
//}

//public abstract class GenericGenericDeviceTemplate<TElement, TConfigElement, TInterface>
//    : GenericDeviceTemplate<TElement, TConfigElement, TInterface>
//      , IGenericGenericDeviceTemplate<TInterface>
//    where TInterface : IGenericGenericDeviceTemplate<TInterface>
//    where TConfigElement : Datamodel.GenericDevices.IGenericGenericDeviceTemplate
//    where TElement : GenericGenericDeviceTemplate<TElement, TConfigElement, TInterface>
//{
//    //protected override TConfigElement CreateConfiguration(IControllerConfiguration configuration)
//    //{
//    //    return configuration.SignalProcessorTemplates.Create<TConfigElement>();
//    //}
//}
