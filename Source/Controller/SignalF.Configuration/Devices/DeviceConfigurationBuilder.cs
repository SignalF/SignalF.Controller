using SignalF.Configuration.SignalConfiguration;
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
    public override void Build(TConfiguration configuration)
    {
        base.Build(configuration);
    }
}

//public class DeviceConfiguration
//    : DeviceConfiguration<DeviceConfiguration, Datamodel.Hardware.IDeviceConfiguration, IDeviceConfiguration>
//      , IDeviceConfiguration
//{
//    protected override IDeviceConfiguration This => this;
//}

//public abstract class DeviceConfiguration<TElement, TConfigElement, TInterface>
//    : SignalProcessorConfiguration<TElement, TConfigElement, TInterface>
//      , IDeviceConfiguration<TInterface>
//    where TInterface : IDeviceConfiguration<TInterface>
//    where TConfigElement : Datamodel.Hardware.IDeviceConfiguration
//    where TElement : DeviceConfiguration<TElement, TConfigElement, TInterface>
//{
//    protected override TConfigElement CreateConfiguration(IControllerConfiguration configuration)
//    {
//        return configuration.SignalProcessorConfigurations.Create<TConfigElement>();
//    }
//}
