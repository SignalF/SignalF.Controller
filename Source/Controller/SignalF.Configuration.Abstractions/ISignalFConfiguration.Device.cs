using SignalF.Configuration.Devices;
using SignalF.Controller.Signals.Devices;
using SignalF.Datamodel.Hardware;

namespace SignalF.Configuration;

public partial interface ISignalFConfiguration
{
    ISignalFConfiguration AddDeviceConfiguration<TBuilder, TOptions>(Action<TBuilder> builder)
        where TBuilder : IDeviceConfigurationBuilder<TBuilder, IDeviceConfiguration, TOptions>
        where TOptions : DeviceOptions;

    ISignalFConfiguration AddDeviceConfiguration<TBuilder, TOptions, TType>(Action<TBuilder> builder)
        where TBuilder : IDeviceConfigurationBuilder<TBuilder, IDeviceConfiguration, TOptions>
        where TOptions : DeviceOptions
        where TType : class, IDevice;

    ISignalFConfiguration AddDeviceDefinition<TBuilder, TOptions>(Action<TBuilder> builder)
        where TBuilder : IDeviceDefinitionBuilder<TBuilder, IDeviceDefinition, TOptions>
        where TOptions : DeviceOptions;

    ISignalFConfiguration AddDeviceDefinition<TBuilder, TOptions, TType>(Action<TBuilder> builder)
        where TBuilder : IDeviceDefinitionBuilder<TBuilder, IDeviceDefinition, TOptions>
        where TOptions : DeviceOptions
        where TType : class, IDevice;

    ISignalFConfiguration AddDeviceTemplate<TBuilder, TOptions>(Action<TBuilder> builder)
        where TBuilder : IDeviceTemplateBuilder<TBuilder, IDeviceTemplate, TOptions>
        where TOptions : DeviceOptions;

    ISignalFConfiguration AddDeviceTemplate<TBuilder, TOptions, TType>(Action<TBuilder> action)
        where TBuilder : IDeviceTemplateBuilder<TBuilder, IDeviceTemplate, TOptions>
        where TOptions : DeviceOptions
        where TType : class, IDevice;
}
