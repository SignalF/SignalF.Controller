using SignalF.Datamodel.Signals;
using SignalF.Datamodel.Units;

namespace SignalF.Configuration.SignalConfiguration;

public class SignalConfigurationBuilder
{
    public SignalConfigurationBuilder(string name, string signalEndpointName)
    {
        Name = name;
        SignalEndpointName = signalEndpointName;
    }

    public SignalConfigurationBuilder(string signalEndpointName, string signalName, Enum unit)
    {
        Name = signalName;
        SignalEndpointName = signalEndpointName;
        Unit = unit;
    }

    public string Name { get; }
    public string SignalEndpointName { get; }
    public virtual Enum Unit { get; }

    public void Build(ISignalSourceConfiguration configuration)
    {
        configuration.Name = Name;
        configuration.Definition = FindSourceDefinitionByName(SignalEndpointName, configuration);
        BuildUnit(configuration);
    }

    public void Build(ISignalSinkConfiguration configuration)
    {
        configuration.Name = Name;
        configuration.Definition = FindSinkDefinitionByName(SignalEndpointName, configuration);
        BuildUnit(configuration);
    }

    protected virtual void BuildUnit(ISignalConfiguration configuration)
    {
        if (Unit == null)
        {
            return;
        }

        var assembly = typeof(IValue).Assembly;

        var type = assembly.GetTypes().Single(type => type.IsInterface
                                                      && type.Name.EndsWith("Unit")
                                                      && type.GetProperty("Unit")?.PropertyType == Unit.GetType());

        var method = (from i in configuration.GetType().GetInterfaces()
                      let m = i.GetMethod("CreateUnit")
                      where m != null
                      select m).First();

        var genericMethod = method.MakeGenericMethod(type);
        var unit = genericMethod.Invoke(configuration, null);

        var property = (from i in unit.GetType().GetInterfaces()
                        let m = i.GetProperty("Unit")
                        where m != null
                        select m).First();

        property.SetMethod.Invoke(unit, new object[] { Unit });
    }

    private ISignalEndpointDefinition FindSourceDefinitionByName(string signalEndpointName, ISignalSourceConfiguration configuration)
    {
        var signalProcessorConfiguration = configuration.FindParent<ISignalProcessorConfiguration>();
        var endpointDefinition = signalProcessorConfiguration
                                 .Definition
                                 .SignalSourceDefinitions
                                 .FirstOrDefault(endpoint => endpoint.Name == signalEndpointName);

        if (endpointDefinition == null)
        {
            endpointDefinition = signalProcessorConfiguration
                                 .Definition
                                 .Template
                                 .SignalSourceDefinitions
                                 .FirstOrDefault(endpoint => endpoint.Name == signalEndpointName);
        }

        if (endpointDefinition == null)
        {
            throw new ConfigurationBuilderException($"Unknown signal source endpoint '{signalEndpointName}'.");
        }

        return endpointDefinition;
    }

    private ISignalEndpointDefinition FindSinkDefinitionByName(string signalEndpointName, ISignalSinkConfiguration configuration)
    {
        var signalProcessorConfiguration = configuration.FindParent<ISignalProcessorConfiguration>();
        var endpointDefinition = signalProcessorConfiguration
                                 .Definition
                                 .SignalSinkDefinitions
                                 .FirstOrDefault(endpoint => endpoint.Name == signalEndpointName);

        if (endpointDefinition == null)
        {
            endpointDefinition = signalProcessorConfiguration
                                 .Definition
                                 .Template
                                 .SignalSinkDefinitions
                                 .FirstOrDefault(endpoint => endpoint.Name == signalEndpointName);
        }

        if (endpointDefinition == null)
        {
            throw new ConfigurationBuilderException($"Unknown signal sink endpoint '{signalEndpointName}'.");
        }

        return endpointDefinition;
    }
}
