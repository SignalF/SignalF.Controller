using System;
using SignalF.Configuration.TaskConfiguration;

namespace SignalF.Configuration;

public partial interface ICoreConfiguration
{
    ICoreConfiguration AddTasks(Action<ITaskConfigurationBuilder> builder);

    ICoreConfiguration AddTaskMappings(Action<ITaskMappingBuilder> builder);
}
