using SignalF.Configuration.Hardware;
using SignalF.Controller;
using SignalF.Controller.Configuration;
using SignalF.Controller.Hardware.DeviceBindings;
using SignalF.Datamodel.Hardware;

namespace SignalF.Configuration;

public partial interface ISignalFConfiguration
{
    //ICoreConfiguration AddDeviceBinding(Action<IDeviceBindingBuilder> builder);

    ISignalFConfiguration AddDeviceBinding<TBuilder, TConfiguration, TOptions>(Action<TBuilder> builder)
        where TBuilder : IDeviceBindingBuilder<TBuilder, TConfiguration, TOptions>
        where TConfiguration : IDeviceBindingConfiguration
        where TOptions : DeviceOptions;

    ISignalFConfiguration AddDeviceBinding<TBuilder, TConfiguration, TOptions, TType>(Action<TBuilder> builder)
        where TBuilder : IDeviceBindingBuilder<TBuilder, TConfiguration, TOptions>
        where TConfiguration : IDeviceBindingConfiguration
        where TOptions : SignalFConfigurationOptions
        where TType : class, IDeviceBinding;
}
