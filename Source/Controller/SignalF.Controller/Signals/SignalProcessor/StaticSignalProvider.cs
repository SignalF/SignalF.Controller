#region

using System.Linq;
using Microsoft.Extensions.Logging;
using SignalF.Datamodel.Configuration;
using SignalF.Datamodel.Signals;

#endregion

namespace SignalF.Controller.Signals.SignalProcessor;

// TODO: This is a specialization of a signal process and should not be part of the controller. Move it to another project.
public class StaticSignalProvider : SignalProcessor<IStaticSignalProviderConfiguration>, IStaticSignalProvider
{
    private int[] _indexes;
    private double[] _values;

    public StaticSignalProvider(ISignalHub signalHub, ILogger<StaticSignalProvider> logger)
        : base(signalHub, logger)
    {
    }

    protected override void OnInitialize()
    {
        var timestamp = SignalHub.GetTimestamp();
        var signals = SignalSources;
        
        for (var i = 0; i < _indexes.Length; i++)
        {
            signals[i].AssignWith(_values[i], timestamp);
        }
    }


    protected override void OnConfigure(IStaticSignalProviderConfiguration configuration)
    {
        base.OnConfigure(configuration);

        var size = configuration.SignalSources.Count;
        _indexes = new int[size];
        _values = new double[size];

        var tempIndex = 0;
        foreach (var signalSource in configuration.SignalSources)
        {
            _indexes[tempIndex] = GetSignalIndex(signalSource.Name);// SignalHub.GetSignalIndex(signalSource);
            _values[tempIndex] = configuration.SignalValues.SingleOrDefault(value => value.SignalSource == signalSource)?.Value.SIValue ?? double.NaN;

            tempIndex++;
        }
    }
}
