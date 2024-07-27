#region

using Scotec.Queues;
using SignalF.Controller.Signals;
using SignalF.Datamodel.DataOutput;

#endregion

namespace SignalF.Controller.DataOutput;

public class DataOutput : IDataOutput
{
    private readonly IDataOutputSenderFactory _dataOutputSenderFactory;
    private readonly ISignalDispatcher _dispatcher;

    private readonly TaskQueue<Signal[]> _queue;
    private readonly ISignalHub _signalHub;
    private IDataOutputFilter _filter;

    private List<IDataOutputSender> _senders;
    private int[] _signalIndexes;

    public DataOutput(ISignalDispatcher dispatcher, IDataOutputSenderFactory dataOutputSenderFactory, ISignalHub signalHub)
    {
        _dispatcher = dispatcher;
        _dataOutputSenderFactory = dataOutputSenderFactory;
        _signalHub = signalHub;
        _queue = new TaskQueue<Signal[]>(ProcessValues);
    }

    public Guid Id { get; private set; }

    public string Name { get; private set; }

    public void Configure(IDataOutputConfiguration configuration)
    {
        Id = configuration.Id;
        Name = configuration.Name;

        _senders = configuration.DataOutputSenders.Select(senderConfiguration => _dataOutputSenderFactory.FindDataOutputSender(senderConfiguration.Id))
                                .ToList();

        //TODO: Keep signal sources and create a mapping to signal index.
        //      This provides the possibility to send the signal name or signal ID to the DataOutputSender.
        _signalIndexes = configuration.SignalSources.Select(_signalHub.GetSignalIndex).ToArray();

        _dispatcher.Dispatch += OnDispatch;
    }

    public void Stop()
    {
        _filter.FilterAbort -= OnFilterAbort;
        _filter = null;
        _queue.Stop();
        _senders.ForEach(sender => sender.Stop());
    }

    public void SetFilter()
    {
        SetFilter(long.MaxValue, Timeout.InfiniteTimeSpan);
    }

    public void SetFilter(long cycleAmount)
    {
        SetFilter(cycleAmount, Timeout.InfiniteTimeSpan);
    }

    public void SetFilter(TimeSpan duration)
    {
        SetFilter(long.MaxValue, duration);
    }

    private void SetFilter(long cycleAmount, TimeSpan duration)
    {
        DateTime finishedTime;

        if (duration == Timeout.InfiniteTimeSpan)
        {
            finishedTime = DateTime.MaxValue;
        }
        else
        {
            finishedTime = DateTime.UtcNow + duration;
        }

        _senders.ForEach(sender => sender.Start());

        _filter = new DataOutputFilter(_signalIndexes, cycleAmount, finishedTime);
        _filter.FilterAbort += OnFilterAbort;
        //TODO: Check if we can use higher priority.
        _queue.Start(ThreadPriority.BelowNormal);
    }

    private void OnFilterAbort(object sender, EventArgs e)
    {
        Stop();
    }

    private void OnDispatch(object sender, DispatcherEventArgs e)
    {
        _queue.Enqueue(e.Values);
    }

    private void ProcessValues(Signal[] values)
    {
        var filteredValues = _filter?.Invoke(values);

        if (filteredValues != null)
        {
            _senders.ForEach(s => s.SendValues(filteredValues));
        }
    }
}
