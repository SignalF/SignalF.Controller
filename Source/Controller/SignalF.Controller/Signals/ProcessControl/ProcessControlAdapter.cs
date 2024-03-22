#region

using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Extensions.Logging;
using SignalF.Controller.Signals.SignalProcessor;
using SignalF.Datamodel.Configuration;
using SignalF.Datamodel.Workflow;

#endregion

namespace SignalF.Controller.Signals.ProcessControl;

public class ProcessControlAdapter : SignalProcessor<IProcessControlConfiguration>, IProcessControlAdapter
{
    private bool _configured;

    private Dictionary<string, int> _indexNameMapping;
    private int _readSignalCount;
    private volatile Signal[] _readValues;

    private int _writeSignalCount;

    private volatile Signal[] _writeValues;

    public ProcessControlAdapter(ISignalHub signalHub, ILogger<ProcessControlAdapter> logger)
        : base(signalHub, logger)
    {
    }

    protected override void OnRead()
    {
        _readValues = SignalSinks.ToArray();
    }

    protected override void OnWrite()
    {
        _writeValues.CopyTo(SignalSources);
    }


    /// <inheritdoc />
    public ReadOnlySpan<Signal> ReadValues()
    {
        return _readValues;
    }

    /// <inheritdoc />
    public void WriteValues(ReadOnlySpan<Signal> signals)
    {
        if (signals.Length != _writeSignalCount)
        {
            throw new ArgumentException($"Length of values array must match the write signal count. Length: {signals.Length}, expected: {_writeSignalCount}");
        }

        var buffer = new Signal[_writeSignalCount];

        var spanBuffer = new Span<Signal>(buffer);
        signals.CopyTo(spanBuffer);

        _writeValues = buffer;
    }

    /// <inheritdoc />
    public Signal GetValue(string signalName)
    {
        if (_configured)
        {
            return _indexNameMapping.TryGetValue(signalName, out var index)
                ? _readValues[index]
                : new Signal(-1);
        }

        Logger.LogWarning("No signals in ProcessControlAdapter configured! Check provided configuration!");
        return new Signal(-1);
    }

    /// <inheritdoc />
    public void SetValue(string signalName, double value, long? timestamp)
    {
        if (_configured)
        {
            if (_indexNameMapping.TryGetValue(signalName, out var index))
            {
                _writeValues[index] = _writeValues[index] with{Value = value, Timestamp = timestamp ??SignalHub.GetTimestamp()};
            }

            return;
        }

        Logger.LogWarning("No signals in ProcessControlAdapter configured! Check provided configuration!");
    }

    public long Timestamp => SignalHub.GetTimestamp();

    protected override void OnConfigure(IProcessControlConfiguration configuration)
    {
        base.OnConfigure(configuration);

        int readSignalCount = configuration.SignalSinks.Count;
        int writeSignalCount = configuration.SignalSources.Count;

        _indexNameMapping = new Dictionary<string, int>();

        // get all SignalSinks and map index to name
        for (var i = 0; i < readSignalCount; i++)
        {
            _indexNameMapping.Add(configuration.SignalSinks[i].Name, GetSignalIndex(configuration.SignalSinks[i].Name));
        }

        // get all SignalSources and map index to name
        for (var i = 0; i < writeSignalCount; i++)
        {
            _indexNameMapping.Add(configuration.SignalSources[i].Name, GetSignalIndex(configuration.SignalSources[i].Name));
        }

        _configured = true;
    }
}
