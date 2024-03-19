using System;
using System.Threading;
using System.Threading.Tasks;

namespace SignalF.Controller.Signals.ProcessControl;

public class DefaultProcedure : IProcessControlProcedure
{
    public async Task Main(IProcessControlAdapter processControlAdapter, CancellationToken cancellationToken)
    {
        var count = 0;
        Console.WriteLine();

        while (true)
        {
            if(cancellationToken.IsCancellationRequested)
            {
                return;
            }


            if (count++ % 10 == 0)
            {
                var currentLineCursor = Console.CursorTop;
                Console.SetCursorPosition(0, Console.CursorTop);
                Console.Write(new string(' ', Console.WindowWidth));
                Console.SetCursorPosition(0, currentLineCursor);
                Console.Write("\rDefault process is running " );
            }
            else
            {
                Console.Write(".");
            }
            await Task.Delay(500, cancellationToken);
        }
        // ReSharper disable once FunctionNeverReturns
    }
}
