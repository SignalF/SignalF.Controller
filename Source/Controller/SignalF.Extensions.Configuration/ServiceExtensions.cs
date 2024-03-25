using Autofac;
using Autofac.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using SignalF.Extensions.Configuration.Module;

namespace SignalF.Extensions.Configuration;

public static class ServiceExtensions
{
    public static IHostBuilder UseSignalFConfiguration(this IHostBuilder builder)
    {
        builder.UseServiceProviderFactory(new AutofacServiceProviderFactory())
               .ConfigureContainer<ContainerBuilder>((_, containerBuilder) =>
                   containerBuilder.RegisterModule(new ConfigurationModule()));
        return builder;
    }
}
