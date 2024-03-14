using SignalF.Configuration.SignalConfiguration;
using SignalF.Controller.Configuration;
using SignalF.Datamodel.Workflow;

namespace SignalF.Configuration.ProcessControl;

public interface IProcessControlConfigurationBuilder : IProcessControlConfigurationBuilder<IProcessControlConfigurationBuilder, IProcessControlConfiguration
    , CoreConfigurationOptions>
{
}

public interface
    IProcessControlConfigurationBuilder<out TBuilder, in TConfiguration, in TOptions> : ISignalProcessorConfigurationBuilder<TBuilder, TConfiguration,
        TOptions>
    where TBuilder : IProcessControlConfigurationBuilder<TBuilder, TConfiguration, TOptions>
    where TConfiguration : IProcessControlConfiguration
    where TOptions : CoreConfigurationOptions
{
}
