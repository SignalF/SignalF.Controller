using SignalF.Datamodel.Signals;

namespace SignalF.Configuration.SignalConfiguration;

public interface ISignalProcessorConfigurationBuilder : ISignalProcessorConfigurationBuilder<ISignalProcessorConfigurationBuilder, ISignalProcessorConfiguration
    , SignalProcessorOptions>
{
}

public interface ISignalProcessorConfigurationBuilder<out TBuilder, in TConfiguration, in TOptions>
    : ISignalFConfigurationBuilder<TBuilder, TConfiguration, TOptions>
    where TBuilder : ISignalProcessorConfigurationBuilder<TBuilder, TConfiguration, TOptions>
    where TConfiguration : ISignalProcessorConfiguration
    where TOptions : SignalProcessorOptions
{
    TBuilder UseDefinition(string definitionName);

    TBuilder AddSignalSourceConfiguration(string signalDefinition);

    TBuilder AddSignalSourceConfiguration(string signalDefinition, Enum unit);

    TBuilder AddSignalSourceConfiguration(string signalDefinition, string signalName);

    TBuilder AddSignalSourceConfiguration(string signalDefinition, string signalName, Enum unit);

    TBuilder AddSignalSinkConfiguration(string signalDefinition);

    TBuilder AddSignalSinkConfiguration(string signalDefinition, Enum unit);

    TBuilder AddSignalSinkConfiguration(string signalDefinition, string signalName);

    TBuilder AddSignalSinkConfiguration(string signalDefinition, string signalName, Enum unit);
}
