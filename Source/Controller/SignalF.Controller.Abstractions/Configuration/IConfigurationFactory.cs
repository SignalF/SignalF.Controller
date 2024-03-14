using SignalF.Datamodel.Configuration;

namespace SignalF.Controller.Configuration;

public interface IConfigurationFactory
{
    bool HasConfiguration { get; }
    IControllerConfiguration Configure();
}
