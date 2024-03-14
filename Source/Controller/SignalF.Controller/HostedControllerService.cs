using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using SignalF.Controller.Configuration;
using SignalF.Controller.Signals.ProcessControl;

namespace SignalF.Controller;

public class HostedControllerService : IHostedService
{
    private readonly IApplicationArgumentCollection _applicationArgumentCollection;
    private readonly IServiceScopeFactory _scopeFactory;

    private ICoreConfigurationManager _configurationManager;
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
    ///     In offline mode, the controller executes the test program specified in the CLI parameters.External control is not
    ///     possible in offline mode.
    ///     To control the controller externally, e.g. via the Azure Cloud, the controller must be started in online mode.
    ///     In online mode, test programs can be specified, started or stopped from outside.
    /// </summary>
    public Task StartAsync(CancellationToken cancellationToken)
    {
        // configuration based on configuration file
        var options = CliOptionParser.ParseCliArguments(_applicationArgumentCollection.ToList());

        _scope = _scopeFactory.CreateScope();

        _controlInterface = _scope.ServiceProvider.GetService<IControlInterface>();
        _configurationManager = _scope.ServiceProvider.GetService<ICoreConfigurationManager>();

        // Use default configuration.
        //_configurationManager!.Configure(null);

        // execute default procedure if no procedureName is supplied by CLI
        var procedureName = options.ProcedureName ?? "DefaultProcedure";
        _controlInterface.Start(options.Configuration ?? "DefaultConfiguration");
        _controlInterface.StartMeasurement();
        _controlInterface!.StartProcessControl(new ProcessControlStartInfo
        {
            ProcedureName = options.ProcedureName ?? "DefaultProcedure",
            // Create a new ID of none is provided.
            ProcedureId = options.ProcedureId, AssemblyName = string.IsNullOrWhiteSpace(options.AssemblyName) ? "SignalF.Controller" : options.AssemblyName,
            AssemblyDirectory = options.AssemblyDirectory
        });

        return Task.CompletedTask;
    }

    public Task StopAsync(CancellationToken cancellationToken)
    {
        _controlInterface.Stop();

        _controlInterface = null;
        _configurationManager = null;
        _scope.Dispose();
        _scope = null;

        return Task.CompletedTask;
    }
}
