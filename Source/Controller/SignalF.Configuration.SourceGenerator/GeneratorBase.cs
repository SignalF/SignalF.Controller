using System.Diagnostics;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Mono.TextTemplating;

//using Mono.TextTemplating;

namespace SignalF.Configuration.SourceGenerator;

public abstract class GeneratorBase : IncrementalGenerator
{
    private readonly TemplateGenerator _generator = new();

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
        Debugger.Launch();
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
        var classNamespace = symbol.ContainingNamespace.ToDisplayString();
        var globalNamespace = syntaxContext.SemanticModel.Compilation.Assembly.Name;

        _generator.AddParameter("", "", "className", className);
        _generator.AddParameter("", "", "classNamespace", classNamespace);
        _generator.AddParameter("", "", "globalNamespace", globalNamespace);
        
        foreach (var templateName in GetTemplateNames())
        {
            var template = LoadTemplate(templateName);
            if (!string.IsNullOrEmpty(template))
            {
                //var content = string.Format(template, @namespace, className, globalNamespace);

                var parsed = _generator.ParseTemplate(templateName, template);
                var settings = TemplatingEngine.GetSettings(_generator, parsed);
                settings.CompilerOptions = "-nullable:enable";
                

                var (outputName, content, success) = _generator.ProcessTemplateAsync(templateName, template, $"{className}{templateName}")
                    .GetAwaiter().GetResult();

                if (success)
                {
                    sourceContext.AddSource(outputName, content);
                }
                
                // sourceContext.AddSource($"{className}{templateName}.g.cs", content);
            }
        }
    }

    protected abstract string[] GetTemplateNames();

    protected abstract string[] GetAttributes();
}
