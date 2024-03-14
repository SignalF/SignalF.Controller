#region

using System;
using System.Collections.Generic;

#endregion

namespace SignalF.Controller.Schedule;

public interface ITaskScheduler : IService
{
    /// <summary>
    ///     Configures scheduler with list of Tasks
    /// </summary>
    void Configure(IList<IControllerTask> tasks);

    /// <summary>
    ///     Updates the raster of a Task
    /// </summary>
    /// <param name="id">Id of the Task</param>
    /// <param name="newRaster">New rastersize</param>
    void UpdateRaster(Guid id, long newRaster);
}
