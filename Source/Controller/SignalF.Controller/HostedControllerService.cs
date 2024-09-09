using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using SignalF.Controller.Configuration;
using SignalF.Controller.Signals.ProcessControl;

namespace SignalF.Controller;

public class HostedControllerService : IHostedService
{
    private const string DefaultConfiguration = "DefaultConfiguration";
    private readonly IApplicationArgumentCollection _applicationArgumentCollection;
    private readonly IServiceScopeFactory _scopeFactory;

    private IControlInterface _controlInterface;
    private IServiceScope _scope;

    public HostedControllerService(
        IServiceScopeFactory scopeFactory,
        IApplicationArgumentCollection applicationArgumentCollection
    )
    {
        _scopeFactory = scopeFactory;
        _applicationArgumentCollection = applicationArgumentCollection;
    }

    /// <summary>
    ///     The controller can be started in either online or offline mode.
    ///     In offline mode, the controller executes the process control specified in the CLI parameters. External control is not
    ///     possible in offline mode.
    ///     To control the controller externally, e.g. via the Azure Cloud, the controller must be started in online mode.
    ///     In online mode, process control programs can be specified, started or stopped from outside.
    /// </summary>
    public Task StartAsync(CancellationToken cancellationToken)
    {
        // configuration based on configuration file
        var options = CliOptionParser.ParseCliArguments(_applicationArgumentCollection.ToList());

        _scope = _scopeFactory.CreateScope();

        _controlInterface = _scope.ServiceProvider.GetRequiredService<IControlInterface>();

        var configuration = options.Configuration ?? DefaultConfiguration;
        var procedureName = options.ProcedureName ?? nameof(DefaultProcedure);
        var assemblyName = string.IsNullOrWhiteSpace(options.AssemblyName) ? GetAssenblyName() : options.AssemblyName;

        _controlInterface.Start(configuration);
        _controlInterface.StartMeasurement();
        _controlInterface!.StartProcessControl(new ProcessControlStartInfo
        {
            // execute default procedure if no procedureName is supplied by CLI
            ProcedureName = procedureName,
            // Create a new ID if none is provided.
            ProcedureId = options.ProcedureId, AssemblyName = assemblyName,
            AssemblyDirectory = options.AssemblyDirectory
        });

        return Task.CompletedTask;

        string GetAssenblyName()
        {
            return typeof(DefaultProcedure).Assembly.GetName().Name;
        }
    }

    public Task StopAsync(CancellationToken cancellationToken)
    {
        _controlInterface.Stop();

        _controlInterface = null;
        _scope.Dispose();
        _scope = null;

        return Task.CompletedTask;
    }
}
