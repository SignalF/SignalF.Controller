using Microsoft.Extensions.Logging;
using Scotec.Math.Units;
using SignalF.Datamodel.Configuration;

namespace SignalF.Configuration.TaskConfiguration;

public class TaskConfigurationBuilder : ITaskConfigurationBuilder
{
    //TODO: Add logging to class
    private readonly ILogger<TaskConfigurationBuilder> _logger;
    private readonly List<Task> _tasks = new();

    public TaskConfigurationBuilder(ILogger<TaskConfigurationBuilder> logger)
    {
        _logger = logger;
    }

    public ITaskConfigurationBuilder AddTask(string taskName, byte priority, ETaskType taskType, double raster, Time.Units unit)
    {
        _tasks.Add(new Task(taskName, priority, taskType, raster, unit));
        return this;
    }

    public void Build(IControllerConfiguration configuration)
    {
        var taskConfigurations = configuration.TaskConfigurations;

        //TODO: Add consistency check for all tasks.

        _tasks.ForEach(task => { task.Build(taskConfigurations); });
    }

    private class Task
    {
        public Task(string taskName, byte priority, ETaskType taskType, double raster, Time.Units unit)
        {
            TaskName = taskName;
            Priority = priority;
            TaskType = taskType;
            Raster = raster;
            Unit = unit;
        }

        private byte Priority { get; }
        private double Raster { get; }
        private string TaskName { get; }
        private ETaskType TaskType { get; }
        private Time.Units Unit { get; }

        public void Build(ITaskConfigurationList taskConfigurations)
        {
            var configuration = taskConfigurations.Create();
            configuration.Name = TaskName;
            configuration.Priority = Priority;
            configuration.Type = TaskType;
            configuration.Raster.Unit = Unit;
            configuration.Raster.Value = new Time(Unit, Raster);
        }
    }
}
