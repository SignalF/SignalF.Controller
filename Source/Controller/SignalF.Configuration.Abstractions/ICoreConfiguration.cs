using SignalF.Datamodel.Configuration;

namespace SignalF.Configuration;

public partial interface ICoreConfiguration
{
    void Build(IControllerConfiguration configuration);
}
