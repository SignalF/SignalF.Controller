using SignalF.Datamodel.Configuration;

namespace SignalF.Controller.Configuration;

public interface IDeviceChannelMappingConfigurator
{
    void Configure(IControllerConfiguration controllerConfigurations);
}
