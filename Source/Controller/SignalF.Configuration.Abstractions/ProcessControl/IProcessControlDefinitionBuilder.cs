using SignalF.Configuration.SignalConfiguration;
using SignalF.Controller;
using SignalF.Controller.Configuration;
using SignalF.Datamodel.Workflow;

namespace SignalF.Configuration.ProcessControl;

public interface
    IProcessControlDefinitionBuilder : IProcessControlDefinitionBuilder<IProcessControlDefinitionBuilder, IProcessControlDefinition,
        SignalFConfigurationOptions>
{
}

public interface
    IProcessControlDefinitionBuilder<out TBuilder, in TConfiguration, in TOptions> : ISignalProcessorDefinitionBuilder<TBuilder, TConfiguration, TOptions>
    where TBuilder : IProcessControlDefinitionBuilder<TBuilder, TConfiguration, TOptions>
    where TConfiguration : IProcessControlDefinition
    where TOptions : SignalFConfigurationOptions
{
}
