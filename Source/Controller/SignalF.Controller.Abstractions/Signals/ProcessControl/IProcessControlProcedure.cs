using System.Threading;
using System.Threading.Tasks;

namespace SignalF.Controller.Signals.ProcessControl;

public interface IProcessControlProcedure
{
    /// <summary>
    ///     Entry Point for the user defined process control procedure.
    /// </summary>
    /// <param name="processControlAdapter">
    ///     The Process Control Adapter for reading or writing signals to or from the Signal Hub.
    ///     This parameter is <value>null</value> if no adapter has been configured for the procedure.
    /// </param>
    /// <param name="cancellationToken">A cancellation token.</param>
    /// <returns></returns>
    Task Main(IProcessControlAdapter processControlAdapter, CancellationToken cancellationToken);
}
