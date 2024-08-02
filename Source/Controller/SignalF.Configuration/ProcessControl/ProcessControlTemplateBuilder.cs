using SignalF.Configuration.SignalConfiguration;
using SignalF.Datamodel.Workflow;

namespace SignalF.Configuration.ProcessControl;

public class ProcessControlTemplateBuilder
    : ProcessControlTemplateBuilder<ProcessControlTemplateBuilder, IProcessControlTemplateBuilder, IProcessControlTemplate, ProcessControlOptions>,
      IProcessControlTemplateBuilder
{
    protected override IProcessControlTemplateBuilder This => this;
}

public abstract class ProcessControlTemplateBuilder<TImpl, TBuilder, TConfiguration, TOptions>
    : SignalProcessorTemplateBuilder<TImpl, TBuilder, TConfiguration, TOptions>, IProcessControlTemplateBuilder<TBuilder, TConfiguration, TOptions>
    where TBuilder : IProcessControlTemplateBuilder<TBuilder, TConfiguration, TOptions>
    where TImpl : ProcessControlTemplateBuilder<TImpl, TBuilder, TConfiguration, TOptions>
    where TConfiguration : IProcessControlTemplate
    where TOptions : ProcessControlOptions
{
    public override void Build(TConfiguration configuration)
    {
        base.Build(configuration);
    }
}

//public class ProcessControlTemplate
//    : ProcessControlTemplate<ProcessControlTemplate, Datamodel.Workflow.IProcessControlTemplate, IProcessControlTemplate>
//      , IProcessControlTemplate
//{
//    protected override IProcessControlTemplate This => this;
//}

//public abstract class ProcessControlTemplate<TElement, TConfigElement, TInterface>
//    : SignalProcessorTemplate<TElement, TConfigElement, TInterface>
//      , IProcessControlTemplate<TInterface>
//    where TInterface : IProcessControlTemplate<TInterface>
//    where TConfigElement : Datamodel.Workflow.IProcessControlTemplate
//    where TElement : ProcessControlTemplate<TElement, TConfigElement, TInterface>
//{
//    //protected override TConfigElement CreateConfiguration(IControllerConfiguration configuration)
//    //{
//    //    return configuration.SignalProcessorTemplates.Create<TConfigElement>();
//    //}
//}
