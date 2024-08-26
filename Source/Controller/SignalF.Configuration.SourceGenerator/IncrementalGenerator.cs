using System.Collections.Concurrent;
using System.Reflection;
using Microsoft.CodeAnalysis;

namespace SignalF.Configuration.SourceGenerator;

public abstract class IncrementalGenerator : IIncrementalGenerator
{
    private static readonly ConcurrentDictionary<string, string> Templates = new();

    static IncrementalGenerator()
    {
        // The reference to the Scotec.T4 assembly cannot be resolved automatically if the
        // source generator runs within a GitHub action. Therefor we need an assembly resolver
        // that gets the assembly from the package directory.
        var gitHubWorkspace = Environment.GetEnvironmentVariable("GITHUB_WORKSPACE");
        if (string.IsNullOrEmpty(gitHubWorkspace))
        {
            return;
        }
        
        var searchPath = gitHubWorkspace + "/packages/signalf.configuration.integration";
        AppDomain.CurrentDomain.AssemblyResolve += (sender, args) =>
        {
            var name = new AssemblyName(args.Name).Name;

            var assemblyPath = Directory.GetFiles(searchPath, $"{name}.dll", SearchOption.AllDirectories).FirstOrDefault();

            if (!string.IsNullOrEmpty(assemblyPath))
            {
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
