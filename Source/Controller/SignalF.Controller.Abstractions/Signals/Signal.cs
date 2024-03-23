using System;
using Iot.Device.Bno055;
using Scotec.Math.Units;
using System.Runtime.CompilerServices;
using static System.Runtime.InteropServices.JavaScript.JSType;

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

public static class SignalExtensions
{
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static void AssignWith(this ref Signal signal, double value, long timestamp)
    {
        signal = signal with { Value = value, Timestamp = timestamp };
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static void AssignWith(this ref Signal to, Signal from)
    {
        to = to with { Value = from.Value, Timestamp = from.Timestamp };
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static void AssignWith(this Span<Signal> to, Span<Signal> from)
    {
        var length = to.Length;
        if (from.Length != length)
        {
            throw new ControllerException("Spans must have same size.");
        }

        for (var i = 0; i < length; i++)
        {
            to[i].AssignWith(from[i]);
        }
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static void AssignWith(this Span<Signal> to, ReadOnlySpan<Signal> from)
    {
        var length = to.Length;
        if (from.Length != length)
        {
            throw new ControllerException("Spans must have same size.");
        }
        for (var i = 0; i < length; i++)
        {
            to[i].AssignWith(from[i]);
        }
    }
}
