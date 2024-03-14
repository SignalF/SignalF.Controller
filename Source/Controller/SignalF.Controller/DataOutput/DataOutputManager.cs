#region

using System;
using System.Collections.Generic;
using System.Linq;
using SignalF.Datamodel.Configuration;

#endregion

namespace SignalF.Controller.DataOutput;

public class DataOutputManager : IDataOutputManager
{
    private readonly Func<IDataOutput> _dataOutputFactory;
    private readonly List<IDataOutput> _dataOutputs;

    public DataOutputManager(Func<IDataOutput> dataOutputFactory)
    {
        _dataOutputFactory = dataOutputFactory;
        _dataOutputs = new List<IDataOutput>();
    }

    public void Configure(IControllerConfiguration configuration)
    {
        var dataOutputConfigurations = configuration.DataOutputConfigurations;

        foreach (var outputConfiguration in dataOutputConfigurations)
        {
            var output = _dataOutputFactory();
            output.Configure(outputConfiguration);

            _dataOutputs.Add(output);
        }
    }

    public void StartCapture(Guid id, long cycleAmount)
    {
        _dataOutputs.SingleOrDefault(output => output.Id == id)?.SetFilter(cycleAmount);
    }

    public void StartCapture(Guid id, TimeSpan duration)
    {
        _dataOutputs.SingleOrDefault(output => output.Id == id)?.SetFilter(duration);
    }

    public void StartMeasurement()
    {
        _dataOutputs.SingleOrDefault(output => output.Name == "Measurement")?.SetFilter();
    }

    public void StopMeasurement()
    {
        _dataOutputs.SingleOrDefault(output => output.Name == "Measurement")?.Stop();
    }
}
