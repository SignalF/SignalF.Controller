using System.Linq;
using SignalF.Datamodel.Configuration;
using SignalF.Datamodel.Signals;

namespace SignalF.Configuration.SignalConfiguration;

internal class SignalConnection
{
    public SignalConnection(string source, string sink)
    {
        Source = source;
        Sink = sink;
    }

    public string Source { get; set; }
    public string Sink { get; }

    public void Build(ISignalConnection configuration)
    {
        var controllerConfiguration = configuration.FindParent<IControllerConfiguration>();
        configuration.SignalSource = FindSignalSource(controllerConfiguration);
        configuration.SignalSink = FindSignalSink(controllerConfiguration);
    }

    private ISignalSinkConfiguration FindSignalSink(IControllerConfiguration controllerConfiguration)
    {
        var parts = Sink.Split('.');
        return controllerConfiguration.SignalProcessorConfigurations
                                      .Single(config => config.Name == parts[0])
                                      .SignalSinks
                                      .Single(sink => sink.Name == parts[1]);
    }

    private ISignalSourceConfiguration FindSignalSource(IControllerConfiguration controllerConfiguration)
    {
        var parts = Source.Split('.');
        return controllerConfiguration.SignalProcessorConfigurations
                                      .Single(config => config.Name == parts[0])
                                      .SignalSources
                                      .Single(source => source.Name == parts[1]);
    }
}
