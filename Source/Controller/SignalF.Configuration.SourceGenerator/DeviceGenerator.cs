using Microsoft.CodeAnalysis;

namespace SignalF.Configuration.SourceGenerator;

[Generator(LanguageNames.CSharp)]
public class DeviceGenerator : GeneratorBase
{
    protected override string[] GetTemplateNames()
    {
        return new string[]
        {
            "DeviceOptions",
            "ConfigurationBuilder",
            "DefinitionBuilder",
            "TemplateBuilder",
            "DeviceExtensions",
        };
    }

    protected override string[] GetAttributes()
    {
        return new[] { "SignalF.Configuration.DeviceAttribute" };
    }
}
