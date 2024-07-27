namespace SignalF.Controller.Signals.ProcessControl;

public class DefaultProcedure : IProcessControlProcedure
{
    /// <inheritdoc />
    /// >
    public async Task Main(IProcessControlAdapter processControlAdapter, CancellationToken cancellationToken)
    {
        Console.WriteLine();

        var count = 0;
        while (true)
        {
            if (cancellationToken.IsCancellationRequested)
            {
                break;
            }

            if (count++ % 10 == 0)
            {
                ClearCurrentConsoleLine();
                Console.Write("Default process is running ");
            }
            else
            {
                Console.Write(".");
            }

            await Task.Delay(500, cancellationToken);
        }
        // ReSharper disable once FunctionNeverReturns
    }

    public static void ClearCurrentConsoleLine()
    {
        var currentLineCursor = Console.CursorTop;
        Console.SetCursorPosition(0, Console.CursorTop);
        Console.Write(new string(' ', Console.WindowWidth));
        Console.SetCursorPosition(0, currentLineCursor);
    }
}
