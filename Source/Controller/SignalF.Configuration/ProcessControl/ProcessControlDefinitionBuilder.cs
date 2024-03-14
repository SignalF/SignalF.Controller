using SignalF.Configuration.SignalConfiguration;
using SignalF.Controller.Configuration;
using SignalF.Datamodel.Workflow;

namespace SignalF.Configuration.ProcessControl;

public class ProcessControlDefinitionBuilder
    : ProcessControlDefinitionBuilder<ProcessControlDefinitionBuilder, IProcessControlDefinitionBuilder, IProcessControlDefinition,
          CoreConfigurationOptions>,
      IProcessControlDefinitionBuilder
{
    protected override IProcessControlDefinitionBuilder This => this;
}

public abstract class ProcessControlDefinitionBuilder<TImpl, TBuilder, TConfiguration, TOptions>
    : SignalProcessorDefinitionBuilder<TImpl, TBuilder, TConfiguration, TOptions>, IProcessControlDefinitionBuilder<TBuilder, TConfiguration, TOptions>
    where TBuilder : IProcessControlDefinitionBuilder<TBuilder, TConfiguration, TOptions>
    where TImpl : ProcessControlDefinitionBuilder<TImpl, TBuilder, TConfiguration, TOptions>
    where TConfiguration : IProcessControlDefinition
    where TOptions : CoreConfigurationOptions
{
    public override void Build(TConfiguration configuration)
    {
        base.Build(configuration);
    }
}

//public class ProcessControlDefinition
//    : ProcessControlDefinition<ProcessControlDefinition, Datamodel.Workflow.IProcessControlDefinition, IProcessControlDefinitionBuilder>
//      , IProcessControlDefinitionBuilder
//{
//    protected override IProcessControlDefinitionBuilder This => this;
//}

//public abstract class ProcessControlDefinition<TElement, TConfigElement, TInterface>
//    : SignalProcessorDefinition<TElement, TConfigElement, TInterface>
//      , IProcessControlDefinition<TInterface>
//    where TInterface : IProcessControlDefinition<TInterface>
//    where TConfigElement : Datamodel.Workflow.IProcessControlDefinition
//    where TElement : ProcessControlDefinition<TElement, TConfigElement, TInterface>
//{
//    //protected override TConfigElement CreateConfiguration(IControllerConfiguration configuration)
//    //{
//    //    return configuration.SignalProcessorDefinitions.Create<TConfigElement>();
//    //}
//}
