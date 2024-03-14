using System;
using SignalF.Configuration.Devices;
using SignalF.Controller.Configuration;
using SignalF.Controller.Signals.Devices;

namespace SignalF.Configuration;

public partial interface ICoreConfiguration
{
    ICoreConfiguration AddDeviceConfiguration<TBuilder, TOptions>(Action<TBuilder> builder)
        where TBuilder : IDeviceConfigurationBuilder
        where TOptions : CoreConfigurationOptions;

    ICoreConfiguration AddDeviceConfiguration<TBuilder, TOptions, TType>(Action<TBuilder> builder)
        where TBuilder : IDeviceConfigurationBuilder
        where TOptions : CoreConfigurationOptions
        where TType : class, IDevice;

    ICoreConfiguration AddDeviceDefinition<TBuilder, TOptions>(Action<TBuilder> builder)
        where TBuilder : IDeviceDefinitionBuilder
        where TOptions : CoreConfigurationOptions;

    ICoreConfiguration AddDeviceDefinition<TBuilder, TOptions, TType>(Action<TBuilder> builder)
        where TBuilder : IDeviceDefinitionBuilder
        where TOptions : CoreConfigurationOptions
        where TType : class, IDevice;

    ICoreConfiguration AddDeviceTemplate<TBuilder, TOptions>(Action<TBuilder> builder)
        where TBuilder : IDeviceTemplateBuilder
        where TOptions : CoreConfigurationOptions;

    ICoreConfiguration AddDeviceTemplate<TBuilder, TOptions, TType>(Action<TBuilder> action)
        where TBuilder : IDeviceTemplateBuilder
        where TOptions : CoreConfigurationOptions
        where TType : class, IDevice;
}
