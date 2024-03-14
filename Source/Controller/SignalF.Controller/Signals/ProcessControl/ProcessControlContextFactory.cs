#region

using System;
using System.IO;
using System.Reflection;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;

#endregion

namespace SignalF.Controller.Signals.ProcessControl;

// creates collectible assembly and loads assembly into this context, creates TestProgram from loaded assembly
public class ProcessControlContextFactory : IProcessControlContextFactory
{
    private readonly Func<string, CancellationTokenSource, IProcessControlContext> _factory;
    private readonly ILogger<ProcessControlContextFactory> _logger;

    public Assembly Assembly;
    public Task AssignedTask;
    public bool ProcedureIsExecuting;
    public IProcessControlProcedure ProcessControlProcedure;

    public ProcessControlContextFactory(Func<string, CancellationTokenSource, IProcessControlContext> factory, ILogger<ProcessControlContextFactory> logger)
    {
        _factory = factory;
        _logger = logger;
    }

    public IProcessControlContext CreateProcessControlContext(ProcessControlContextConfiguration configuration,
                                                              CancellationTokenSource cancellationTokenSource)
    {
        var directory = string.IsNullOrWhiteSpace(configuration.ProcessDirectory)
            ? $".{Path.DirectorySeparatorChar}"
            : configuration.ProcessDirectory;
        var isAbsolutePath = Path.IsPathFullyQualified(directory);

        var basePath = isAbsolutePath
            ? directory
            : Path.Combine(AppDomain.CurrentDomain.BaseDirectory, directory);

        var assemblyPath = Path.GetFullPath($"{configuration.ProcessAssembly}.dll", basePath);

        return _factory(Path.GetFullPath(assemblyPath), cancellationTokenSource);
    }
}
