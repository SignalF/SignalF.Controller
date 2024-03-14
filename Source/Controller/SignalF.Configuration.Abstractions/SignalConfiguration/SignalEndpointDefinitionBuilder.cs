using SignalF.Datamodel.Signals;

namespace SignalF.Configuration.SignalConfiguration;

public class SignalEndpointDefinitionBuilder
{
    public SignalEndpointDefinitionBuilder(string name, EUnitType unitType)
    {
        Name = name;
        UnitType = unitType;
    }

    public string Name { get; }
    public EUnitType UnitType { get; }

    public void Build(ISignalEndpointDefinition definition)
    {
        definition.Name = Name;
        definition.UnitType = UnitType;
    }
}
