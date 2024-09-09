#region

using System.Runtime.Versioning;
using Scotec.Extensions.Linq;
using SignalF.Controller.Signals;
using SignalF.Controller.Timer;
using SignalF.Datamodel.Configuration;

#endregion

namespace SignalF.Controller.Schedule;

[SupportedOSPlatform("linux")]
[SupportedOSPlatform("windows")]
public class TaskScheduler : ITaskScheduler
{
    //TODO: Make MinInterval configurable.
    //When changing this value, the microsecondMultiplier in the Configure() in TaskConfigurator.cs must be changed as well
    private const long MinInterval = 100000; // in microseconds
    private const long Cutoff = 500; // in microseconds

    private readonly ScotecTimer _timer;
    private readonly ISignalHub _signalHub;

    private ScheduleItem[] _scheduleItems;
    private IControllerTask[] _initTasks;
    private IControllerTask[] _exitTasks;

#if DEBUG_SCHEDULER
        private readonly long[] _array = new long[2_000_000];
        private int _index;
#endif

    public TaskScheduler(ScotecTimer timer, ISignalHub signalHub)
    {
        _timer = timer;
        _signalHub = signalHub;
    }

    public void Configure(IList<IControllerTask> tasks)
    {
        _initTasks = tasks.Where(task => task.TaskType == ETaskType.Init).ToArray();
        _exitTasks = tasks.Where(task => task.TaskType == ETaskType.Exit).ToArray();
        _scheduleItems = tasks.Where(task => task.TaskType != ETaskType.Init && task.TaskType != ETaskType.Exit)
                              .Select(task => new ScheduleItem { Task = task }).ToArray();

        // configure internal timer
        _timer.Interval = MinInterval;
        _timer.IgnoreCutoff = Cutoff;
        _timer.Elapsed += OnTimerElapsed;
    }

    public void Initialize()
    {
        // reset DueCounter
        _scheduleItems.ForAll(item => item.DueCounter = 0);
    }

    public void Run()
    {
        _initTasks.ForAll(task => task.Execute());

        // The init tasks may write initial values to the signal hub.
        // Therefore the signal hub needs to be informed that a new cycle has started.
        _signalHub.NewCycle();
        _timer.Start();
    }

    public void Shutdown()
    {
        _timer.StopAndWait();

        _exitTasks.ForAll(task => task.Execute());

#if DEBUG_SCHEDULER
// count how many events were skipped due to being late
            long prev = 0;
            long missed = 0;
            foreach (var s in _array)
            {
                if (s == 0) continue;
                if (s != prev + 1)
                    missed += s - prev;
                prev = s;
            }

            Trace.WriteLine($"Skipped: {missed}");

            Trace.WriteLine("Done");
#endif
    }

    public void UpdateRaster(Guid id, long newRaster)
    {
        var item = _scheduleItems.Single(i => i.Task.Id == id);
        item.Task.Raster = newRaster;
        item.RasterChanged = true;
    }

    private void OnTimerElapsed(object source, ScotecTimerEventArgs eventArgs)
    {
        _signalHub.Timestamp = eventArgs.Timestamp;
#if DEBUG_SCHEDULER
            _array[_index++] = eventArgs.Counter;
#endif

        foreach (var scheduleItem in _scheduleItems)
        {
            if (eventArgs.Counter < scheduleItem.DueCounter && !scheduleItem.RasterChanged)
            {
                continue;
            }

            scheduleItem.Task.Execute();

            if (scheduleItem.RasterChanged)
            {
                scheduleItem.DueCounter = eventArgs.Counter;
                scheduleItem.RasterChanged = false;
            }

            scheduleItem.DueCounter += scheduleItem.Task.Raster;
        }

        _signalHub.NewCycle();
    }

    private class ScheduleItem
    {
        public IControllerTask Task { get; init; }
        public long DueCounter { get; set; }
        public bool RasterChanged { get; set; }
    }
}
