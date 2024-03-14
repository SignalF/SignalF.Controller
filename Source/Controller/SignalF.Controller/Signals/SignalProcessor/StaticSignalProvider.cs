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

    public override void Execute(ETaskType taskType)
    {
        if (taskType != ETaskType.Init)
        {
            return;
        }

        for (var i = 0; i < _indexes.Length; i++)
        {
            SignalHub.SetValue(_indexes[i], _values[i]);
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
            _indexes[tempIndex] = SignalHub.GetSignalIndex(signalSource);
            _values[tempIndex] = configuration.SignalValues.SingleOrDefault(value => value.SignalSource == signalSource)?.Value.SIValue ?? double.NaN;

            tempIndex++;
        }
    }
}
