using System.Reflection;
using SignalF.Datamodel.Base;

namespace SignalF.Controller.Configuration;

internal static class ConfigurationExtensions
{
    public static Type GetCoreType(this ICoreObject configuration)
    {
        if (string.IsNullOrWhiteSpace(configuration.Type))
        {
            return null;
        }

        var parts = configuration.Type.Split(';');
        if (parts.Length != 2)
        {
            return null;
        }

        var assembly = Assembly.Load(parts[0]);

        return assembly.GetType(parts[1]);
    }
}
