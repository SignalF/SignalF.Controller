﻿#region

using System.Collections.Concurrent;
using Microsoft.Extensions.Logging;
using Scotec.Extensions.Linq;
using SignalF.Controller.Signals.SignalProcessor;

#endregion

namespace SignalF.Controller.Signals.ProcessControl;

public class ProcessControlHost : IProcessControlHost
{
    private static readonly ConcurrentDictionary<string, IProcessControlContext> ProcedureContextPairs = new();
    private readonly IProcessControlContextFactory _contextFactory;
    private readonly ILogger<ProcessControlHost> _logger;
    private readonly ISignalProcessorFactory _signalProcessorFactory;

    public ProcessControlHost(ISignalProcessorFactory signalProcessorFactory, IProcessControlContextFactory contextFactory,
                              ILogger<ProcessControlHost> logger)
    {
        _signalProcessorFactory = signalProcessorFactory;
        _contextFactory = contextFactory;
        _logger = logger;
    }

    public void StartProcessControl(ProcessControlStartInfo startInfo)
    {
        var processControlAdapter = _signalProcessorFactory
                                    .GetSignalProcessors<IProcessControlAdapter>()
                                    .SingleOrDefault(adapter => adapter.Name == startInfo.ProcedureName);
        if (processControlAdapter == null)
        {
            _logger.LogWarning(
                $"No adapter has been configured for the process control procedure '{startInfo.ProcedureName}'. The procedure is not able to read or write signals from or to the signal hub.");
        }

        // create context which creates a new assembly
        var cancellationSource = new CancellationTokenSource();

        var context = _contextFactory.CreateProcessControlContext(new ProcessControlContextConfiguration
        {
            //Todo: directory and assembly should come as parameter or from configuration.
            ProcessDirectory = startInfo.AssemblyDirectory, ProcessAssembly = startInfo.AssemblyName
        }, cancellationSource);

        if (context == null)
        {
            return;
        }

        _logger.LogInformation($"Starting process control procedure '{startInfo.ProcedureName}'...");
#pragma warning disable CS4014
        var task = new Task(() => ExecuteProcedure(startInfo.ProcedureName, processControlAdapter, context), TaskCreationOptions.LongRunning);
#pragma warning restore CS4014
        ProcedureContextPairs.TryAdd(startInfo.ProcedureName, context);
        context.AssignTask(task);
        task.Start();
    }

    public void StopProcessControl(string procedureName)
    {
        if (!ProcedureContextPairs.ContainsKey(procedureName))
        {
            _logger.LogInformation($"Procedure '{procedureName}' could not be stopped, since it does not appear to be running.");
            return;
        }

        var context = ProcedureContextPairs[procedureName];
        _logger.LogInformation($"Cancellation of procedure '{procedureName}' was requested. Terminating...");
        context.Cancel();
    }

    public void StopAllProcessControls()
    {
        ProcedureContextPairs.ForAll(context => context.Value.Cancel());
        _logger.LogInformation("All tests were cancelled.");
    }

    private async Task ExecuteProcedure(string procedureName, IProcessControlAdapter processControlAdapter, IProcessControlContext context)
    {
        if (context.ProcedureIsExecuting)
        {
            return;
        }

        try
        {
            try
            {
                context.CreateProcessControlProcedure(procedureName);
            }
            catch (Exception e)
            {
                _logger.LogError(e, "Exception occurred while trying to create process control procedure.");
                return;
            }

            try
            {
                await context.RunProcessControlAsync(processControlAdapter);
            }
            catch (TaskCanceledException)
            {
                _logger.LogInformation($"Procedure '{procedureName}' has been canceled and unloaded.");
                return;
            }
            catch (Exception e)
            {
                _logger.LogError(e, $"Exception occurred in process control procedure '{procedureName}'.");
                return;
            }
        }
        finally
        {
            context.Dispose();
            ProcedureContextPairs.TryRemove(procedureName, out _);
        }

        _logger.LogInformation($"Procedure '{procedureName}' completed and unloaded.");
    }
}
