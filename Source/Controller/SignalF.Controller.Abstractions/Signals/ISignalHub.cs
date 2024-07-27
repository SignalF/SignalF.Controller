﻿#region

using SignalF.Datamodel.Configuration;
using SignalF.Datamodel.Signals;

/* Unmerged change from project 'SignalF.Controller.Abstractions (netstandard2.0)'
Before:
using SignalF.Datamodel.Configuration;
After:
using Scotec;
using SignalF;
using SignalF.Controller;
using SignalF.Controller.Signals;
using SignalF.Controller.Signals;
using SignalF.Controller.Signals.SignalProcessor;
using SignalF.Datamodel.Configuration;
*/

#endregion

namespace SignalF.Controller.Signals;

public interface ISignalHub : IService
{
    /// <summary>
    ///     Contains the Guid of a Signal with its assigned Index
    /// </summary>
    Dictionary<Guid, int> SignalIndexes { get; }

    /// <summary>
    ///     Gets or sets the timestamp of the current cycle.
    /// </summary>
    long Timestamp { get; set; }

    /// <summary>
    ///     Returns the current timestamp.
    /// </summary>
    long GetTimestamp();

    /// <summary>
    ///     Fires when new data is available in the buffer.
    /// </summary>
    event EventHandler DataAvailable;

    /// <summary>
    ///     Gets a signal from the hub.
    /// </summary>
    /// <param name="index">Index of signal to return</param>
    /// <returns>Requested signal</returns>
    Signal ReadSignal(int index);

    /// <summary>
    ///     Gets signals from the hub.
    /// </summary>
    /// <param name="signals">Signals to read.</param>
    /// <returns>Requested signals</returns>
    void ReadSignals(Span<Signal> signals);

    /// <summary>
    ///     Writes a signal to the hub.
    /// </summary>
    void WriteSignal(Signal signal);

    /// <summary>
    ///     Writes signals to the hub.
    /// </summary>
    /// <param name="signals">The signals to write.</param>
    void WriteSignals(ReadOnlySpan<Signal> signals);

    /// <summary>
    ///     Configures SignalHub with given configuration
    /// </summary>
    /// <param name="configuration">Configuration to configure SignalHub with</param>
    void Configure(IControllerConfiguration configuration);

    /// <summary>
    ///     Returns the index for the given signal source.
    /// </summary>
    /// <param name="signalSource">The signal source to get index for.</param>
    /// <returns>Index of the Signal with given ID</returns>
    int GetSignalIndex(ISignalSourceConfiguration signalSource);

    /// <summary>
    ///     Returns the index for the given signal sink
    /// </summary>
    /// <param name="signalSink">The signal sink to get index for.</param>
    /// <returns>Index of the signal with given ID  or -1 if the signal is not connected to a signal source.</returns>
    int GetSignalIndex(ISignalSinkConfiguration signalSink);

    /// <summary>
    ///     Returns the index for the given signal endpoint
    /// </summary>
    /// <param name="endpoint">The signal endpoint to get index for.</param>
    /// <returns>Index of the Signal with given ID or -1 if the endpoint is an unconnected signal sink.</returns>
    int GetSignalIndex(ISignalEndpointConfiguration endpoint);

    /// <summary>
    ///     Adds current timestamp to data and writes it into buffer
    /// </summary>
    void NewCycle();

    /// <summary>
    ///     Reads out new values in buffer since last readout
    /// </summary>
    /// <returns>Content in buffer since last readout</returns>
    Signal[] GetCurrentBufferContent();

    /// <summary>
    ///     Returns all current signals.
    /// </summary>
    /// <returns>The current signals.</returns>
    Signal[] GetCurrentSignals();
}
