using System;
using SignalF.Configuration.Devices;
using SignalF.Controller.Configuration;
using SignalF.Controller.Signals.Devices;

namespace SignalF.Configuration;

public partial interface ICoreConfiguration
{
    ICoreConfiguration AddGenericDeviceConfiguration<TBuilder, TOptions>(Action<TBuilder> builder)
        where TBuilder : IGenericDeviceConfigurationBuilder
        where TOptions : CoreConfigurationOptions;

    ICoreConfiguration AddGenericDeviceConfiguration<TBuilder, TOptions, TType>(Action<TBuilder> builder)
        where TBuilder : IGenericDeviceConfigurationBuilder
        where TOptions : CoreConfigurationOptions
        where TType : class, IGenericDevice;

    ICoreConfiguration AddGenericDeviceDefinition<TBuilder, TOptions>(Action<TBuilder> builder)
        where TBuilder : IGenericDeviceDefinitionBuilder
        where TOptions : CoreConfigurationOptions;

    ICoreConfiguration AddGenericDeviceDefinition<TBuilder, TOptions, TType>(Action<TBuilder> builder)
        where TBuilder : IGenericDeviceDefinitionBuilder
        where TOptions : CoreConfigurationOptions
        where TType : class, IGenericDevice;

    ICoreConfiguration AddGenericDeviceTemplate<TBuilder, TOptions>(Action<TBuilder> builder)
        where TBuilder : IGenericDeviceTemplateBuilder
        where TOptions : CoreConfigurationOptions;

    ICoreConfiguration AddGenericDeviceTemplate<TBuilder, TOptions, TType>(Action<TBuilder> builder)
        where TBuilder : IGenericDeviceTemplateBuilder
        where TOptions : CoreConfigurationOptions
        where TType : class, IGenericDevice;
}
