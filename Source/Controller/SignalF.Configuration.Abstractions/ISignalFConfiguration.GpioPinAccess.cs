using SignalF.Configuration.Devices.Gpio;
using SignalF.Controller;
using SignalF.Controller.Configuration;
using SignalF.Controller.Signals.Devices;
using SignalF.Datamodel.Devices;
using SignalF.Datamodel.Hardware;

namespace SignalF.Configuration;

public partial interface ISignalFConfiguration
{
    ISignalFConfiguration AddGpioPinAccessConfiguration<TBuilder, TOptions>(Action<TBuilder> builder)
        where TBuilder : IGpioPinAccessConfigurationBuilder<TBuilder, IGpioPinAccessConfiguration, TOptions>
        where TOptions : GpioPinAccessOptions;

    ISignalFConfiguration AddGpioPinAccessConfiguration<TBuilder, TOptions, TType>(Action<TBuilder> builder)
        where TBuilder : IGpioPinAccessConfigurationBuilder<TBuilder, IGpioPinAccessConfiguration, TOptions>
        where TOptions : GpioPinAccessOptions
        where TType : class, IGpioPinAccess;

    ISignalFConfiguration AddGpioPinAccessDefinition<TBuilder, TOptions>(Action<TBuilder> builder)
        where TBuilder : IGpioPinAccessDefinitionBuilder<TBuilder, IGpioPinAccessDefinition, TOptions>
        where TOptions : GpioPinAccessOptions;

    ISignalFConfiguration AddGpioPinAccessDefinition<TBuilder, TOptions, TType>(Action<TBuilder> builder)
        where TBuilder : IGpioPinAccessDefinitionBuilder<TBuilder, IGpioPinAccessDefinition, TOptions>
        where TOptions : GpioPinAccessOptions
        where TType : class, IGpioPinAccess;

    ISignalFConfiguration AddGpioPinAccessTemplate<TBuilder, TOptions>(Action<TBuilder> builder)
        where TBuilder : IGpioPinAccessTemplateBuilder<TBuilder, IGpioPinAccessTemplate, TOptions>
        where TOptions : GpioPinAccessOptions;

    ISignalFConfiguration AddGpioPinAccessTemplate<TBuilder, TOptions, TType>(Action<TBuilder> action)
        where TBuilder : IGpioPinAccessTemplateBuilder<TBuilder, IGpioPinAccessTemplate, TOptions>
        where TOptions : GpioPinAccessOptions
        where TType : class, IGpioPinAccess;
}
