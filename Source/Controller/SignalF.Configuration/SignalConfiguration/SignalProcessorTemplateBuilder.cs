using SignalF.Controller;
using SignalF.Controller.Configuration;
using SignalF.Datamodel.Signals;

namespace SignalF.Configuration.SignalConfiguration;

public class SignalProcessorTemplateBuilder
    : SignalProcessorTemplateBuilder<SignalProcessorTemplateBuilder, ISignalProcessorTemplateBuilder, ISignalProcessorTemplate, SignalFConfigurationOptions>,
      ISignalProcessorTemplateBuilder
{
    protected override ISignalProcessorTemplateBuilder This => this;
}

public abstract class SignalProcessorTemplateBuilder<TImpl, TBuilder, TConfiguration, TOptions>
    : SignalFConfigurationBuilder<TImpl, TBuilder, TConfiguration, TOptions>, ISignalProcessorTemplateBuilder<TBuilder, TConfiguration, TOptions>
    where TBuilder : ISignalProcessorTemplateBuilder<TBuilder, TConfiguration, TOptions>
    where TImpl : SignalProcessorTemplateBuilder<TImpl, TBuilder, TConfiguration, TOptions>
    where TConfiguration : ISignalProcessorTemplate
    where TOptions : SignalFConfigurationOptions
{
    private readonly List<SignalEndpointDefinitionBuilder> _signalSinks = new();
    private readonly List<SignalEndpointDefinitionBuilder> _signalSources = new();

    public virtual TBuilder AddSignalSourceDefinition(string defaultName)
    {
        return AddSignalSourceDefinition(defaultName, EUnitType.None);
    }

    public virtual TBuilder AddSignalSourceDefinition(string defaultName, EUnitType unitType)
    {
        _signalSources.Add(new SignalEndpointDefinitionBuilder(defaultName, unitType));
        return This;
    }

    public virtual TBuilder AddSignalSinkDefinition(string defaultName)
    {
        return AddSignalSinkDefinition(defaultName, EUnitType.None);
    }

    public virtual TBuilder AddSignalSinkDefinition(string defaultName, EUnitType unitType)
    {
        _signalSinks.Add(new SignalEndpointDefinitionBuilder(defaultName, unitType));
        return This;
    }

    public override void Build(TConfiguration configuration)
    {
        base.Build(configuration);

        BuildSignalSourceDefinitions(configuration);
        BuildSignalSinkDefinitions(configuration);
    }

    private void BuildSignalSourceDefinitions(TConfiguration configuration)
    {
        foreach (var endpoint in _signalSources)
        {
            var endpointConfig = configuration.SignalSourceDefinitions.Create();
            endpoint.Build(endpointConfig);
        }
    }

    private void BuildSignalSinkDefinitions(TConfiguration configuration)
    {
        foreach (var endpoint in _signalSinks)
        {
            var endpointConfig = configuration.SignalSinkDefinitions.Create();
            endpoint.Build(endpointConfig);
        }
    }
}
