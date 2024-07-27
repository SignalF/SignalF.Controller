using SignalF.Configuration.Devices.Gpio;
using SignalF.Controller.Configuration;
using SignalF.Controller.Signals.Devices;

namespace SignalF.Configuration;

public partial interface ISignalFConfiguration
{
    ISignalFConfiguration AddGpioPinAccessConfiguration<TBuilder, TOptions>(Action<TBuilder> builder)
        where TBuilder : IGpioPinAccessConfigurationBuilder
        where TOptions : SignalFConfigurationOptions;

    ISignalFConfiguration AddGpioPinAccessConfiguration<TBuilder, TOptions, TType>(Action<TBuilder> builder)
        where TBuilder : IGpioPinAccessConfigurationBuilder
        where TOptions : SignalFConfigurationOptions
        where TType : class, IGpioPinAccess;

    ISignalFConfiguration AddGpioPinAccessDefinition<TBuilder, TOptions>(Action<TBuilder> builder)
        where TBuilder : IGpioPinAccessDefinitionBuilder
        where TOptions : SignalFConfigurationOptions;

    ISignalFConfiguration AddGpioPinAccessDefinition<TBuilder, TOptions, TType>(Action<TBuilder> builder)
        where TBuilder : IGpioPinAccessDefinitionBuilder
        where TOptions : SignalFConfigurationOptions
        where TType : class, IGpioPinAccess;

    ISignalFConfiguration AddGpioPinAccessTemplate<TBuilder, TOptions>(Action<TBuilder> builder)
        where TBuilder : IGpioPinAccessTemplateBuilder
        where TOptions : SignalFConfigurationOptions;

    ISignalFConfiguration AddGpioPinAccessTemplate<TBuilder, TOptions, TType>(Action<TBuilder> action)
        where TBuilder : IGpioPinAccessTemplateBuilder
        where TOptions : SignalFConfigurationOptions
        where TType : class, IGpioPinAccess;
}
