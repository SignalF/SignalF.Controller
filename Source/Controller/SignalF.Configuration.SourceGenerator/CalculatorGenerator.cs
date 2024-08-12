using Microsoft.CodeAnalysis;

namespace SignalF.Configuration.SourceGenerator;

[Generator(LanguageNames.CSharp)]
public class CalculatorGenerator : GeneratorBase
{
    protected override string[] GetTemplateNames()
    {
        return new[]
        {
            "CalculatorOptions",
            "CalculatorConfigurationBuilder",
            "CalculatorDefinitionBuilder",
            "CalculatorTemplateBuilder",
            "CalculatorExtensions"
        };
    }

    protected override string[] GetAttributes()
    {
        return new[] { "SignalF.Configuration.Integration.CalculatorAttribute" };
    }
}
