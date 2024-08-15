using System.Text;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Mono.TextTemplating;

namespace SignalF.Configuration.SourceGenerator;

public abstract class GeneratorBase : IncrementalGenerator
{
    private readonly TemplateGenerator _generator = new();
    private readonly Dictionary<string, CompiledTemplate> _templates = new();

    protected override void OnInitialize()
    {
        _generator.UseInProcessCompiler();
        
        //Debugger.Launch();
        var attributes = GetAttributes();
        foreach (var attribute in attributes)
        {
            RegisterSourceOutputForAttribute(attribute);
        }
    }

    private void RegisterSourceOutputForAttribute(string attributeTypeName)
    {
        LoadTemplates();
        //Debugger.Launch();
        var pipeline = Context.SyntaxProvider.ForAttributeWithMetadataName(
            attributeTypeName,
            static (syntaxNode, _) => syntaxNode is ClassDeclarationSyntax,
            static (context, _) => context);

        Context.RegisterSourceOutput(pipeline, Execute);
    }

    private void LoadTemplates()
    {
        foreach (var templateName                                                 in GetTemplateNames())
        {
            var template = LoadTemplate(templateName);
            if (!string.IsNullOrEmpty(template))
            {
                var parsed = _generator.ParseTemplate(templateName, template);
                var settings = TemplatingEngine.GetSettings(_generator, parsed);
                settings.CompilerOptions = "-nullable:enable";

                var compiled = _generator.CompileTemplateAsync(template).GetAwaiter().GetResult();
                _templates.Add(templateName, compiled);
            }
        }
    }

    private void Execute(SourceProductionContext sourceContext, GeneratorAttributeSyntaxContext syntaxContext)
    {
        lock (_generator)
        {
            //Debugger.Launch();
            var symbol = syntaxContext.TargetSymbol;
            var className = syntaxContext.TargetSymbol.Name;
            var classNamespace = symbol.ContainingNamespace.ToDisplayString();
            var globalNamespace = syntaxContext.SemanticModel.Compilation.Assembly.Name;

            var s = _generator.GetOrCreateSession();
            s.Add("className", className);
            s.Add("classNamespace", classNamespace);
            s.Add("globalNamespace", globalNamespace);

            foreach (var template in _templates)
            {
                if (template.Value != null)
                {
                    //var content = string.Format(template, @namespace, className, globalNamespace);
                    var content = template.Value.Process();
                    sourceContext.AddSource($"{className}{template.Key}.g.cs", content);
                }
            }

            _generator.ClearSession();
        }
    }

    protected abstract string[] GetTemplateNames();

    protected abstract string[] GetAttributes();
}
