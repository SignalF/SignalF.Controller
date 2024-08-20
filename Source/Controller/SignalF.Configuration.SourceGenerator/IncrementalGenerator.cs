using System.Collections.Concurrent;
using System.Reflection;
using System.Xml.Xsl;
using Microsoft.CodeAnalysis;

namespace SignalF.Configuration.SourceGenerator;

public abstract class IncrementalGenerator : IIncrementalGenerator
{
    private static readonly ConcurrentDictionary<string, string> Templates = new();

    static IncrementalGenerator()
    {
        var searchPath = "/home/runner/work/SignalF.Devices/SignalF.Devices/packages/signalf.configuration.integration";
        AppDomain.CurrentDomain.AssemblyResolve += (sender, args) =>
        {
            var name = new AssemblyName(args.Name).Name;
            var assemblyPath = Directory.GetFiles(searchPath, $"{name}.dll", SearchOption.AllDirectories).FirstOrDefault();

            if(!string.IsNullOrEmpty(assemblyPath))
            {
                //var assemblies = AppDomain.CurrentDomain.GetAssemblies();
                //return assemblies.FirstOrDefault(a => a.FullName.Contains("Scotec.T4"));
                return Assembly.LoadFrom(assemblyPath);
            }

            return null;
        };
    }

    protected IncrementalGeneratorInitializationContext Context { get; private set; }

    public void Initialize(IncrementalGeneratorInitializationContext context)
    {
        Context = context;
        OnInitialize();
    }

    protected static string? LoadTemplate(string templateName)
    {
        if (Templates.TryGetValue(templateName, out var template))
        {
            return template;
        }

        var assembly = Assembly.GetExecutingAssembly();
        var resourcePath = assembly
                           .GetManifestResourceNames()
                           .FirstOrDefault(name => name.Contains(templateName));

        if (resourcePath == null)
        {
            return null;
        }

        using var stream = assembly.GetManifestResourceStream(resourcePath)!;
        using var reader = new StreamReader(stream);
        template = reader.ReadToEnd();

        Templates.TryAdd(templateName, template);
        return template;
    }

    protected abstract void OnInitialize();
}
