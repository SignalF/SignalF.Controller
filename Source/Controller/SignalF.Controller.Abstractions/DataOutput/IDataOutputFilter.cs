#region

using SignalF.Controller.Signals;

#endregion

namespace SignalF.Controller.DataOutput;

public interface IDataOutputFilter
{
    /// <summary>
    ///     Signals that the filter is finished.
    /// </summary>
    event EventHandler FilterAbort;

    /// <summary>
    ///     Invokes the filter.
    /// </summary>
    /// <param name="values">The values to pass through the filter.</param>
    /// <returns>The filtered values or null.</returns>
    Signal[] Invoke(Signal[] values);
}
