#region

using System;
using System.Linq;
using System.Reflection;
using System.Runtime.Intrinsics.X86;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;

#endregion

namespace SignalF.Controller.Signals.ProcessControl;

// creates collectible assembly and loads assembly into this context, creates a process control procedure from loaded assembly
public class ProcessControlContext : IProcessControlContext
{
    private readonly string _assemblyPath;

    private readonly CancellationTokenSource _cancellationTokenSource;
    private readonly CollectibleAssemblyLoadContext _context;
    private readonly ILogger<ProcessControlContext> _logger;

    private Assembly _assembly;
    private Task _assignedTask;
    private bool _isDisposed;

    // The assembly that contains the implementation of the IProcessControlProcedure interface
    // will be unloaded after usage. Therefore no reference to the object must be kept outside this class.
    private IProcessControlProcedure _processControlProcedure;

    public ProcessControlContext(string assemblyPath, ILogger<ProcessControlContext> logger,
                                 CancellationTokenSource cancellationTokenSource)
    {
        _assemblyPath = assemblyPath;
        _logger = logger;
        _context = new CollectibleAssemblyLoadContext();
        _cancellationTokenSource = cancellationTokenSource;
    }

    public void AssignTask(Task task)
    {
        _assignedTask = task;
    }

    public bool ProcedureIsExecuting { get; private set; }

    public void CreateProcessControlProcedure(string procedureName)
    {
        LoadAssembly();

        var processControlType = _assembly.GetTypes()
                                          .Single(type => type.GetInterfaces().Contains(typeof(IProcessControlProcedure))
                                                          && type.Name == procedureName);

        _logger.LogInformation($"Loaded control process procedure '{procedureName}' from assembly {_assembly}.");

        // Use the activator to create a new instance of the process control procedure. The type of procedure is only
        // known after the configuration has been loaded and therefore cannot be registered on the IoC container.
        // However, within the main method, the use of a custom IoC container can be implemented.
        _processControlProcedure = (IProcessControlProcedure)Activator.CreateInstance(processControlType);
    }

    public async Task RunProcessControlAsync(IProcessControlAdapter processControlAdapter)
    {
        try
        {
            ProcedureIsExecuting = true;
            await _processControlProcedure.Main(processControlAdapter, _cancellationTokenSource.Token);
        }
        finally
        {
            ProcedureIsExecuting = false;
        }
    }

    public void Cancel()
    {
        if (!_cancellationTokenSource.IsCancellationRequested)
        {
            _cancellationTokenSource.Cancel();
        }
    }

    public void Dispose()
    {
        if (_isDisposed)
        {
            return;
        }

        _isDisposed = true;

        // unloads the context freeing the RAM (IF program isn't running)
        _context?.Unload();

        _cancellationTokenSource?.Dispose();
        _assignedTask?.Dispose();
    }

    // Loads assembly from memory stream or file into collectible context
    private void LoadAssembly()
    {
        try
        {
            _assembly = _context.LoadFromAssemblyPath(_assemblyPath);
        }
        catch (Exception e)
        {
            _logger.LogError(e, "Exception occurred while trying to load assembly from given string." +
                                "Check if the given path is correct.");
        }
    }
}
