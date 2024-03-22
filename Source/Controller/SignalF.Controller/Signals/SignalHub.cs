#region

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using Microsoft.Extensions.Logging;
using Scotec.RingBuffer;
using SignalF.Datamodel.Configuration;
using SignalF.Datamodel.Signals;

#endregion

namespace SignalF.Controller.Signals;

public class SignalHub : ISignalHub
{
    private readonly AutoResetEvent _dateAvailableEvent;
    private readonly ILogger<SignalHub> _logger;
    private RingBuffer<Signal> _buffer;
    private Thread _dataAvailableWatcher;
    private bool _isStopping;
    private int _numberOfValues;
    private Signal[] _signals;

    private Signal[] _updatedSignalValues;
    private int _updatedSignalValuesPointer;

    public SignalHub(ILogger<SignalHub> logger)
    {
        _logger = logger;
        _dateAvailableEvent = new AutoResetEvent(false);
    }

    /// <inheritdoc />
    public Dictionary<Guid, int> SignalIndexes { get; private set; }

    /// <inheritdoc />
    public event EventHandler DataAvailable;

    /// <inheritdoc />
    public Signal ReadSignal(int index)
    {
        return _signals[index];
    }

    /// <inheritdoc />
    public void ReadSignals(Span<Signal> signals)
    {
        //var signalValues = _signals.AsSpan();
        var length = signals.Length;
        for (var i = 0; i < length; i++)
        {
            //var signal = signals[i];
            //signal.Value = signalValues[signal.SignalIndex];
            //signalValues[signal.SignalIndex] = signal.Value;
            //signals[i] = signal;
            var signalIndex = signals[i].SignalIndex;
            signals[i] = _signals[signalIndex];
        }
    }

    /// <inheritdoc />
    public void WriteSignal(Signal signal)
    {
        _signals[signal.SignalIndex] = signal;

        UpdateSignalValue(signal);
    }

    /// <inheritdoc />
    public void WriteSignals(ReadOnlySpan<Signal> signals)
    {
        var signalValues = _signals.AsSpan();
        var length = signals.Length;
        for (var i = 0; i < length; i++)
        {
            var signal = signals[i];
            signalValues[signal.SignalIndex] = signal;
        }
    }

    /// <inheritdoc />
    public void Configure(IControllerConfiguration configuration)
    {
        var signalSources = configuration.SignalProcessorConfigurations.SelectMany(signalProcessorConfiguration => signalProcessorConfiguration.SignalSources);

        AddSignalSources(signalSources);

        //TODO: Get buffer size from configuration. This can be either the controller configuration or the app.config 
        _buffer = new RingBuffer<Signal>(1_000_000);
    }

    /// <inheritdoc />
    public int GetSignalIndex(ISignalEndpointConfiguration endpoint)
    {
        if (endpoint is ISignalSourceConfiguration configuration)
        {
            return GetSignalIndex(configuration);
        }

        return GetSignalIndex((ISignalSinkConfiguration)endpoint);
    }

    /// <inheritdoc />
    public int GetSignalIndex(ISignalSourceConfiguration signalSource)
    {
        return SignalIndexes[signalSource.Id];
    }

    /// <inheritdoc />
    public int GetSignalIndex(ISignalSinkConfiguration signalSink)
    {
        var signalSource = signalSink.GetReverseLink<ISignalConnection>()?.SignalSource;

        return signalSource != null ? SignalIndexes[signalSource.Id] : -1;
    }

    /// <inheritdoc />
    public void NewCycle()
    {
        // We do not write data to the ring buffer, if nothing has changed.
        // TODO: Make this configurable. We might want to send the timestamps periodically even if no data have changed.
        if (_updatedSignalValuesPointer == 0)
        {
            return;
        }

        // Set the timestamp at the end of the cycle so we have the most accurate time.
        _updatedSignalValues[0] = new Signal(-1, Timestamp, Timestamp);
        _buffer.Write(_updatedSignalValues, _updatedSignalValuesPointer + 1);
        _updatedSignalValuesPointer = 0;

        _dateAvailableEvent.Set();
    }

    /// <inheritdoc />
    public Signal[] GetCurrentBufferContent()
    {
        return _buffer.Read();
    }

    /// <inheritdoc />
    public Signal[] GetCurrentSignals()
    {
        // Add one additional signal for the timestamp. This will be hold in the first item of the array.
        // Timestamps always have an index of -1.
        var result = new Signal[_numberOfValues + 1];
        var timestamp = GetTimestamp();
        result[0] = new Signal(-1, timestamp, timestamp);

        for (var index = 0; index < _numberOfValues; ++index)
        {
            result[index + 1] = _signals[index];
        }

        return result;
    }

    public long Timestamp { get; set; }

    public void Initialize()
    {
    }

    /// <inheritdoc />
    public void Run()
    {
        _isStopping = false;
        _dataAvailableWatcher = new Thread(DataAvailableWatcher);
        _dataAvailableWatcher.Start();
    }

    /// <inheritdoc />
    public void Shutdown()
    {
        _isStopping = true;
        _dateAvailableEvent.Set();
        _dataAvailableWatcher.Join();
    }

    public long GetTimestamp()
    {
        return DateTime.UtcNow.Ticks;
    }

    private void AddSignalSources(IEnumerable<ISignalSourceConfiguration> signalSources)
    {
        SignalIndexes = signalSources.Select((item, index) => new { item, index })
                                     .ToDictionary(pair => pair.item.Id, pair => pair.index);

        _numberOfValues = SignalIndexes.Count;

        _signals = new Signal[_numberOfValues];
        _updatedSignalValues = new Signal[_numberOfValues + 1]; // plus 1 for the timestamp
    }

    private void UpdateSignalValue(Signal signal)
    {
        _updatedSignalValues[++_updatedSignalValuesPointer] = signal;
    }

    private void DataAvailableWatcher()
    {
        while (!_isStopping)
        {
            _dateAvailableEvent.WaitOne();

            if (_isStopping)
            {
                return;
            }

            DataAvailable?.Invoke(this, EventArgs.Empty);
        }
    }
}
