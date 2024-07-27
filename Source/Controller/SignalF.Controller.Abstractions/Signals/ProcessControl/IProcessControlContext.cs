namespace SignalF.Controller.Signals.ProcessControl;

public interface IProcessControlContext : IDisposable
{
    /// <summary>
    ///     Return true if the process control procedure is running.
    /// </summary>
    bool ProcedureIsExecuting { get; }

    void AssignTask(Task task);

    void CreateProcessControlProcedure(string procedureName);

    Task RunProcessControlAsync(IProcessControlAdapter processControlAdapter);

    void Cancel();
}
