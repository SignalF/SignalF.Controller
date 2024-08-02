using SignalF.Configuration.SignalConfiguration;
using SignalF.Datamodel.Workflow;

namespace SignalF.Configuration.ProcessControl;

public class ProcessControlDefinitionBuilder
    : ProcessControlDefinitionBuilder<ProcessControlDefinitionBuilder, IProcessControlDefinitionBuilder, IProcessControlDefinition,
          ProcessControlOptions>,
      IProcessControlDefinitionBuilder
{
    protected override IProcessControlDefinitionBuilder This => this;
}

public abstract class ProcessControlDefinitionBuilder<TImpl, TBuilder, TConfiguration, TOptions>
    : SignalProcessorDefinitionBuilder<TImpl, TBuilder, TConfiguration, TOptions>, IProcessControlDefinitionBuilder<TBuilder, TConfiguration, TOptions>
    where TBuilder : IProcessControlDefinitionBuilder<TBuilder, TConfiguration, TOptions>
    where TImpl : ProcessControlDefinitionBuilder<TImpl, TBuilder, TConfiguration, TOptions>
    where TConfiguration : IProcessControlDefinition
    where TOptions : ProcessControlOptions
{
    public override void Build(TConfiguration configuration)
    {
        base.Build(configuration);
    }
}
