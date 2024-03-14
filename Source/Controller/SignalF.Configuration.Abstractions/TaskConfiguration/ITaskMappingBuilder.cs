using SignalF.Datamodel.Configuration;

namespace SignalF.Configuration.TaskConfiguration;

public interface ITaskMappingBuilder
{
    ITaskMappingBuilder MapSignalProcessorToTask(string signalProcessorName, string taskName);

    void Build(IControllerConfiguration configuration);
}
