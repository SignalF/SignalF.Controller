using System.Runtime.Versioning;
using SignalF.Controller;
using SignalF.Controller.Configuration;
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

        await host.RunAsync();
    }
}