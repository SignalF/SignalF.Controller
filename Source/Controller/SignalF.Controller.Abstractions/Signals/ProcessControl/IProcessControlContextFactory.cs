namespace SignalF.Controller.Signals.ProcessControl;

public interface IProcessControlContextFactory
{
    IProcessControlContext CreateProcessControlContext(ProcessControlContextConfiguration configuration,
                                                       CancellationTokenSource cancellationTokenSource);
}
