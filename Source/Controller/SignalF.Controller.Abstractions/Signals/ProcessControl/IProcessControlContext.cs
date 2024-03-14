using System;
using System.Threading.Tasks;

namespace SignalF.Controller.Signals.ProcessControl;

public interface IProcessControlContext : IDisposable
{
    bool ProcedureIsExecuting { get; }

    void AssignTask(Task task);

    void CreateProcessControlProcedure(string procedureName);

    Task RunProcessControlAsync(IProcessControlAdapter processControlAdapter);

    void Cancel();
}
