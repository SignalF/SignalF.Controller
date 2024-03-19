using SignalF.Datamodel.Configuration;

namespace SignalF.Configuration;

public partial interface ISignalFConfiguration
{
    void Build(IControllerConfiguration configuration);
}
