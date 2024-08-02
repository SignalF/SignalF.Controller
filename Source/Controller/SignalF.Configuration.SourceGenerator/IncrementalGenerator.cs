using System.Reflection;
using Microsoft.CodeAnalysis;

namespace SignalF.Configuration.SourceGenerator;

public abstract class IncrementalGenerator : IIncrementalGenerator
{
    protected IncrementalGeneratorInitializationContext Context { get; private set; }

    public void Initialize(IncrementalGeneratorInitializationContext context)
    {
        Context = context;
        OnInitialize();
    }

    protected static string? LoadTemplate(string templateName)
    {
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
        return reader.ReadToEnd();
    }

    protected abstract void OnInitialize();
}
