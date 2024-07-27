using SignalF.Configuration.TaskConfiguration;

namespace SignalF.Configuration;

public partial interface ISignalFConfiguration
{
    ISignalFConfiguration AddTasks(Action<ITaskConfigurationBuilder> builder);

    ISignalFConfiguration AddTaskMappings(Action<ITaskMappingBuilder> builder);
}
