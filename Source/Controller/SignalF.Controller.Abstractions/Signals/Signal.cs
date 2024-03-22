namespace SignalF.Controller.Signals;

public readonly record struct Signal
{
    public Signal(int signalIndex, double value, long? timestamp)
    {
        SignalIndex = signalIndex;
        Value = value;
        Timestamp = timestamp;
    }
    
    public Signal(int signalIndex) : this(signalIndex, double.NaN, null)
    {
    }

    public Signal() : this(-1, double.NaN, null)
    {
    }

    public int SignalIndex { get; }
    public double Value { get; init; }
    public long? Timestamp { get; init; }

    public void Deconstruct(out int signalIndex, out double value, out long? timestamp)
    {
        signalIndex = SignalIndex;
        value = Value;
        timestamp = Timestamp;
    }
}
