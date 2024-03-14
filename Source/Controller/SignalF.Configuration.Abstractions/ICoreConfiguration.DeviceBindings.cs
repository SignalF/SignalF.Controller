using System;
using SignalF.Configuration.Hardware;
using SignalF.Controller.Configuration;
using SignalF.Controller.Hardware.DeviceBindings;
using SignalF.Datamodel.Hardware;

namespace SignalF.Configuration;

public partial interface ICoreConfiguration
{
    //ICoreConfiguration AddDeviceBinding(Action<IDeviceBindingBuilder> builder);

    ICoreConfiguration AddDeviceBinding<TBuilder, TConfiguration, TOptions>(Action<TBuilder> builder)
        where TBuilder : IDeviceBindingBuilder<TBuilder, TConfiguration, TOptions>
        where TConfiguration : IDeviceBindingConfiguration
        where TOptions : CoreConfigurationOptions;

    ICoreConfiguration AddDeviceBinding<TBuilder, TConfiguration, TOptions, TType>(Action<TBuilder> builder)
        where TBuilder : IDeviceBindingBuilder<TBuilder, TConfiguration, TOptions>
        where TConfiguration : IDeviceBindingConfiguration
        where TOptions : CoreConfigurationOptions
        where TType : class, IDeviceBinding;
}
