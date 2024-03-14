using SignalF.Datamodel.Configuration;
using SignalF.Datamodel.DataOutput;
using SignalF.Datamodel.Signals;

namespace SignalF.Configuration.DataOutput;

public sealed class DataOutputConfigurationBuilder : IDataOutputConfigurationBuilder
{
    private readonly IList<string> _senderNames = new List<string>();
    private readonly IList<string> _signalNamess = new List<string>();
    public string Name { get; private set; }

    public IDataOutputConfigurationBuilder AddSignalSource(string signalName)
    {
        _signalNamess.Add(signalName);

        return this;
    }

    public IDataOutputConfigurationBuilder AddDataOutputSender(string senderName)
    {
        _senderNames.Add(senderName);
        return this;
    }

    public void Build(IDataOutputConfiguration configuration)
    {
        configuration.Name = Name;

        var controllerConfiguration = configuration.FindParent<IControllerConfiguration>();

        var signalProcessors = controllerConfiguration.SignalProcessorConfigurations;
        foreach (var signalName in _signalNamess)
        {
            var signalSource = FindSignalSource(signalProcessors, signalName);
            configuration.SignalSources.Append(signalSource);
        }

        var dataOutputSenders = controllerConfiguration.DataOutputSenderConfigurations;
        foreach (var senderName in _senderNames)
        {
            var senderConfiguration = FindDataOutputSender(dataOutputSenders, senderName);
            configuration.DataOutputSenders.Append(senderConfiguration);
        }
    }

    public IDataOutputConfigurationBuilder SetName(string name)
    {
        Name = name;

        return this;
    }

    private ISignalSourceConfiguration FindSignalSource(ISignalProcessorConfigurationList configurations, string signalName)
    {
        var parts = signalName.Split('.');
        return configurations.Single(config => config.Name == parts[0])
                             .SignalSources
                             .Single(source => source.Name == parts[1]);
    }

    private IDataOutputSenderConfiguration FindDataOutputSender(IDataOutputSenderConfigurationList configurations, string senderName)
    {
        return configurations.Single(config => config.Name == senderName);
    }
}
