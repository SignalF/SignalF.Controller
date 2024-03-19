using System;
using SignalF.Configuration.Devices;
using SignalF.Controller.Configuration;
using SignalF.Controller.Signals.Devices;

namespace SignalF.Configuration;

public partial interface ISignalFConfiguration
{
    ISignalFConfiguration AddGenericDeviceConfiguration<TBuilder, TOptions>(Action<TBuilder> builder)
        where TBuilder : IGenericDeviceConfigurationBuilder
        where TOptions : SignalFConfigurationOptions;

    ISignalFConfiguration AddGenericDeviceConfiguration<TBuilder, TOptions, TType>(Action<TBuilder> builder)
        where TBuilder : IGenericDeviceConfigurationBuilder
        where TOptions : SignalFConfigurationOptions
        where TType : class, IGenericDevice;

    ISignalFConfiguration AddGenericDeviceDefinition<TBuilder, TOptions>(Action<TBuilder> builder)
        where TBuilder : IGenericDeviceDefinitionBuilder
        where TOptions : SignalFConfigurationOptions;

    ISignalFConfiguration AddGenericDeviceDefinition<TBuilder, TOptions, TType>(Action<TBuilder> builder)
        where TBuilder : IGenericDeviceDefinitionBuilder
        where TOptions : SignalFConfigurationOptions
        where TType : class, IGenericDevice;

    ISignalFConfiguration AddGenericDeviceTemplate<TBuilder, TOptions>(Action<TBuilder> builder)
        where TBuilder : IGenericDeviceTemplateBuilder
        where TOptions : SignalFConfigurationOptions;

    ISignalFConfiguration AddGenericDeviceTemplate<TBuilder, TOptions, TType>(Action<TBuilder> builder)
        where TBuilder : IGenericDeviceTemplateBuilder
        where TOptions : SignalFConfigurationOptions
        where TType : class, IGenericDevice;
}
