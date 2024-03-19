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
    private volatile double[] _readValues;
    private int[] _signalReadIndexes;

    private int[] _signalWriteIndexes;
    private int _writeSignalCount;

    private volatile double[] _writeValues;

    public ProcessControlAdapter(ISignalHub signalHub, ILogger<ProcessControlAdapter> logger)
        : base(signalHub, logger)
    {
    }

    /// <inheritdoc />
    public override void Execute(ETaskType taskType)
    {
        switch (taskType)
        {
            case ETaskType.Read:
            {
                Timestamp = SignalHub.Timestamp;
                var atomicRead = Enumerable.Repeat(double.NaN, _readSignalCount).ToArray(); //new double[_readSignalCount];

                for (var i = 0; i < _readSignalCount; i++)
                {
                    atomicRead[i] = SignalHub.GetSignal(_signalReadIndexes[i]).Value;
                }

                _readValues = atomicRead;
                break;
            }

            case ETaskType.Write:
            {
                var timestamp = SignalHub.GetTimestamp();
                var atomicWrite = _writeValues;

                for (var i = 0; i < _writeSignalCount; i++)
                {
                    SignalHub.SetSignal(new Signal(_signalWriteIndexes[i], atomicWrite[i], timestamp));
                }

                break;
            }
        }
    }

    /// <inheritdoc />
    public double[] ReadValues()
    {
        var values = new double[_readSignalCount];
        Array.Copy(_readValues, values, _readSignalCount);

        return values;
    }

    /// <inheritdoc />
    public void WriteValues(double[] values)
    {
        if (values.Length != _writeSignalCount)
        {
            throw new ArgumentException($"Length of values array must match the write signal count. Length: {values.Length}, expected: {_writeSignalCount}");
        }

        var buffer = new double[_writeSignalCount];
        Array.Copy(_writeValues, buffer, _writeSignalCount);

        _writeValues = buffer;
    }

    /// <inheritdoc />
    public double GetValue(string signalName)
    {
        if (_configured)
        {
            return _indexNameMapping.TryGetValue(signalName, out var index)
                ? _readValues[index]
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
            if (_indexNameMapping.TryGetValue(signalName, out var index))
            {
                _writeValues[index] = value;
            }

            return;
        }

        Logger.LogWarning("No signals in ProcessControlAdapter configured! Check provided configuration!");
    }

    public long Timestamp { get; private set; }

    protected override void OnConfigure(IProcessControlConfiguration configuration)
    {
        base.OnConfigure(configuration);

        _readSignalCount = configuration.SignalSinks.Count;
        _writeSignalCount = configuration.SignalSources.Count;

        _indexNameMapping = new Dictionary<string, int>();

        _signalReadIndexes = new int[_readSignalCount];
        _signalWriteIndexes = new int[_writeSignalCount];

        // get all SignalSinks and map index to name
        for (var i = 0; i < _readSignalCount; i++)
        {
            var index = SignalHub.GetSignalIndex(configuration.SignalSinks[i]);
            _indexNameMapping.Add(configuration.SignalSinks[i].Name, i);

            _signalReadIndexes[i] = index;
        }

        // get all SignalSources and map index to name
        for (var i = 0; i < _writeSignalCount; i++)
        {
            var index = SignalHub.GetSignalIndex(configuration.SignalSources[i]);
            _indexNameMapping.Add(configuration.SignalSources[i].Name, i);

            _signalWriteIndexes[i] = index;
        }

        // Initialize all values with NaN.
        _writeValues = new double[_writeSignalCount];
        Array.Fill(_writeValues, double.NaN);

        _readValues = new double[_readSignalCount];
        Array.Fill(_readValues, double.NaN);

        _configured = true;
    }
}
