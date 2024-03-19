using SignalF.Controller.Configuration;
using SignalF.Datamodel.Devices;

namespace SignalF.Configuration.Devices;

public class GenericDeviceConfigurationBuilder
    : GenericDeviceConfigurationBuilder<GenericDeviceConfigurationBuilder, IGenericDeviceConfigurationBuilder, IGenericDeviceConfiguration,
          SignalFConfigurationOptions>, IGenericDeviceConfigurationBuilder
{
    protected override IGenericDeviceConfigurationBuilder This => this;
}

public abstract class GenericDeviceConfigurationBuilder<TImpl, TBuilder, TConfiguration, TOptions>
    : DeviceConfigurationBuilder<TImpl, TBuilder, TConfiguration, TOptions>, IGenericDeviceConfigurationBuilder<TBuilder, TConfiguration, TOptions>
    where TBuilder : IGenericDeviceConfigurationBuilder<TBuilder, TConfiguration, TOptions>
    where TImpl : GenericDeviceConfigurationBuilder<TImpl, TBuilder, TConfiguration, TOptions>
    where TConfiguration : IGenericDeviceConfiguration
    where TOptions : SignalFConfigurationOptions
{
    public override void Build(TConfiguration configuration)
    {
        base.Build(configuration);
    }
}

//public class GenericGenericDeviceConfiguration
//    : GenericGenericDeviceConfiguration<GenericGenericDeviceConfiguration, Datamodel.GenericDevices.IGenericGenericDeviceConfiguration, IGenericGenericDeviceConfiguration>
//      , IGenericGenericDeviceConfiguration
//{
//    protected override IGenericGenericDeviceConfiguration This => this;
//}

//public abstract class GenericGenericDeviceConfiguration<TElement, TConfigElement, TInterface>
//    : GenericDeviceConfiguration<TElement, TConfigElement, TInterface>
//      , IGenericGenericDeviceConfiguration<TInterface>
//    where TInterface : IGenericGenericDeviceConfiguration<TInterface>
//    where TConfigElement : Datamodel.GenericDevices.IGenericGenericDeviceConfiguration
//    where TElement : GenericGenericDeviceConfiguration<TElement, TConfigElement, TInterface>
//{
//    //protected override TConfigElement CreateConfiguration(IControllerConfiguration configuration)
//    //{
//    //}
//}
