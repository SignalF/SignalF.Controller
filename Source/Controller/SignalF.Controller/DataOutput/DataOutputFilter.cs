#region

using System;
using System.Linq;
using SignalF.Controller.Signals;

#endregion

namespace SignalF.Controller.DataOutput;

public class DataOutputFilter : IDataOutputFilter
{
    private readonly long _cycleAmount;
    private readonly DateTime _finishTime;
    private readonly int[] _signalIndexes;

    private long _cycleCounter;

    public DataOutputFilter(int[] signalIndexes, long cycleAmount, DateTime finishTime)
    {
        _signalIndexes = signalIndexes;
        _cycleAmount = cycleAmount;
        _finishTime = finishTime;
    }

    public event EventHandler FilterAbort;

    public Signal[] Invoke(Signal[] values)
    {
        if (++_cycleCounter <= _cycleAmount && DateTime.Now <= _finishTime)
        {
            return values.Where(pair => pair.SignalIndex == -1 || _signalIndexes.Contains(pair.SignalIndex)).ToArray();
        }

        FilterAbort?.Invoke(this, EventArgs.Empty);
        return null;
    }
}
