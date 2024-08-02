using Microsoft.CodeAnalysis;

namespace SignalF.Configuration.SourceGenerator;

[Generator(LanguageNames.CSharp)]
public class DeviceConfigurationGenerator : ConfigurationGeneratorBase
{
    protected override string GetTemplateName()
    {
        return "DeviceConfiguration";
    }

    protected override string[] GetAttributes()
    {
        return new[] { "SignalF.Configuration.DeviceAttribute" };
    }
}
