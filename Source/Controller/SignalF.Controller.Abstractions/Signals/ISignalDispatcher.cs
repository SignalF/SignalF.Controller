#region

/* Unmerged change from project 'SignalF.Controller.Abstractions (netstandard2.0)'
Before:
using System;
After:
using System;
using Scotec;
using SignalF;
using SignalF.Controller;
using SignalF.Controller.Signals;
using SignalF.Controller.Signals;
using SignalF.Controller.Signals.SignalProcessor;
*/
#endregion

namespace SignalF.Controller.Signals;

public interface ISignalDispatcher : IService
{
    /// <summary>
    ///     Occurs when new values are available for processing
    /// </summary>
    event EventHandler<DispatcherEventArgs> Dispatch;
}

public class DispatcherEventArgs : EventArgs
{
    public DispatcherEventArgs(Signal[] values)
    {
        Values = values;
    }

    public Signal[] Values { get; }
}
