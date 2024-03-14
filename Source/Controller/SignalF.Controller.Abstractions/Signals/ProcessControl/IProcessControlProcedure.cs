using System.Threading;
using System.Threading.Tasks;

namespace SignalF.Controller.Signals.ProcessControl;

public interface IProcessControlProcedure
{
    /// <summary>
    ///     Entry Point for the user defined process control procedure.
    /// </summary>
    Task Main(IProcessControlAdapter processControlAdapter, CancellationToken cancellationToken);
}
