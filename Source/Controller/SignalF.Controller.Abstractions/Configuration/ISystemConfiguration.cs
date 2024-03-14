using SignalF.Datamodel.Configuration;

namespace SignalF.Controller.Configuration;

public interface ISystemConfiguration
{
    void Configure(IControllerConfiguration configuration);
}
