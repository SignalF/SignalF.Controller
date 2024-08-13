using Microsoft.CodeAnalysis;

namespace SignalF.Configuration.SourceGenerator;

[Generator(LanguageNames.CSharp)]
public class DataOutputSenderGenerator : GeneratorBase
{
    protected override string[] GetTemplateNames()
    {
        return new[]
        {
            "DataOutputSenderOptions",
            "DataOutputSenderExtensions",
            "DataOutputSenderConfigurationBuilder"
        };
    }

    protected override string[] GetAttributes()
    {
        return new[] { "SignalF.Configuration.Integration.DataOutputSenderAttribute" };
    }
}
