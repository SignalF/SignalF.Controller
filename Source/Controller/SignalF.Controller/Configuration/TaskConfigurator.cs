#region

using System.Collections.Generic;
using System.Linq;
using SignalF.Controller.Schedule;
using SignalF.Datamodel.Configuration;

#endregion

namespace SignalF.Controller.Configuration;

public class TaskConfigurator : ITaskConfigurator
{
    private readonly ISignalProcessorConfigurator _processorManager;
    private readonly ITaskScheduler _taskScheduler;

    public TaskConfigurator(ITaskScheduler taskScheduler, ISignalProcessorConfigurator processorManager)
    {
        _taskScheduler = taskScheduler;
        _processorManager = processorManager;
    }

    public void Configure(IList<ITaskConfiguration> taskConfigurations)
    {
        //TODO: Automatically set the microsecondMultiplier in dependency of MinInterval.
        // The value of the microsecondMultiplier depends directly 
        // on the MinInterval of the TaskScheduler. The task scheduling is based on
        // microseconds. To determine whether a task should be executed, the time
        // is not measured, but timer events are counted. For example, a 1s task is
        // called after exactly 10^6 timer events.
        // Depending on system requirements, the task scheduler is not triggered
        // every microsecond, but at larger time intervals, e.g. 10µs, 1 ms or 1s.
        // So that the calling of the tasks is not delayed, the microsecondMultiplier
        // value must be adjusted accordingly.The value must be chosen so that the
        // product of microsecondMultiplier* MinInterval is exactly 10 ^ 6.
        const long microsecondMultiplier = 10;

        // OrderBy() performs a stable sort; that is, if the keys of two elements are equal, the order of the elements is preserved.
        // In contrast, an unstable sort does not preserve the order of elements that have the same key. 
        // Within a task, signal processors are executed in the order in which they were added.
        var orderedTasks = from taskConfiguration in taskConfigurations
                           let id = taskConfiguration.Id
                           let priority = taskConfiguration.Priority
                           let taskType = taskConfiguration.Type
                           let raster = (long)((taskConfiguration.Raster.SIValue ?? 0) * microsecondMultiplier)
                           let signalProcessors =
                               taskConfiguration.SignalProcessorConfigurations.Select(processorConfiguration =>
                                   _processorManager.SignalProcessorList.Single(processor => processor.Id == processorConfiguration.Id)).ToList()
                           select new SignalProcessorTask(id, raster, priority, taskType, signalProcessors)
                           into task
                           orderby task.Priority
                           select task as IControllerTask;

        _taskScheduler.Configure(orderedTasks.ToList());
    }
}
