#region

using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using SignalF.Datamodel.Configuration;
using SignalF.Datamodel.Signals;

#endregion

namespace SignalF.Controller.Signals.SignalProcessor;

public abstract class SignalProcessor<TConfiguration> : ISignalProcessor
    where TConfiguration : ISignalProcessorConfiguration
{
    private int _readSignalCount;
    private int[] _readSignals;
    private int _writeSignalCount;
    private int[] _writeSignals;

    protected SignalProcessor(ISignalHub signalHub, ILogger<SignalProcessor<TConfiguration>> logger)
    {
        Logger = logger;
        SignalHub = signalHub;
    }

    /// <summary>
    ///     Mappings from signal definition name to signal index. The dictionary only contains the names of signal definitions
    ///     that are actually used in the current device instance. This is always the case if a corresponding signal source or
    ///     signal sink has been configured for the device.
    /// </summary>
    protected IDictionary<string, int> SignalNameToIndexMapping { get; } = new Dictionary<string, int>();

    /// <summary>
    ///     Configuration data provided by the signal processor configuration (template, definition, configuration).
    /// </summary>
    protected IConfigurationRoot ConfigurationData { get; private set; }

    protected ILogger Logger { get; }

    protected ISignalHub SignalHub { get; }

    /// <inheritdoc />
    public Guid Id { get; private set; }

    /// <inheritdoc />
    public string Name { get; private set; }

    /// <inheritdoc />
    public void Configure(ISignalProcessorConfiguration configuration)
    {
        Id = configuration.Id;
        Name = configuration.Name;

        ReadConfigurationData(configuration);
        OnConfigure((TConfiguration)configuration);
    }

    public abstract void Execute(ETaskType taskType);

    private void ReadConfigurationData(ISignalProcessorConfiguration configuration)
    {
        var templateConfig = configuration.Definition.Template.Configuration.Data;
        var definitionConfig = configuration.Definition.Configuration.Data;
        var configurationConfig = configuration.Configuration.Data;

        using var stream1 = new MemoryStream(Encoding.ASCII.GetBytes(CheckJson(templateConfig)));
        using var stream2 = new MemoryStream(Encoding.ASCII.GetBytes(CheckJson(definitionConfig)));
        using var stream3 = new MemoryStream(Encoding.ASCII.GetBytes(CheckJson(configurationConfig)));

        var builder = new ConfigurationBuilder()
                      .AddJsonStream(stream1)
                      .AddJsonStream(stream2)
                      .AddJsonStream(stream3);
        ConfigurationData = builder.Build();
        return;
        //Test
        //var data = ConfigurationData.GetSection("name");

        string CheckJson(string json)
        {
            const string emptyJson = "{}";
            return string.IsNullOrWhiteSpace(json) ? emptyJson : json;
        }
    }

//    protected abstract void DoConfigure(TConfiguration configuration);
    protected virtual void OnConfigure(TConfiguration configuration)
    {
        _readSignalCount = configuration.SignalSinks.Count;
        _writeSignalCount = configuration.SignalSources.Count;

        _readSignals = new int[_readSignalCount];
        _writeSignals = new int[_writeSignalCount];

        // get all SignalSinks and map index to name
        for (var i = 0; i < _readSignalCount; i++)
        {
            var index = SignalHub.GetSignalIndex(configuration.SignalSinks[i]);
            SignalNameToIndexMapping.Add(configuration.SignalSinks[i].Definition.Name, i);
            _readSignals[i] = index;
        }

        // get all SignalSources and map index to name
        for (var i = 0; i < _writeSignalCount; i++)
        {
            var index = SignalHub.GetSignalIndex(configuration.SignalSources[i]);
            SignalNameToIndexMapping.Add(configuration.SignalSources[i].Definition.Name, i);
            _writeSignals[i] = index;
        }
    }

    protected Signal ReadSignal(int index)
    {
        return SignalHub.GetSignal(_readSignals[index]);
    }

    protected void WriteSignal(Signal signal)
    {
        SignalHub.SetSignal(signal);
    }
}
