using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace SignalF.Configuration.SourceGenerator;

public abstract class GeneratorBase : IncrementalGenerator
{
    protected override void OnInitialize()
    {
        var attributes = GetAttributes();
        foreach (var attribute in attributes)
        {
            RegisterSourceOutputForAttribute(attribute);
        }
    }

    private void RegisterSourceOutputForAttribute(string attributeTypeName)
    {
        //Debugger.Launch();
        var pipeline = Context.SyntaxProvider.ForAttributeWithMetadataName(
            attributeTypeName,
            static (syntaxNode, _) => syntaxNode is ClassDeclarationSyntax,
            static (context, _) => context);

        Context.RegisterSourceOutput(pipeline, Execute);
    }

    private void Execute(SourceProductionContext sourceContext, GeneratorAttributeSyntaxContext syntaxContext)
    {
        //Debugger.Launch();
        var symbol = syntaxContext.TargetSymbol;
        var className = syntaxContext.TargetSymbol.Name;
        var @namespace = symbol.ContainingNamespace.ToDisplayString();
        var globalNamespace = syntaxContext.SemanticModel.Compilation.Assembly.Name;

        foreach (var templateName in GetTemplateNames())
        {
            var template = LoadTemplate(templateName);
            if (!string.IsNullOrEmpty(template))
            {
                var content = string.Format(template, @namespace, className, globalNamespace);
                sourceContext.AddSource($"{className}{templateName}.g.cs", content);
            }

        }
    }

    protected abstract string[] GetTemplateNames();

    protected abstract string[] GetAttributes();
}
