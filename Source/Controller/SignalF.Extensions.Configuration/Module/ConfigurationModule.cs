#region

using Autofac;
using SignalF.Configuration;
using SignalF.Configuration.Calculators;
using SignalF.Configuration.DataOutput;
using SignalF.Configuration.Devices;
using SignalF.Configuration.Devices.Gpio;
using SignalF.Configuration.Hardware;
using SignalF.Configuration.Hardware.Gpio;
using SignalF.Configuration.Hardware.I2c;
using SignalF.Configuration.Hardware.OneWire;
using SignalF.Configuration.Hardware.Spi;
using SignalF.Configuration.Hardware.Tcp;
using SignalF.Configuration.ProcessControl;
using SignalF.Configuration.SignalConfiguration;
using SignalF.Configuration.StaticSignalProvider;
using SignalF.Configuration.TaskConfiguration;

#endregion

namespace SignalF.Extensions.Configuration.Module;

public class ConfigurationModule : Autofac.Module
{
    protected override void Load(ContainerBuilder builder)
    {
        base.Load(builder);

        builder.RegisterType<SignalFConfiguration>()
               .As<ISignalFConfiguration>()
               .InstancePerDependency();

        builder.RegisterType<TaskConfigurationBuilder>()
               .As<ITaskConfigurationBuilder>()
               .InstancePerDependency();

        builder.RegisterType<TaskMappingBuilder>()
               .As<ITaskMappingBuilder>()
               .InstancePerDependency();

        builder.RegisterType<GpioPinAccessConfigurationBuilder>()
               .As<IGpioPinAccessConfigurationBuilder>()
               .InstancePerDependency();

        builder.RegisterType<ChannelGroupBuilder>()
               .As<IChannelGroupBuilder>()
               .InstancePerDependency();

        //builder.RegisterGeneric(typeof(ChannelGroupBuilder<,,,,,>))
        //       .As(typeof(IChannelGroupBuilder<,,,>))
        //       .InstancePerDependency();

        builder.RegisterType<GpioChannelGroupBuilder>()
               .As<IGpioChannelGroupBuilder>()
               .InstancePerDependency();

        builder.RegisterType<GpioChannelConfigurationBuilder>()
               .As<IGpioChannelConfigurationBuilder>()
               .InstancePerDependency();

        builder.RegisterType<I2cChannelGroupBuilder>()
               .As<II2cChannelGroupBuilder>()
               .InstancePerDependency();

        builder.RegisterType<I2CChannelConfigurationBuilder>()
               .As<II2CChannelConfigurationBuilder>()
               .InstancePerDependency();

        builder.RegisterType<SpiChannelGroupBuilder>()
               .As<ISpiChannelGroupBuilder>()
               .InstancePerDependency();

        builder.RegisterType<SpiChannelConfigurationBuilder>()
               .As<ISpiChannelConfigurationBuilder>()
               .InstancePerDependency();

        builder.RegisterType<OneWireChannelGroupBuilder>()
               .As<IOneWireChannelGroupBuilder>()
               .InstancePerDependency();

        builder.RegisterType<OneWireChannelConfigurationBuilder>()
               .As<IOneWireChannelConfigurationBuilder>()
               .InstancePerDependency();

        builder.RegisterType<TcpChannelGroupBuilder>()
               .As<ITcpChannelGroupBuilder>()
               .InstancePerDependency();

        builder.RegisterType<TcpChannelConfigurationBuilder>()
               .As<ITcpChannelConfigurationBuilder>()
               .InstancePerDependency();

        builder.RegisterType<SignalProcessorConfigurationBuilder>()
               .As<ISignalProcessorConfigurationBuilder>()
               .InstancePerDependency();

        builder.RegisterType<SignalProcessorDefinitionBuilder>()
               .As<ISignalProcessorDefinitionBuilder>()
               .InstancePerDependency();

        builder.RegisterType<SignalProcessorTemplateBuilder>()
               .As<ISignalProcessorTemplateBuilder>()
               .InstancePerDependency();

        builder.RegisterType<CalculatorConfigurationBuilder>()
               .As<ICalculatorConfigurationBuilder>()
               .InstancePerDependency();

        builder.RegisterType<CalculatorDefinitionBuilder>()
               .As<ICalculatorDefinitionBuilder>()
               .InstancePerDependency();

        builder.RegisterType<CalculatorTemplateBuilder>()
               .As<ICalculatorTemplateBuilder>()
               .InstancePerDependency();

        builder.RegisterType<ProcessControlConfigurationBuilder>()
               .As<IProcessControlConfigurationBuilder>()
               .InstancePerDependency();

        builder.RegisterType<ProcessControlDefinitionBuilder>()
               .As<IProcessControlDefinitionBuilder>()
               .InstancePerDependency();

        builder.RegisterType<ProcessControlTemplateBuilder>()
               .As<IProcessControlTemplateBuilder>()
               .InstancePerDependency();

        builder.RegisterType<GpioPinAccessTemplateBuilder>()
               .As<IGpioPinAccessTemplateBuilder>()
               .InstancePerDependency();

        builder.RegisterType<GpioPinAccessDefinitionBuilder>()
               .As<IGpioPinAccessDefinitionBuilder>()
               .InstancePerDependency();

        builder.RegisterType<GpioPinAccessConfigurationBuilder>()
               .As<IGpioPinAccessConfigurationBuilder>()
               .InstancePerDependency();

        builder.RegisterType<StaticSignalProviderConfigurationBuilder>()
               .As<IStaticSignalProviderConfigurationBuilder>()
               .InstancePerDependency();

        builder.RegisterType<StaticSignalProviderDefinitionBuilder>()
               .As<IStaticSignalProviderDefinitionBuilder>()
               .InstancePerDependency();

        builder.RegisterType<StaticSignalProviderTemplateBuilder>()
               .As<IStaticSignalProviderTemplateBuilder>()
               .InstancePerDependency();

        builder.RegisterType<DeviceConfigurationBuilder>()
               .As<IDeviceConfigurationBuilder>()
               .InstancePerDependency();

        builder.RegisterType<DeviceDefinitionBuilder>()
               .As<IDeviceDefinitionBuilder>()
               .InstancePerDependency();

        builder.RegisterType<DeviceTemplateBuilder>()
               .As<IDeviceTemplateBuilder>()
               .InstancePerDependency();

        builder.RegisterType<GenericDeviceConfigurationBuilder>()
               .As<IGenericDeviceConfigurationBuilder>()
               .InstancePerDependency();

        builder.RegisterType<GenericDeviceDefinitionBuilder>()
               .As<IGenericDeviceDefinitionBuilder>()
               .InstancePerDependency();

        builder.RegisterType<GenericDeviceTemplateBuilder>()
               .As<IGenericDeviceTemplateBuilder>()
               .InstancePerDependency();

        builder.RegisterType<DataOutputConfigurationBuilder>()
               .As<IDataOutputConfigurationBuilder>()
               .InstancePerDependency();

        builder.RegisterType<DataOutputSenderConfigurationBuilder>()
               .As<IDataOutputSenderConfigurationBuilder>()
               .InstancePerDependency();

        builder.RegisterType<ChannelToSignalEndpointMappingBuilder>()
               .As<IChannelToSignalEndpointMappingBuilder>()
               .InstancePerDependency();

        builder.RegisterType<ChannelToDeviceMappingBuilder>()
               .As<IChannelToDeviceMappingBuilder>()
               .InstancePerDependency();

        builder.RegisterType<DeviceBindingBuilder>()
               .As<IDeviceBindingBuilder>()
               .InstancePerDependency();

        builder.RegisterType<GpioDeviceBindingBuilder>()
               .As<IGpioDeviceBindingBuilder>()
               .InstancePerDependency();

        builder.RegisterType<SpiDeviceBindingBuilder>()
               .As<ISpiDeviceBindingBuilder>()
               .InstancePerDependency();

        builder.RegisterType<I2cDeviceBindingBuilder>()
               .As<II2cDeviceBindingBuilder>()
               .InstancePerDependency();

        builder.RegisterType<TcpDeviceBindingBuilder>()
               .As<ITcpDeviceBindingBuilder>()
               .InstancePerDependency();

        builder.RegisterType<OneWireDeviceBindingBuilder>()
               .As<IOneWireDeviceBindingBuilder>()
               .InstancePerDependency();
    }
}
