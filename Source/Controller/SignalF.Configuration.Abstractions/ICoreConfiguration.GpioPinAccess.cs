using System;
using SignalF.Configuration.Devices.Gpio;
using SignalF.Controller.Configuration;
using SignalF.Controller.Signals.Devices;

namespace SignalF.Configuration;

public partial interface ICoreConfiguration
{
    ICoreConfiguration AddGpioPinAccessConfiguration<TBuilder, TOptions>(Action<TBuilder> builder)
        where TBuilder : IGpioPinAccessConfigurationBuilder
        where TOptions : CoreConfigurationOptions;

    ICoreConfiguration AddGpioPinAccessConfiguration<TBuilder, TOptions, TType>(Action<TBuilder> builder)
        where TBuilder : IGpioPinAccessConfigurationBuilder
        where TOptions : CoreConfigurationOptions
        where TType : class, IGpioPinAccess;

    ICoreConfiguration AddGpioPinAccessDefinition<TBuilder, TOptions>(Action<TBuilder> builder)
        where TBuilder : IGpioPinAccessDefinitionBuilder
        where TOptions : CoreConfigurationOptions;

    ICoreConfiguration AddGpioPinAccessDefinition<TBuilder, TOptions, TType>(Action<TBuilder> builder)
        where TBuilder : IGpioPinAccessDefinitionBuilder
        where TOptions : CoreConfigurationOptions
        where TType : class, IGpioPinAccess;

    ICoreConfiguration AddGpioPinAccessTemplate<TBuilder, TOptions>(Action<TBuilder> builder)
        where TBuilder : IGpioPinAccessTemplateBuilder
        where TOptions : CoreConfigurationOptions;

    ICoreConfiguration AddGpioPinAccessTemplate<TBuilder, TOptions, TType>(Action<TBuilder> action)
        where TBuilder : IGpioPinAccessTemplateBuilder
        where TOptions : CoreConfigurationOptions
        where TType : class, IGpioPinAccess;
}
