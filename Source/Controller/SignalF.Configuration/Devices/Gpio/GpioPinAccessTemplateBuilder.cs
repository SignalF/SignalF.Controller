using SignalF.Configuration.SignalConfiguration;
using SignalF.Datamodel.Hardware;

namespace SignalF.Configuration.Devices.Gpio;

public class GpioPinAccessTemplateBuilder
    : GpioPinAccessTemplateBuilder<GpioPinAccessTemplateBuilder, IGpioPinAccessTemplateBuilder, IGpioPinAccessTemplate, GpioPinAccessOptions>,
      IGpioPinAccessTemplateBuilder
{
    protected override IGpioPinAccessTemplateBuilder This => this;
}

public abstract class GpioPinAccessTemplateBuilder<TImpl, TBuilder, TConfiguration, TOptions>
    : SignalProcessorTemplateBuilder<TImpl, TBuilder, TConfiguration, TOptions>, IGpioPinAccessTemplateBuilder<TBuilder, TConfiguration, TOptions>
    where TBuilder : IGpioPinAccessTemplateBuilder<TBuilder, TConfiguration, TOptions>
    where TImpl : GpioPinAccessTemplateBuilder<TImpl, TBuilder, TConfiguration, TOptions>
    where TConfiguration : IGpioPinAccessTemplate
    where TOptions : GpioPinAccessOptions
{
    public override void Build(TConfiguration configuration)
    {
        base.Build(configuration);
    }
}

//public class GpioPinAccessTemplate
//    : GpioPinAccessTemplate<GpioPinAccessTemplate, Datamodel.Workflow.IGpioPinAccessTemplate, IGpioPinAccessTemplate>
//      , IGpioPinAccessTemplate
//{
//    protected override IGpioPinAccessTemplate This => this;
//}

//public abstract class GpioPinAccessTemplate<TElement, TConfigElement, TInterface>
//    : SignalProcessorTemplate<TElement, TConfigElement, TInterface>
//      , IGpioPinAccessTemplate<TInterface>
//    where TInterface : IGpioPinAccessTemplate<TInterface>
//    where TConfigElement : Datamodel.Workflow.IGpioPinAccessTemplate
//    where TElement : GpioPinAccessTemplate<TElement, TConfigElement, TInterface>
//{
//    //protected override TConfigElement CreateConfiguration(IControllerConfiguration configuration)
//    //{
//    //    return configuration.SignalProcessorTemplates.Create<TConfigElement>();
//    //}
//}
