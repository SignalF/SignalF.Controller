using SignalF.Controller.Configuration;
using SignalF.Datamodel.Configuration;
using SignalF.Datamodel.Signals;

namespace SignalF.Configuration.SignalConfiguration;

public class SignalProcessorDefinitionBuilder
    : SignalProcessorDefinitionBuilder<SignalProcessorDefinitionBuilder, ISignalProcessorDefinitionBuilder, ISignalProcessorDefinition,
          CoreConfigurationOptions>, ISignalProcessorDefinitionBuilder
{
    protected override ISignalProcessorDefinitionBuilder This => this;
}

public abstract class SignalProcessorDefinitionBuilder<TImpl, TBuilder, TConfiguration, TOptions>
    : CoreConfigurationBuilder<TImpl, TBuilder, TConfiguration, TOptions>, ISignalProcessorDefinitionBuilder<TBuilder, TConfiguration, TOptions>
    where TBuilder : ISignalProcessorDefinitionBuilder<TBuilder, TConfiguration, TOptions>
    where TImpl : SignalProcessorDefinitionBuilder<TImpl, TBuilder, TConfiguration, TOptions>
    where TConfiguration : ISignalProcessorDefinition
    where TOptions : CoreConfigurationOptions
{
    private readonly List<SignalEndpointDefinitionBuilder> _signalSinks = new();
    private readonly List<SignalEndpointDefinitionBuilder> _signalSources = new();

    private string TemplateName { get; set; }

    public TBuilder UseTemplate(string templateName)
    {
        TemplateName = templateName;
        return This;
    }

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

        configuration.Template = FindTemplateByName(TemplateName, configuration);
        BuildSignalSourceDefinitions(configuration);
        BuildSignalSinkDefinitions(configuration);
    }

    private ISignalProcessorTemplate FindTemplateByName(string name, TConfiguration configuration)
    {
        return configuration.FindParent<IControllerConfiguration>()
                            .SignalProcessorTemplates.First(template => template.Name == name);
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
