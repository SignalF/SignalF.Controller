using SignalF.Configuration.SignalConfiguration;
using SignalF.Datamodel.Signals;

namespace SignalF.Configuration.StaticSignalProvider;

public class StaticSignalProviderTemplateBuilder
    : StaticSignalProviderTemplateBuilder<StaticSignalProviderTemplateBuilder, IStaticSignalProviderTemplateBuilder, IStaticSignalProviderTemplate,
          StaticSignalProviderOptions>,
      IStaticSignalProviderTemplateBuilder
{
    protected override IStaticSignalProviderTemplateBuilder This => this;
}

public abstract class StaticSignalProviderTemplateBuilder<TImpl, TBuilder, TConfiguration, TOptions>
    : SignalProcessorTemplateBuilder<TImpl, TBuilder, TConfiguration, TOptions>, IStaticSignalProviderTemplateBuilder<TBuilder, TConfiguration, TOptions>
    where TBuilder : IStaticSignalProviderTemplateBuilder<TBuilder, TConfiguration, TOptions>
    where TImpl : StaticSignalProviderTemplateBuilder<TImpl, TBuilder, TConfiguration, TOptions>
    where TConfiguration : IStaticSignalProviderTemplate
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
