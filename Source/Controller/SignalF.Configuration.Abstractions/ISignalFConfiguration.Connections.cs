using SignalF.Configuration.SignalConfiguration;

namespace SignalF.Configuration;

public partial interface ISignalFConfiguration
{
    ISignalFConfiguration AddConnections(Action<SignalConnectionBuilder> builder);
}
