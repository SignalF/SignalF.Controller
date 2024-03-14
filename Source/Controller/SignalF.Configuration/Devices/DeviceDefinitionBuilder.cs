using SignalF.Configuration.SignalConfiguration;
using SignalF.Controller.Configuration;
using SignalF.Datamodel.Hardware;

namespace SignalF.Configuration.Devices;

public class DeviceDefinitionBuilder
    : DeviceDefinitionBuilder<DeviceDefinitionBuilder, IDeviceDefinitionBuilder, IDeviceDefinition, CoreConfigurationOptions>,
      IDeviceDefinitionBuilder
{
    protected override IDeviceDefinitionBuilder This => this;
}

public abstract class DeviceDefinitionBuilder<TImpl, TBuilder, TConfiguration, TOptions>
    : SignalProcessorDefinitionBuilder<TImpl, TBuilder, TConfiguration, TOptions>, IDeviceDefinitionBuilder<TBuilder, TConfiguration, TOptions>
    where TBuilder : IDeviceDefinitionBuilder<TBuilder, TConfiguration, TOptions>
    where TImpl : DeviceDefinitionBuilder<TImpl, TBuilder, TConfiguration, TOptions>
    where TConfiguration : IDeviceDefinition
    where TOptions : CoreConfigurationOptions
{
    public override void Build(TConfiguration configuration)
    {
        base.Build(configuration);
    }
}

//public class DeviceDefinition
//    : DeviceDefinition<DeviceDefinition, Datamodel.Hardware.IDeviceDefinition, IDeviceDefinition>
//      , IDeviceDefinition
//{
//    protected override IDeviceDefinition This => this;
//}

//public abstract class DeviceDefinition<TElement, TConfigElement, TInterface>
//    : SignalProcessorDefinition<TElement, TConfigElement, TInterface>
//      , IDeviceDefinition<TInterface>
//    where TInterface : IDeviceDefinition<TInterface>
//    where TConfigElement : Datamodel.Hardware.IDeviceDefinition
//    where TElement : DeviceDefinition<TElement, TConfigElement, TInterface>
//{
//    //protected override TConfigElement CreateConfiguration(IControllerConfiguration configuration)
//    //{
//    //    return configuration.SignalProcessorDefinitions.Create<TConfigElement>();
//    //}
//}
