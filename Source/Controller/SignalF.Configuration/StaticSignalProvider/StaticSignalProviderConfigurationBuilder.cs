using SignalF.Configuration.SignalConfiguration;
using SignalF.Controller;
using SignalF.Controller.Configuration;
using SignalF.Datamodel.Signals;

namespace SignalF.Configuration.StaticSignalProvider;

public class StaticSignalProviderConfigurationBuilder
    : StaticSignalProviderConfigurationBuilder<StaticSignalProviderConfigurationBuilder, IStaticSignalProviderConfigurationBuilder,
          IStaticSignalProviderConfiguration, SignalFConfigurationOptions>, IStaticSignalProviderConfigurationBuilder
{
    protected override IStaticSignalProviderConfigurationBuilder This => this;
}

public abstract class StaticSignalProviderConfigurationBuilder<TImpl, TBuilder, TConfiguration, TOptions>
    : SignalProcessorConfigurationBuilder<TImpl, TBuilder, TConfiguration, TOptions>
      , IStaticSignalProviderConfigurationBuilder<TBuilder, TConfiguration, TOptions>
    where TBuilder : IStaticSignalProviderConfigurationBuilder<TBuilder, TConfiguration, TOptions>
    where TImpl : StaticSignalProviderConfigurationBuilder<TImpl, TBuilder, TConfiguration, TOptions>
    where TConfiguration : IStaticSignalProviderConfiguration
    where TOptions : SignalFConfigurationOptions
{
    public override TBuilder AddSignalSinkConfiguration(string signalName, string signalDefinition, Enum unit)
    {
        throw new NotImplementedException(" Static signal provider supports signal sources only.");
    }

    public override void Build(TConfiguration configuration)
    {
        base.Build(configuration);
    }
}

//public class StaticSignalProviderConfiguration
//    : StaticSignalProviderConfiguration<StaticSignalProviderConfiguration, Datamodel.Signals.IStaticSignalProviderConfiguration,
//          IStaticSignalProviderConfiguration>
//      , IStaticSignalProviderConfiguration
//{
//    protected override IStaticSignalProviderConfiguration This => this;
//}

//public abstract class StaticSignalProviderConfiguration<TElement, TConfigElement, TInterface>
//    : SignalProcessorConfiguration<TElement, TConfigElement, TInterface>
//      , IStaticSignalProviderConfiguration<TInterface>
//    where TInterface : IStaticSignalProviderConfiguration<TInterface>
//    where TConfigElement : Datamodel.Signals.IStaticSignalProviderConfiguration
//    where TElement : SignalProcessorConfiguration<TElement, TConfigElement, TInterface>
//{
//    public override TInterface AddSignalSinkConfiguration(string signalName, string signalDefinition, Enum unit)
//    {
//        throw new NotImplementedException(" Static signal provider supports signal sources.");
//    }

//    protected override TConfigElement CreateConfiguration(IControllerConfiguration configuration)
//    {
//        return configuration.SignalProcessorConfigurations.Create<TConfigElement>();
//    }
//}
