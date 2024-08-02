using SignalF.Configuration.SignalConfiguration;
using SignalF.Datamodel.Hardware;

namespace SignalF.Configuration.Devices.Gpio;

public interface
    IGpioPinAccessDefinitionBuilder : IGpioPinAccessDefinitionBuilder<IGpioPinAccessDefinitionBuilder, IGpioPinAccessDefinition, GpioPinAccessOptions>
{
}

public interface
    IGpioPinAccessDefinitionBuilder<out TBuilder, in TConfiguration, in TOptions> : ISignalProcessorDefinitionBuilder<TBuilder, TConfiguration, TOptions>
    where TBuilder : IGpioPinAccessDefinitionBuilder<TBuilder, TConfiguration, TOptions>
    where TConfiguration : IGpioPinAccessDefinition
    where TOptions : GpioPinAccessOptions
{
}
