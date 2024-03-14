using System;
using SignalF.Controller.Configuration;
using SignalF.Datamodel.Signals;

namespace SignalF.Configuration.SignalConfiguration;

public interface ISignalProcessorConfigurationBuilder : ISignalProcessorConfigurationBuilder<ISignalProcessorConfigurationBuilder, ISignalProcessorConfiguration
    , CoreConfigurationOptions>
{
}

public interface ISignalProcessorConfigurationBuilder<out TBuilder, in TConfiguration, in TOptions>
    : ICoreConfigurationBuilder<TBuilder, TConfiguration, TOptions>
    where TBuilder : ISignalProcessorConfigurationBuilder<TBuilder, TConfiguration, TOptions>
    where TConfiguration : ISignalProcessorConfiguration
    where TOptions : CoreConfigurationOptions
{
    TBuilder UseDefinition(string definitionName);

    TBuilder AddSignalSourceConfiguration(string signalName, string signalDefinition);

    TBuilder AddSignalSourceConfiguration(string signalName, string signalDefinition, Enum unit);

    TBuilder AddSignalSinkConfiguration(string signalName, string signalDefinition);

    TBuilder AddSignalSinkConfiguration(string signalName, string signalDefinition, Enum unit);
}
