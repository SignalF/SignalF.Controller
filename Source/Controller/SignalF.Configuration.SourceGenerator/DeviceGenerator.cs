using Microsoft.CodeAnalysis;

namespace SignalF.Configuration.SourceGenerator;

[Generator(LanguageNames.CSharp)]
public class DeviceGenerator : GeneratorBase
{
    protected override string[] GetTemplateNames()
    {
        return new[]
        {
            "DeviceOptions",
            "DeviceConfigurationBuilder",
            "DeviceDefinitionBuilder",
            "DeviceTemplateBuilder",
            "DeviceExtensions"
        };
    }

    protected override string[] GetAttributes()
    {
        return new[] { "SignalF.Configuration.Integration.DeviceAttribute" };
    }
}
