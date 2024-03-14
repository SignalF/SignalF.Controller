#region

using Scotec.XMLDatabase.DAL.DataTypes;
using SignalF.Datamodel.Configuration;

#endregion

namespace SignalF.Controller.Schedule;

public interface IControllerTask
{
    /// <summary>
    ///     ID of the Task
    /// </summary>
    Guid Id { get; }

    /// <summary>
    ///     Determines how often the task is executed
    /// </summary>
    long Raster { get; set; }

    /// <summary>
    ///     Priority of the task.
    /// </summary>
    byte Priority { get; }

    /// <summary>
    ///     The type of the task. (e.g. init, read, write, etc.)
    /// </summary>
    ETaskType TaskType { get; }

    /// <summary>
    ///     Executes the task
    /// </summary>
    void Execute();
}
