using SignalF.Controller.Configuration;
using SignalF.Datamodel.Devices;

namespace SignalF.Configuration.Devices;

public class GenericDeviceDefinitionBuilder
    : GenericDeviceDefinitionBuilder<GenericDeviceDefinitionBuilder, IGenericDeviceDefinitionBuilder, IGenericDeviceDefinition, SignalFConfigurationOptions>,
      IGenericDeviceDefinitionBuilder
{
    protected override IGenericDeviceDefinitionBuilder This => this;
}

public abstract class GenericDeviceDefinitionBuilder<TImpl, TBuilder, TConfiguration, TOptions>
    : DeviceDefinitionBuilder<TImpl, TBuilder, TConfiguration, TOptions>, IGenericDeviceDefinitionBuilder<TBuilder, TConfiguration, TOptions>
    where TBuilder : IGenericDeviceDefinitionBuilder<TBuilder, TConfiguration, TOptions>
    where TImpl : GenericDeviceDefinitionBuilder<TImpl, TBuilder, TConfiguration, TOptions>
    where TConfiguration : IGenericDeviceDefinition
    where TOptions : SignalFConfigurationOptions
{
    public override void Build(TConfiguration configuration)
    {
        base.Build(configuration);
    }
}

//public class GenericGenericDeviceDefinition
//    : GenericGenericDeviceDefinition<GenericGenericDeviceDefinition, Datamodel.GenericDevices.IGenericGenericDeviceDefinition, IGenericGenericDeviceDefinition>
//      , IGenericGenericDeviceDefinition
//{
//    protected override IGenericGenericDeviceDefinition This => this;
//}

//public abstract class GenericGenericDeviceDefinition<TElement, TConfigElement, TInterface>
//    : GenericDeviceDefinition<TElement, TConfigElement, TInterface>
//      , IGenericGenericDeviceDefinition<TInterface>
//    where TInterface : IGenericGenericDeviceDefinition<TInterface>
//    where TConfigElement : Datamodel.GenericDevices.IGenericGenericDeviceDefinition
//    where TElement : GenericGenericDeviceDefinition<TElement, TConfigElement, TInterface>
//{
//    //protected override TConfigElement CreateConfiguration(IControllerConfiguration configuration)
//    //{
//    //    return configuration.SignalProcessorDefinitions.Create<TConfigElement>();
//    //}
//}
