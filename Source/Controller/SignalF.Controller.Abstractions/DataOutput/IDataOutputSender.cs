#region

using System;
using SignalF.Controller.Signals;
using SignalF.Datamodel.DataOutput;

#endregion

namespace SignalF.Controller.DataOutput;

public interface IDataOutputSender
{
    /// <summary>
    ///     The ID of the DataOutputSender
    /// </summary>
    Guid Id { get; }

    /// <summary>
    ///     The name of the DataOutputSender
    /// </summary>
    string Name { get; }

    /// <summary>
    ///     Configures the DataOutput.
    /// </summary>
    /// <param name="configuration"></param>
    void Configure(IDataOutputSenderConfiguration configuration);

    /// <summary>
    ///     Sends given values.
    /// </summary>
    /// <param name="values">The values to send</param>
    void SendValues(Signal[] values);

    /// <summary>
    ///     Starts sending values.
    /// </summary>
    void Start();

    /// <summary>
    ///     Stops sending values.
    /// </summary>
    void Stop();
}
