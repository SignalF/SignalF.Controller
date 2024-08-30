#region

using System.Runtime.Versioning;
using Autofac;
using SignalF.Controller;
using SignalF.Controller.Configuration;
using SignalF.Controller.DataOutput;
using SignalF.Controller.Hardware.Channels;
using SignalF.Controller.Hardware.Channels.Gpio;
using SignalF.Controller.Hardware.Channels.I2c;
using SignalF.Controller.Hardware.Channels.OneWire;
using SignalF.Controller.Hardware.Channels.Spi;
using SignalF.Controller.Hardware.Channels.Tcp;
using SignalF.Controller.Hardware.DeviceBindings;
using SignalF.Controller.Schedule;
using SignalF.Controller.Signals;
using SignalF.Controller.Signals.Devices;
using SignalF.Controller.Signals.ProcessControl;
using SignalF.Controller.Signals.SignalProcessor;
using SignalF.Controller.Timer;
using TaskScheduler = SignalF.Controller.Schedule.TaskScheduler;

#endregion

namespace SignalF.Extensions.Controller.Module;

[SupportedOSPlatform("linux")]
[SupportedOSPlatform("windows")]
public class ControllerModule : Autofac.Module
{
    protected override void Load(ContainerBuilder builder)
    {
        base.Load(builder);

        builder.RegisterType<SystemTimeTimestampProvider>()
               .As<ITimestampProvider>()
               .InstancePerDependency();

        builder.Register<Func<Type, IDeviceBinding, IChannelGroup>>(context =>
        {
            var currentContext = context.Resolve<IComponentContext>();
            return (type, binding) => (IChannelGroup)currentContext.Resolve(type, new TypedParameter(binding.GetType(), binding));
        }).InstancePerDependency();

        builder.Register<Func<Type, IChannel>>(context =>
        {
            var currentContext = context.Resolve<IComponentContext>();
            return type => (IChannel)currentContext.Resolve(type);
        }).InstancePerDependency();

        builder.RegisterType<DeviceBindingFactory>()
               .As<IDeviceBindingFactory>()
               .InstancePerLifetimeScope();

        builder.RegisterType<DeviceBindingConfigurator>()
               .As<IDeviceBindingConfigurator>()
               .InstancePerLifetimeScope();

        builder.RegisterType<ChannelGroupFactory>()
               .As<IChannelGroupFactory>()
               .InstancePerLifetimeScope();

        builder.RegisterType<ChannelGroupConfigurator>()
               .As<IChannelGroupConfigurator>()
               .InstancePerLifetimeScope();

        builder.RegisterType<SignalProcessorFactory>()
               .As<ISignalProcessorFactory>()
               .InstancePerLifetimeScope();

        builder.RegisterType<SignalProcessorConfigurator>()
               .As<ISignalProcessorConfigurator>()
               .InstancePerLifetimeScope();

        builder.RegisterType<DeviceChannelMappingConfigurator>()
               .As<IDeviceChannelMappingConfigurator>()
               .InstancePerLifetimeScope();

        builder.RegisterType<DataOutputSenderFactory>()
               .As<IDataOutputSenderFactory>()
               .InstancePerLifetimeScope();

        builder.RegisterType<DataOutputSenderConfigurator>()
               .As<IDataOutputSenderConfigurator>()
               .InstancePerLifetimeScope();

        builder.RegisterType<SignalHub>()
               .As<IService>()
               .As<ISignalHub>()
               .InstancePerLifetimeScope();

        builder.RegisterType<ScotecTimer>()
               .InstancePerLifetimeScope();

        builder.RegisterType<ProcessControlContextFactory>()
               .As<IProcessControlContextFactory>()
               .InstancePerLifetimeScope();

        builder.RegisterType<ProcessControlContext>()
               .As<IProcessControlContext>()
               .InstancePerDependency();

        builder.RegisterType<ProcessControlAdapter>()
               .As<IProcessControlAdapter>()
               .InstancePerDependency();
        builder.RegisterType<GpioPinAccess>()
               .As<IGpioPinAccess>()
               .InstancePerDependency();

        builder.RegisterType<StaticSignalProvider>()
               .As<IStaticSignalProvider>()
               .InstancePerDependency();

        builder.RegisterType<SignalFConfigurationManager>()
               .As<ISignalFConfigurationManager>()
               .InstancePerLifetimeScope();

        builder.RegisterType<TaskScheduler>()
               .As<IService>()
               .As<ITaskScheduler>()
               .InstancePerLifetimeScope();

        builder.RegisterType<TaskConfigurator>()
               .As<ITaskConfigurator>()
               .InstancePerLifetimeScope();

        builder.RegisterType<SignalDispatcher>()
               .As<IService>()
               .As<ISignalDispatcher>()
               .InstancePerLifetimeScope();

        builder.RegisterType<DeviceStartupService>()
               .As<IService>()
               .InstancePerLifetimeScope();

        builder.RegisterType<ControlInterface>()
               .As<IControlInterface>()
               .InstancePerDependency();

        builder.RegisterType<DataOutputManager>()
               .As<IDataOutputManager>()
               .InstancePerLifetimeScope();

        builder.RegisterType<DataOutput>()
               .As<IDataOutput>()
               .InstancePerDependency();

        builder.RegisterType<ProcessControlHost>()
               .As<IProcessControlHost>()
               .InstancePerDependency();

        builder.RegisterType<GpioChannelGroup>()
               .As<IGpioChannelGroup>()
               .InstancePerDependency();

        builder.RegisterType<GpioChannel>()
               .As<IGpioChannel>()
               .InstancePerDependency();

        if (Environment.OSVersion.Platform == PlatformID.Win32NT)
        {
            builder.RegisterType<GpioTestDeviceBinding>()
                   .As<IGpioDeviceBinding>()
                   .SingleInstance();
        }
        else
        {
            builder.RegisterType<GpioDeviceBinding>()
                   .As<IGpioDeviceBinding>()
                   .SingleInstance();
        }

        //builder.RegisterType<I2cChannelGroup>()
        //       .As<II2cChannelGroup>()
        //       .InstancePerDependency();

        builder.RegisterType<I2cChannel>()
               .As<II2cChannel>()
               .InstancePerDependency();

        builder.RegisterType<I2cDeviceBinding>()
               .As<II2cDeviceBinding>()
               .SingleInstance();

        builder.RegisterType<SpiChannelGroup>()
               .As<ISpiChannelGroup>()
               .As<IChannelGroup>()
               .InstancePerDependency();

        builder.RegisterType<I2cChannelGroup>()
               .As<II2cChannelGroup>()
               .As<IChannelGroup>()
               .InstancePerDependency();

        builder.RegisterType<TcpChannelGroup>()
               .As<ITcpChannelGroup>()
               .As<IChannelGroup>()
               .InstancePerDependency();

        builder.RegisterType<OneWireChannelGroup>()
               .As<IOneWireChannelGroup>()
               .As<IChannelGroup>()
               .InstancePerDependency();
    }
}
