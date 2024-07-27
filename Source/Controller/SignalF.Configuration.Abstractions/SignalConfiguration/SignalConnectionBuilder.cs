using SignalF.Datamodel.Configuration;
using SignalF.Datamodel.Signals;

namespace SignalF.Configuration.SignalConfiguration;

public class SignalConnectionBuilder
{
    private readonly List<SignalConnection> _connections = new();

    public SignalConnectionBuilder AddConnection(string source, string sink)
    {
        _connections.Add(new SignalConnection(source, sink));
        return this;
    }

    public void Build(IControllerConfiguration configuration)
    {
        foreach (var connection in _connections)
        {
            connection.Build(configuration.Connections.Create<ISignalConnection>());
        }
    }
}
