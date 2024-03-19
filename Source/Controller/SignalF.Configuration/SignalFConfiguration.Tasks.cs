using Microsoft.Extensions.DependencyInjection;
using SignalF.Configuration.TaskConfiguration;

namespace SignalF.Configuration;

public partial class SignalFConfiguration : ISignalFConfiguration
{
    public ISignalFConfiguration AddTasks(Action<ITaskConfigurationBuilder> action)
    {
        _taskOptions.Add(configuration =>
        {
            var builder = _serviceProvider.GetRequiredService<ITaskConfigurationBuilder>();
            action(builder);
            builder.Build(configuration);
        });
        return this;
    }

    public ISignalFConfiguration AddTaskMappings(Action<ITaskMappingBuilder> action)
    {
        _taskMappingOptions.Add(configuration =>
        {
            var builder = _serviceProvider.GetRequiredService<ITaskMappingBuilder>();
            action(builder);
            builder.Build(configuration);
        });
        return this;
    }
}
