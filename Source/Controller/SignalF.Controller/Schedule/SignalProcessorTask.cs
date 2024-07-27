#region

using SignalF.Controller.Signals.SignalProcessor;
using SignalF.Datamodel.Configuration;

#endregion

namespace SignalF.Controller.Schedule;

public class SignalProcessorTask : ControllerTask, ISignalProcessorTask
{
    private readonly IEnumerable<ISignalProcessor> _signalProcessorList;

    public SignalProcessorTask(Guid id, long raster, byte priority, ETaskType taskType, IEnumerable<ISignalProcessor> signalProcessorList)
        : base(id, raster, priority, taskType)
    {
        _signalProcessorList = signalProcessorList;
    }

    public override void Execute()
    {
        //TODO: Consider using derrived classes for each task type instead of using ETaskType enumerable. This would avoid special handling within the Execute() method.
        switch (TaskType)
        {
            case ETaskType.Calculate:
            {
                ExecuteCalculation();
                break;
            }
            default:
            {
                ExecuteDefault();
                break;
            }
        }
    }

    private void ExecuteDefault()
    {
        foreach (var signalProcessor in _signalProcessorList)
        {
            signalProcessor.Execute(TaskType);
        }
    }

    private void ExecuteCalculation()
    {
        // Calculators always read data from the signal hub, calculate the data and write it back to the signal hub.
        // Reading and writing data from/to the hub is independent of read or write tasks. 
        foreach (var signalProcessor in _signalProcessorList)
        {
            signalProcessor.Execute(ETaskType.Read);
            signalProcessor.Execute(ETaskType.Calculate);
            signalProcessor.Execute(ETaskType.Write);
        }
    }
}
