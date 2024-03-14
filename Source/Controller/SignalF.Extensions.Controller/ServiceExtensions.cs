using System.Runtime.Versioning;
using Autofac;
using Autofac.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using SignalF.Controller;
using SignalF.Controller.Configuration;
using SignalF.Extensions.Controller.Module;

namespace SignalF.Extensions.Controller;

[SupportedOSPlatform("linux")]
[SupportedOSPlatform("windows")]
public static class ServiceExtensions
{
    /// <summary>
    ///     Registers the SignalF controller and the underlying datamodel.
    /// </summary>
    public static IHostBuilder UseSignalFController(this IHostBuilder builder)
    {
        builder.UseServiceProviderFactory(new AutofacServiceProviderFactory())
               //Add controller services
               .ConfigureContainer<ContainerBuilder>((_, containerBuilder) => containerBuilder.RegisterModule(new ControllerModule()))
               .ConfigureContainer<ContainerBuilder>((_, containerBuilder) => containerBuilder.RegisterModule(new DataModelModule()));

        builder.ConfigureServices((_, services) => { services.AddSingleton<IApplicationArgumentCollection>(new ApplicationArgumentCollection()); });
        return builder;
    }

    public static IServiceCollection AddSignalFControllerService(this IServiceCollection services)
    {
        services.AddHostedService<HostedControllerService>();

        return services;
    }
}
