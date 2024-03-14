using System;
using SignalF.Configuration.SignalConfiguration;

namespace SignalF.Configuration;

public partial interface ICoreConfiguration
{
    ICoreConfiguration AddConnections(Action<SignalConnectionBuilder> builder);
}
