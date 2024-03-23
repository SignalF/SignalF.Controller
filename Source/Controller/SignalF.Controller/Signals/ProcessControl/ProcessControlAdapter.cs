#region

using System;
using System.Collections.Generic;
using Microsoft.Extensions.Logging;
using SignalF.Controller.Signals.SignalProcessor;
using SignalF.Datamodel.Workflow;

#endregion

namespace SignalF.Controller.Signals.ProcessControl;

public class ProcessControlAdapter : SignalProcessor<IProcessControlConfiguration>, IProcessControlAdapter
{
    private bool _configured;

    private Dictionary<string, int> _indexNameMapping;
    private volatile Signal[] _readValues;
    private volatile Signal[] _writeValues;

    public ProcessControlAdapter(ISignalHub signalHub, ILogger<ProcessControlAdapter> logger)
        : base(signalHub, logger)
    {
    }

    /// <inheritdoc />
    public ReadOnlySpan<Signal> ReadValues()
    {
        return _readValues;
    }

    /// <inheritdoc />
    public void WriteValues(ReadOnlySpan<Signal> signals)
    {
        var length = _writeValues.Length;
        if (signals.Length != length)
        {
            throw new ArgumentException($"Length of values array must match the write signal count. Length: {signals.Length}, expected: {length}");
        }

        var buffer = new Signal[length];

        var spanBuffer = new Span<Signal>(buffer);
        signals.CopyTo(spanBuffer);

        _writeValues = buffer;
    }

    /// <inheritdoc />
    public double GetValue(string signalName)
    {
        if (_configured)
        {
            return _indexNameMapping.TryGetValue(signalName, out var index)
                ? _readValues[index].Value
                : double.NaN;
        }

        Logger.LogWarning("No signals in ProcessControlAdapter configured! Check provided configuration!");
        return double.NaN;
    }

    /// <inheritdoc />
    public void SetValue(string signalName, double value)
    {
        if (_configured)
        {
            var timestamp = SignalHub.GetTimestamp();
            if (_indexNameMapping.TryGetValue(signalName, out var index))
            {
                _writeValues[index].AssignWith(value, timestamp);
            }

            return;
        }

        Logger.LogWarning("No signals in ProcessControlAdapter configured! Check provided configuration!");
    }

    public long Timestamp => SignalHub.GetTimestamp();

    protected override void OnRead()
    {
        _readValues = SignalSinks.ToArray();
    }

    protected override void OnWrite()
    {
        SignalSources.AssignWith(_writeValues);
    }

    protected override void OnConfigure(IProcessControlConfiguration configuration)
    {
        base.OnConfigure(configuration);

        var readSignalCount = configuration.SignalSinks.Count;
        var writeSignalCount = configuration.SignalSources.Count;

        _readValues = SignalSinks.ToArray();
        _writeValues = SignalSources.ToArray();

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
