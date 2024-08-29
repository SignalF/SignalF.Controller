using SignalF.Controller.Configuration;
using SignalF.Datamodel.Configuration;
using SignalF.Datamodel.DataOutput;
using SignalF.Datamodel.Signals;

namespace SignalF.Configuration.DataOutput;

public sealed class DataOutputConfigurationBuilder : IDataOutputConfigurationBuilder
{
    private readonly IList<string> _senderNames = new List<string>();
    private readonly IList<string> _signalNames = new List<string>();
    public string Name { get; private set; }

    public IDataOutputConfigurationBuilder AddSignalSource(string signalName)
    {
        var parts = signalName.Split('.');
        if (parts.Length != 2)
        {
            throw new ConfiguratorException($"Invalid signal source added to data output configuration. (Name = {signalName})");
        }

        if (_signalNames.Contains(signalName))
        {
            throw new ConfiguratorException($"Signal source already added to data output configuration. (Name = {signalName})");
        }

        _signalNames.Add(signalName);

        return this;
    }

    public IDataOutputConfigurationBuilder AddDataOutputSender(string senderName)
    {
        if (_senderNames.Contains(senderName))
        {
            throw new ConfiguratorException($"Data output sender already added to data output configuration. (Name = {senderName})");
        }

        _senderNames.Add(senderName);
        return this;
    }

    public void Build(IDataOutputConfiguration configuration)
    {
        configuration.Name = Name;

        var controllerConfiguration = configuration.FindParent<IControllerConfiguration>();

        var signalProcessors = controllerConfiguration.SignalProcessorConfigurations;
        foreach (var signalName in _signalNames)
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

    private static ISignalSourceConfiguration FindSignalSource(ISignalProcessorConfigurationList configurations, string signalName)
    {
        var parts = signalName.Split('.');

        var signalProcessor = configurations.FirstOrDefault(config => config.Name == parts[0]);
        if (signalProcessor == null)
        {
            throw new ConfiguratorException($"Could not find signal processor. (Name = {parts[0]})");
        }

        var source = signalProcessor.SignalSources.FirstOrDefault(source => source.Name == parts[1]);
        if (source == null)
        {
            throw new ConfiguratorException($"Could not find signal source. (SignalProcessor = {parts[0]}, SignalSource = {parts[1]})");
        }

        return source;
    }

    private static IDataOutputSenderConfiguration FindDataOutputSender(IDataOutputSenderConfigurationList configurations, string senderName)
    {
        var sender =  configurations.FirstOrDefault(config => config.Name == senderName);
        if (sender == null)
        {
            throw new ConfiguratorException($"Could not find dataoutput sender. (Name = {senderName})");
        }

        return sender;
    }
}
