using SignalF.Configuration.SignalConfiguration;
using SignalF.Controller.Configuration;
using SignalF.Datamodel.Signals;

namespace SignalF.Configuration.StaticSignalProvider;

public class StaticSignalProviderDefinitionBuilder
    : StaticSignalProviderDefinitionBuilder<StaticSignalProviderDefinitionBuilder, IStaticSignalProviderDefinitionBuilder, IStaticSignalProviderDefinition,
          SignalFConfigurationOptions>,
      IStaticSignalProviderDefinitionBuilder
{
    protected override IStaticSignalProviderDefinitionBuilder This => this;
}

public abstract class StaticSignalProviderDefinitionBuilder<TImpl, TBuilder, TConfiguration, TOptions>
    : SignalProcessorDefinitionBuilder<TImpl, TBuilder, TConfiguration, TOptions>, IStaticSignalProviderDefinitionBuilder<TBuilder, TConfiguration, TOptions>
    where TBuilder : IStaticSignalProviderDefinitionBuilder<TBuilder, TConfiguration, TOptions>
    where TImpl : StaticSignalProviderDefinitionBuilder<TImpl, TBuilder, TConfiguration, TOptions>
    where TConfiguration : IStaticSignalProviderDefinition
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

//public class StaticSignalProviderDefinitionBuilder
//    : StaticSignalProviderDefinition<StaticSignalProviderDefinitionBuilder, Datamodel.Signals.IStaticSignalProviderDefinition, IStaticSignalProviderDefinition>
//      , IStaticSignalProviderDefinition
//{
//    protected override IStaticSignalProviderDefinition This => this;
//}

//public abstract class StaticSignalProviderDefinition<TElement, TConfigElement, TInterface>
//    : SignalProcessorDefinition<TElement, TConfigElement, TInterface>
//      , IStaticSignalProviderDefinition<TInterface>
//    where TInterface : IStaticSignalProviderDefinition<TInterface>
//    where TConfigElement : Datamodel.Signals.IStaticSignalProviderDefinition
//    where TElement : StaticSignalProviderDefinition<TElement, TConfigElement, TInterface>
//{
//    public override TInterface AddSignalSinkDefinition(string defaultName, EUnitType unitType)
//    {
//        throw new NotImplementedException(" Static signal provider supports signal sources.");
//    }
//}
