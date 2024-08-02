using SignalF.Configuration.SignalConfiguration;
using SignalF.Datamodel.Workflow;

namespace SignalF.Configuration.ProcessControl;

public class ProcessControlConfigurationBuilder
    : ProcessControlConfigurationBuilder<ProcessControlConfigurationBuilder, IProcessControlConfigurationBuilder, IProcessControlConfiguration,
          ProcessControlOptions>, IProcessControlConfigurationBuilder
{
    protected override IProcessControlConfigurationBuilder This => this;
}

public abstract class ProcessControlConfigurationBuilder<TImpl, TBuilder, TConfiguration, TOptions>
    : SignalProcessorConfigurationBuilder<TImpl, TBuilder, TConfiguration, TOptions>, IProcessControlConfigurationBuilder<TBuilder, TConfiguration, TOptions>
    where TBuilder : IProcessControlConfigurationBuilder<TBuilder, TConfiguration, TOptions>
    where TImpl : ProcessControlConfigurationBuilder<TImpl, TBuilder, TConfiguration, TOptions>
    where TConfiguration : IProcessControlConfiguration
    where TOptions : ProcessControlOptions
{
    public override void Build(TConfiguration configuration)
    {
        base.Build(configuration);
    }
}
