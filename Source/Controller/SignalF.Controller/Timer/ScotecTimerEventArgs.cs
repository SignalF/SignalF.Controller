#region

#endregion

namespace SignalF.Controller.Timer;

public record struct ScotecTimerEventArgs
{
    /// <summary>
    ///     The time at which the event has been raised.
    /// </summary>
    public long Timestamp { get; set; }

    /// <summary>
    ///     Gets how often the event has been raised.
    /// </summary>
    public long Counter { get; set; }

    /// <summary>
    ///     Gets the time that elapsed since the ScotecTimer was started.
    /// </summary>
    public long Elapsed { get; set; }

    /// <summary>
    ///     Gets the time it took the previous event to execute.
    /// </summary>
    public long ExecutionTime { get; set; }

    /// <summary>
    ///     Gets the time that elapsed since the event should have been raised.
    /// </summary>
    public long Offset { get; set; }

    /// <summary>
    ///     Time of the privious event.
    /// </summary>
    public long LastTime { get; set; }
}
