using Microsoft.Extensions.Logging;
using SignalF.Datamodel.Configuration;

namespace SignalF.Configuration.TaskConfiguration;

public class TaskMappingBuilder : ITaskMappingBuilder
{
    //TODO: Add logging.
    private readonly ILogger<TaskMappingBuilder> _logger;
    private readonly List<Mapping> _mappings = new();

    public TaskMappingBuilder(ILogger<TaskMappingBuilder> logger)
    {
        _logger = logger;
    }

    public ITaskMappingBuilder MapSignalProcessorToTask(string signalProcessorName, string taskName)
    {
        _mappings.Add(new Mapping(signalProcessorName, taskName));
        return this;
    }

    public void Build(IControllerConfiguration configuration)
    {
        //TODO: Add consistency check for all mappings.

        _mappings.ForEach(mapping => { mapping.Build(configuration); });
    }

    private class Mapping
    {
        public Mapping(string signalProcessorName, string taskName)
        {
            SignalProcessorName = signalProcessorName;
            TaskName = taskName;
        }

        private string SignalProcessorName { get; }
        private string TaskName { get; }

        public void Build(IControllerConfiguration configuration)
        {
            var taskConfiguration = configuration.TaskConfigurations.FirstOrDefault(task => task.Name == TaskName);
            if (taskConfiguration == null)
            {
                throw new ConfigurationBuilderException($"Unknown task '{TaskName}' used in task mapping.");
            }

            var signalProcessorConfiguration =
                configuration.SignalProcessorConfigurations.FirstOrDefault(signalProcessor => signalProcessor.Name == SignalProcessorName);
            if (signalProcessorConfiguration == null)
            {
                throw new ConfigurationBuilderException($"Unknown signal processor '{SignalProcessorName}' used in task mapping.");
            }

            taskConfiguration.SignalProcessorConfigurations.Append(signalProcessorConfiguration);
        }
    }
}
