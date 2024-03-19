using SignalF.Configuration.SignalConfiguration;

namespace SignalF.Configuration;

public partial class SignalFConfiguration : ISignalFConfiguration
{
    public ISignalFConfiguration AddConnections(Action<SignalConnectionBuilder> builder)
    {
        _signalProcessorConnections.Add(configuration =>
        {
            var connectionBuilder = new SignalConnectionBuilder();
            builder(connectionBuilder);
            connectionBuilder.Build(configuration);
        });
        return this;
    }
}
