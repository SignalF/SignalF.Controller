using Scotec.Math.Units;
using SignalF.Controller.Configuration;
using SignalF.Datamodel.Configuration;
using SignalF.Datamodel.Signals;

namespace SignalF.Configuration.SignalConfiguration;

public class SignalProcessorConfigurationBuilder
    : SignalProcessorConfigurationBuilder<SignalProcessorConfigurationBuilder, ISignalProcessorConfigurationBuilder, ISignalProcessorConfiguration,
          SignalFConfigurationOptions>, ISignalProcessorConfigurationBuilder
{
    protected override ISignalProcessorConfigurationBuilder This => this;
}

public abstract class SignalProcessorConfigurationBuilder<TImpl, TBuilder, TConfiguration, TOptions>
    : SignalFConfigurationBuilder<TImpl, TBuilder, TConfiguration, TOptions>, ISignalProcessorConfigurationBuilder<TBuilder, TConfiguration, TOptions>
    where TBuilder : ISignalProcessorConfigurationBuilder<TBuilder, TConfiguration, TOptions>
    where TImpl : SignalProcessorConfigurationBuilder<TImpl, TBuilder, TConfiguration, TOptions>
    where TConfiguration : ISignalProcessorConfiguration
    where TOptions : SignalFConfigurationOptions
{
    private readonly List<SignalConfigurationBuilder> _signalSinks = new();
    private readonly List<SignalConfigurationBuilder> _signalSources = new();

    private string DefinitionName { get; set; }

    public TBuilder UseDefinition(string definitionName)
    {
        DefinitionName = definitionName;
        return This;
    }

    public virtual TBuilder AddSignalSourceConfiguration(string signalDefinition)
    {
        return AddSignalSourceConfiguration(signalDefinition, signalDefinition, Numeric.Units.Any);
    }

    public virtual TBuilder AddSignalSourceConfiguration(string signalDefinition, Enum unit)
    {
        return AddSignalSourceConfiguration(signalDefinition, signalDefinition, unit);
    }

    public virtual TBuilder AddSignalSourceConfiguration(string signalDefinition, string signalName)
    {
        return AddSignalSourceConfiguration(signalDefinition, signalName, Numeric.Units.Any);
    }

    public virtual TBuilder AddSignalSourceConfiguration(string signalDefinition, string signalName, Enum unit)
    {
        _signalSources.Add(new SignalConfigurationBuilder(signalDefinition, signalName, unit));
        return This;
    }

    public virtual TBuilder AddSignalSinkConfiguration(string signalDefinition)
    {
        return AddSignalSinkConfiguration(signalDefinition, signalDefinition, Numeric.Units.Any);
    }

    public virtual TBuilder AddSignalSinkConfiguration(string signalDefinition, Enum unit)
    {
        return AddSignalSinkConfiguration(signalDefinition, signalDefinition, unit);
    }

    public virtual TBuilder AddSignalSinkConfiguration(string signalDefinition, string signalName)
    {
        return AddSignalSinkConfiguration(signalDefinition, signalName, Numeric.Units.Any);
    }

    public virtual TBuilder AddSignalSinkConfiguration(string signalDefinition, string signalName, Enum unit)
    {
        _signalSinks.Add(new SignalConfigurationBuilder(signalDefinition, signalName, unit));
        return This;
    }

    public override void Build(TConfiguration configuration)
    {
        base.Build(configuration);

        configuration.Definition = FindDefinitionByName(DefinitionName, configuration);
        BuildSignalSourceConfigurations(configuration);
        BuildSignalSinkConfigurations(configuration);
    }

    private ISignalProcessorDefinition FindDefinitionByName(string name, ISignalProcessorConfiguration configuration)
    {
        var definition = configuration.FindParent<IControllerConfiguration>()
                                      .SignalProcessorDefinitions.FirstOrDefault(definition => definition.Name == name);
        if (definition == null)
        {
            var message = $"No definition with name '{name}' has been configured for configuration '{Name}'.";
            throw new ConfigurationBuilderException(message);
        }

        return definition;
    }

    private void BuildSignalSourceConfigurations(ISignalProcessorConfiguration configuration)
    {
        foreach (var endpoint in _signalSources)
        {
            var endpointConfig = configuration.SignalSources.Create();
            endpoint.Build(endpointConfig);
        }
    }

    private void BuildSignalSinkConfigurations(ISignalProcessorConfiguration configuration)
    {
        foreach (var endpoint in _signalSinks)
        {
            var endpointConfig = configuration.SignalSinks.Create();
            endpoint.Build(endpointConfig);
        }
    }
}
