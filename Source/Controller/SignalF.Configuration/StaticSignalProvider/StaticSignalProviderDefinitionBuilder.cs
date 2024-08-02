using SignalF.Configuration.SignalConfiguration;
using SignalF.Datamodel.Signals;

namespace SignalF.Configuration.StaticSignalProvider;

public class StaticSignalProviderDefinitionBuilder
    : StaticSignalProviderDefinitionBuilder<StaticSignalProviderDefinitionBuilder, IStaticSignalProviderDefinitionBuilder, IStaticSignalProviderDefinition,
          StaticSignalProviderOptions>,
      IStaticSignalProviderDefinitionBuilder
{
    protected override IStaticSignalProviderDefinitionBuilder This => this;
}

public abstract class StaticSignalProviderDefinitionBuilder<TImpl, TBuilder, TConfiguration, TOptions>
    : SignalProcessorDefinitionBuilder<TImpl, TBuilder, TConfiguration, TOptions>, IStaticSignalProviderDefinitionBuilder<TBuilder, TConfiguration, TOptions>
    where TBuilder : IStaticSignalProviderDefinitionBuilder<TBuilder, TConfiguration, TOptions>
    where TImpl : StaticSignalProviderDefinitionBuilder<TImpl, TBuilder, TConfiguration, TOptions>
    where TConfiguration : IStaticSignalProviderDefinition
    where TOptions : StaticSignalProviderOptions
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
