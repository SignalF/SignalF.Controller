//#define USE_DATETIME

#region

using System.Diagnostics;

#endregion

namespace SignalF.Controller;

public class ScotecStopwatch : Stopwatch
{
    private readonly long _nanosecondsPerTick = 1_000_000_000L / Frequency;

    /// <summary>
    ///     Gets the total elapsed time measured by the current instance, in nanoseconds
    /// </summary>
    public ScotecStopwatch()
    {
        Console.WriteLine("Frequency:" + Frequency);
        Console.WriteLine("Accuracy:" + _nanosecondsPerTick + " nanoseconds");

        if (!IsHighResolution)
        {
            throw new Exception("High resolution time is not available");
        }
    }

#if USE_DATETIME
    public long Ticks => DateTime.UtcNow.Ticks;
#else
    public long Ticks => GetTimestamp();
#endif
}
