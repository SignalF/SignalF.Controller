#region

#endregion

namespace SignalF.Controller.Signals.ProcessControl;

public interface IProcessControlHost
{
    /// <summary>
    ///     Starts the process controller.
    /// </summary>
    void StartProcessControl(ProcessControlStartInfo startInfo);

    /// <summary>
    ///     Requests a stop of the process controller.
    /// </summary>
    void StopProcessControl(string procedureName);

    /// <summary>
    ///     Stops all currently running process controllers.
    /// </summary>
    void StopAllProcessControls();
}
