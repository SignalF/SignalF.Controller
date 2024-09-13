using System.IO.Packaging;
using System.Runtime.Versioning;
using Microsoft.Extensions.Hosting;
using Scotec.XMLDatabase;
using SignalF.Controller;
using SignalF.Controller.Configuration;
using SignalF.Datamodel.Configuration;
using SignalF.Extensions.Configuration;
using SignalF.Extensions.Controller;

namespace TestController;

[SupportedOSPlatform("linux")]
[SupportedOSPlatform("windows")]
public class Program
{
    public static async Task Main(string[] args)
    {
        var options = CliOptionParser.ParseCliArguments(new ApplicationArgumentCollection());
        if (options.ShowHelp)
        {
            return;
        }

        var hostBuilder = Host.CreateDefaultBuilder(args)
            .UseSignalFController()
            .UseSignalFConfiguration()
            //.UseSignalFDevices()
            //.UseSignalFDataOutput()
            .ConfigureServices(services =>
            {
                if (options.IsOnline)
                {
                    // In online mode, the control process is only started upon an external request.
                    //services.AddSignalFWebService();
                }
                else
                {
                    //In offline mode, the control process in the HostedControllerService is started immediately.
                    services.AddSignalFControllerService();
                    //services.AddTransient<ISystemConfiguration, TestConfiguration>();
                }
            });

        var host = hostBuilder.Build();

        Test(host.Services);

        await host.RunAsync();
    }

    private static void Test(IServiceProvider services)
    {
        //LoadSchema(new Uri("pack://application:,,,ConsoleApp1;component/Schemas/SignalF.Datamodel.Configuration.xsd"), schemas);
        var document = services.GetService<IBusinessDocument>();
        document.Root = "ControllerConfiguration";

        //Test();

        var scheme = PackUriHelper.UriSchemePack;
        document.Schema = new Uri($"{scheme}://application:,,,SignalF.Datamodel;component/Schemas/SignalF.Datamodel.Configuration.xsd");
        document.CreateDocument("");
        var session = document.CreateSession(EBusinessSessionMode.Write);
        var configuration = session.GetRoot<IControllerConfiguration>();

    }
}