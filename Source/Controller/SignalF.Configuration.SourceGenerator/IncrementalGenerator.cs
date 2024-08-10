using System.Collections.Concurrent;
using System.Diagnostics;
using System.Reflection;
using Microsoft.CodeAnalysis;

namespace SignalF.Configuration.SourceGenerator;

public abstract class IncrementalGenerator : IIncrementalGenerator
{
    private static readonly ConcurrentDictionary<string, string> Templates = new();

    protected IncrementalGeneratorInitializationContext Context { get; private set; }

    static IncrementalGenerator()
    {
        AppDomain.CurrentDomain.UnhandledException += (sender, args) =>
        {
                //Debugger.Launch();
        };
        AppDomain.CurrentDomain.FirstChanceException+= (sender, args) =>
        {
                //Debugger.Launch();
        };
        AppDomain.CurrentDomain.AssemblyResolve += (sender, args) =>
        {
            //if (args.Name.Contains("CodeDom") && !args.Name.Contains("TextTemp"))
            //{
            //    Debugger.Launch();
            //}
            return null;
        };
    }

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
        template =  reader.ReadToEnd();

        Templates.TryAdd(templateName, template);
        return template;
    }

    protected abstract void OnInitialize();
}
