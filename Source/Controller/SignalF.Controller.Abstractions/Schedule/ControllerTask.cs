#region

using SignalF.Datamodel.Configuration;

#endregion

namespace SignalF.Controller.Schedule;

public abstract class ControllerTask : IControllerTask
{
    protected ControllerTask(Guid id, long raster, byte priority, ETaskType taskType)
    {
        Id = id;
        Raster = raster;
        Priority = priority;
        TaskType = taskType;
    }

    public Guid Id { get; }

    public long Raster { get; set; }

    public byte Priority { get; }

    public ETaskType TaskType { get; }

    public abstract void Execute();
}
