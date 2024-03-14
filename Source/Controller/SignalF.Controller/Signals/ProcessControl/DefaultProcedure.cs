using System;
using System.Threading;
using System.Threading.Tasks;

namespace SignalF.Controller.Signals.ProcessControl;

public class DefaultProcedure : IProcessControlProcedure
{
    public async Task Main(IProcessControlAdapter processControlAdapter, CancellationToken cancellationToken)
    {
        while (true)
        {
            Console.WriteLine("Default precess is running");
            await Task.Delay(1000, cancellationToken);
        }
    }
}
