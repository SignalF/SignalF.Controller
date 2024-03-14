#region

using System;
using System.Threading;
using System.Threading.Tasks;
using Scotec.Queues;
using SignalF.Controller.Signals;
using SignalF.Datamodel.DataOutput;

#endregion

namespace SignalF.Controller.DataOutput;

public abstract class DataOutputSender : IDataOutputSender
{
    protected readonly TaskQueue<Signal[]> Queue;
    protected readonly ISignalHub SignalHub;

    protected bool FirstValue;

    protected DataOutputSender(ISignalHub signalHub)
    {
        SignalHub = signalHub;
        FirstValue = true;

        Queue = new TaskQueue<Signal[]>(signals => { ProcessValuesAsync(signals).Wait(); });
    }

    /// <inheritdoc />
    public Guid Id { get; private set; }

    /// <inheritdoc />
    public string Name { get; private set; }

    /// <inheritdoc />
    public void Configure(IDataOutputSenderConfiguration configuration)
    {
        Id = configuration.Id;
        Name = configuration.Name;

        DoConfigure(configuration);
    }

    /// <inheritdoc />
    public abstract void SendValues(Signal[] values);

    /// <inheritdoc />
    public void Start()
    {
        Queue.Start(ThreadPriority.BelowNormal);
    }

    /// <inheritdoc />
    public void Stop()
    {
        Queue.Stop();
    }

    protected abstract void DoConfigure(IDataOutputSenderConfiguration configuration);

    protected abstract Task ProcessValuesAsync(Signal[] values);
}
