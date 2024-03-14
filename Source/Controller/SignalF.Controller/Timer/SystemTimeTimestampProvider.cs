using System;

namespace SignalF.Controller.Timer;

public class SystemTimeTimestampProvider : ITimestampProvider
{
    public long Timestamp => DateTime.UtcNow.Ticks;

    public void Start()
    {
    }

    public void Stop()
    {
    }
}
