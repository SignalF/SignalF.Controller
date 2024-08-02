using SignalF.Controller;
using SignalF.Controller.Configuration;
using SignalF.Datamodel.Signals;

namespace SignalF.Configuration.SignalConfiguration;

public interface
    ISignalProcessorDefinitionBuilder : ISignalProcessorDefinitionBuilder<ISignalProcessorDefinitionBuilder, ISignalProcessorDefinition,
    SignalProcessorOptions>
{
}

public interface
    ISignalProcessorDefinitionBuilder<out TBuilder, in TConfiguration, in TOptions> : ISignalFConfigurationBuilder<TBuilder, TConfiguration, TOptions>
    where TBuilder : ISignalProcessorDefinitionBuilder<TBuilder, TConfiguration, TOptions>
    where TConfiguration : ISignalProcessorDefinition
    where TOptions : SignalProcessorOptions
{
    TBuilder AddSignalSourceDefinition(string defaultName);

    TBuilder AddSignalSourceDefinition(string defaultName, EUnitType unitType);

    TBuilder AddSignalSinkDefinition(string defaultName);

    TBuilder AddSignalSinkDefinition(string defaultName, EUnitType unitType);

    TBuilder UseTemplate(string templateName);
}
