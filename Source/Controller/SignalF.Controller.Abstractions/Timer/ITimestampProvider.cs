namespace SignalF.Controller.Timer;

public interface ITimestampProvider
{
    long Timestamp { get; }

    void Start();

    void Stop();
}
