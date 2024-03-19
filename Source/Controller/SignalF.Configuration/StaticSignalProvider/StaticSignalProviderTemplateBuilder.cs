using SignalF.Configuration.SignalConfiguration;
using SignalF.Controller.Configuration;
using SignalF.Datamodel.Signals;

namespace SignalF.Configuration.StaticSignalProvider;

public class StaticSignalProviderTemplateBuilder
    : StaticSignalProviderTemplateBuilder<StaticSignalProviderTemplateBuilder, IStaticSignalProviderTemplateBuilder, IStaticSignalProviderTemplate,
          SignalFConfigurationOptions>,
      IStaticSignalProviderTemplateBuilder
{
    protected override IStaticSignalProviderTemplateBuilder This => this;
}

public abstract class StaticSignalProviderTemplateBuilder<TImpl, TBuilder, TConfiguration, TOptions>
    : SignalProcessorTemplateBuilder<TImpl, TBuilder, TConfiguration, TOptions>, IStaticSignalProviderTemplateBuilder<TBuilder, TConfiguration, TOptions>
    where TBuilder : IStaticSignalProviderTemplateBuilder<TBuilder, TConfiguration, TOptions>
    where TImpl : StaticSignalProviderTemplateBuilder<TImpl, TBuilder, TConfiguration, TOptions>
    where TConfiguration : IStaticSignalProviderTemplate
    where TOptions : SignalFConfigurationOptions
{
    public override TBuilder AddSignalSinkDefinition(string defaultName, EUnitType unitType)
    {
        throw new NotImplementedException(" Static signal provider supports signal sources only.");
    }

    public override void Build(TConfiguration configuration)
    {
        base.Build(configuration);
    }
}

//public class StaticSignalProviderTemplate
//    : StaticSignalProviderTemplate<StaticSignalProviderTemplate, Datamodel.Signals.IStaticSignalProviderTemplate, IStaticSignalProviderTemplate>
//      , IStaticSignalProviderTemplate
//{
//    protected override IStaticSignalProviderTemplate This => this;
//}

//public abstract class StaticSignalProviderTemplate<TElement, TConfigElement, TInterface>
//    : SignalProcessorTemplate<TElement, TConfigElement, TInterface>
//      , IStaticSignalProviderTemplate<TInterface>
//    where TInterface : IStaticSignalProviderTemplate<TInterface>
//    where TConfigElement : Datamodel.Signals.IStaticSignalProviderTemplate
//    where TElement : StaticSignalProviderTemplate<TElement, TConfigElement, TInterface>
//{
//    public override TInterface AddSignalSinkDefinition(string defaultName, EUnitType unitType)
//    {
//        throw new NotImplementedException(" Static signal provider supports signal sources.");
//    }
//}
