#region

using Scotec.Queues;
using Scotec.XMLDatabase;
using SignalF.Controller.Signals;
using SignalF.Datamodel.DataOutput;
using SignalF.Datamodel.Signals;

#endregion

namespace SignalF.Controller.DataOutput;

public abstract class DataOutputSender : IDataOutputSender
{
    protected readonly TaskQueue<Signal[]> Queue;
    protected readonly ISignalHub SignalHub;
    private Dictionary<int, string> _indexToSignalNameMapping;

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
        BuildIndexToSignalNameMapping(configuration);
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

    private void BuildIndexToSignalNameMapping(IDataOutputSenderConfiguration configuration)
    {
        var dataOutputs = configuration.GetReverseLinks<IDataOutputConfiguration>(ESearchType.Deep);
        _indexToSignalNameMapping = dataOutputs.SelectMany(output => output.SignalSources)
                                               .Distinct()
                                               .ToDictionary(item => SignalHub.GetSignalIndex(item), BuildSignalName);
        ;

        return;

        static string BuildSignalName(ISignalSourceConfiguration signalSource)
        {
            var signalProcessor = signalSource.FindParent<ISignalProcessorConfiguration>();
            return $"{signalProcessor.Name}.{signalSource.Name}";
        }
    }

    protected abstract void DoConfigure(IDataOutputSenderConfiguration configuration);

    protected abstract Task ProcessValuesAsync(Signal[] values);

    protected string GetSignalNameFromIndex(int index)
    {
        return _indexToSignalNameMapping[index];
    }
}
