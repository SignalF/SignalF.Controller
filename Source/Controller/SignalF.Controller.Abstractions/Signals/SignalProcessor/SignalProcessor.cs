#region

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
    private int _signalSinkCount;
    private Signal[] _signalSinks;
    private int _signalSourceCount;
    private Signal[] _signalSources;

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

    /// <summary>
    ///     Get access to the logger.
    /// </summary>
    protected ILogger Logger { get; }

    /// <summary>
    ///     Get access tothe signal hub.
    /// </summary>
    protected ISignalHub SignalHub { get; }

    protected ReadOnlySpan<Signal> SignalSinks => new(_signalSinks);

    protected Span<Signal> SignalSources => new(_signalSources);

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

        _signalSinkCount = configuration.SignalSinks.Count;
        _signalSourceCount = configuration.SignalSources.Count;

        _signalSinks = new Signal[_signalSinkCount];
        _signalSources = new Signal[_signalSourceCount];

        // get all SignalSinks and map index to name
        for (var i = 0; i < _signalSinkCount; i++)
        {
            var signalIndex = SignalHub.GetSignalIndex(configuration.SignalSinks[i]);
            SignalNameToIndexMapping.Add(configuration.SignalSinks[i].Definition.Name, i);
            _signalSinks[i] = new Signal(signalIndex);
        }

        // get all SignalSources and map index to name
        for (var i = 0; i < _signalSourceCount; i++)
        {
            var signalIndex = SignalHub.GetSignalIndex(configuration.SignalSources[i]);
            SignalNameToIndexMapping.Add(configuration.SignalSources[i].Definition.Name, i);
            _signalSources[i] = new Signal(signalIndex);
        }

        OnConfigure((TConfiguration)configuration);
    }

    public virtual void Execute(ETaskType taskType)
    {
        switch (taskType)
        {
            case ETaskType.Init:
                Initialize();
                break;
            case ETaskType.Read:
                Read();
                break;
            case ETaskType.Write:
                Write();
                break;
            case ETaskType.Calculate:
                Calculate();
                break;
            case ETaskType.Exit:
                Exit();
                break;
            default:
                throw new ControllerException($"Invalid task type '{taskType}'.");
        }
    }

    private void Initialize()
    {
        OnInitialize();

        SignalHub.WriteSignals(new ReadOnlySpan<Signal>(_signalSources));
    }

    private void Read()
    {
        SignalHub.ReadSignals(new Span<Signal>(_signalSinks));

        OnRead();
    }

    private void Write()
    {
        OnWrite();

        SignalHub.WriteSignals(new ReadOnlySpan<Signal>(_signalSources));
    }

    private void Calculate()
    {
        OnCalculate();
    }

    private void Exit()
    {
        OnExit();
    }

    protected virtual void OnInitialize()
    {
    }

    protected virtual void OnRead()
    {
    }

    protected virtual void OnWrite()
    {
    }

    protected virtual void OnCalculate()
    {
    }

    protected virtual void OnExit()
    {
    }

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

    protected virtual void OnConfigure(TConfiguration configuration)
    {
    }

    /// <summary>
    ///     Gets the signal processor specific index of the requested signal.
    ///     <remarks>This is not the signal index within the signal hub.</remarks>
    /// </summary>
    //protected int GetSignalIndex(string signalName)
    //{
    //    return SignalNameToIndexMapping[signalName];
    //}
    protected int GetSignalIndex(ISignalEndpointConfiguration endPoint)
    {
        return SignalNameToIndexMapping[endPoint.Definition.Name];
    }
}
