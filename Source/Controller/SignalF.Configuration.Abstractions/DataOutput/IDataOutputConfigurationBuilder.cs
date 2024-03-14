using SignalF.Datamodel.DataOutput;

namespace SignalF.Configuration.DataOutput;

public interface IDataOutputConfigurationBuilder
{
    IDataOutputConfigurationBuilder AddSignalSource(string signalName);
    IDataOutputConfigurationBuilder AddDataOutputSender(string senderName);

    void Build(IDataOutputConfiguration configuration);

    IDataOutputConfigurationBuilder SetName(string name);
}
