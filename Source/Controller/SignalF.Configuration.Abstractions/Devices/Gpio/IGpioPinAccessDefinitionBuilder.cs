using SignalF.Configuration.SignalConfiguration;
using SignalF.Controller.Configuration;
using SignalF.Datamodel.Hardware;

namespace SignalF.Configuration.Devices.Gpio;

public interface
    IGpioPinAccessDefinitionBuilder : IGpioPinAccessDefinitionBuilder<IGpioPinAccessDefinitionBuilder, IGpioPinAccessDefinition, SignalFConfigurationOptions>
{
}

public interface
    IGpioPinAccessDefinitionBuilder<out TBuilder, in TConfiguration, in TOptions> : ISignalProcessorDefinitionBuilder<TBuilder, TConfiguration, TOptions>
    where TBuilder : IGpioPinAccessDefinitionBuilder<TBuilder, TConfiguration, TOptions>
    where TConfiguration : IGpioPinAccessDefinition
    where TOptions : SignalFConfigurationOptions
{
}
