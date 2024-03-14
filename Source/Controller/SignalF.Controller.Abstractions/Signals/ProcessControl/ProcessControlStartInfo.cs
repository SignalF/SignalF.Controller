namespace SignalF.Controller.Signals.ProcessControl;

public class ProcessControlStartInfo
{
    /// <summary>
    ///     Name of the procedure to execute
    /// </summary>
    public string ProcedureName { get; set; }

    /// <summary>
    ///     ID of the procedure to execute
    /// </summary>
    public string ProcedureId { get; set; }

    /// <summary>
    ///     Assembly that contains the procedure.
    /// </summary>
    public string AssemblyName { get; set; }

    /// <summary>
    ///     Location of the assembly.
    /// </summary>
    public string AssemblyDirectory { get; set; }
}
