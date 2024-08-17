using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Scotec.T4;
using System.Text;

namespace SignalF.Configuration.SourceGenerator;

public abstract class GeneratorBase : IncrementalGenerator
{
    private readonly Generator _generator = new();
    private readonly Dictionary<string, TextGenerator> _templates = new();

    protected override void OnInitialize()
    {
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
        try
        {
            foreach (var templateName in GetTemplateNames())
            {
                var template = LoadTemplate(templateName);
                if (!string.IsNullOrEmpty(template))
                {
                    var textGenerator = _generator.Build(T4Template.FromString(template, templateName));
                    //var parsed = _generator.ParseTemplate(templateName, template);
                    //var settings = TemplatingEngine.GetSettings(_generator, parsed);
                    //settings.CompilerOptions = "-nullable:enable";

                    //var compiled = _generator.CompileTemplateAsync(template).GetAwaiter().GetResult();
                    _templates.Add(templateName, textGenerator);
                }
            }
        }
        catch (Exception e)
        {
            throw new Exception("TESTTESTTESTTEST");
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

            var parameters = new Dictionary<string, object>()
            {
                { "className", className },
                { "classNamespace", classNamespace },
                { "globalNamespace", globalNamespace }
            };

            foreach (var template in _templates)
            {
                if (template.Value != null)
                {
                    using var stream = new MemoryStream();
                    using var textWriter = new StreamWriter(stream, Encoding.UTF32);
                    template.Value.Generate(textWriter, parameters).GetAwaiter().GetResult();

                    stream.Seek(0, SeekOrigin.Begin);
                    using var textReader = new StreamReader(stream);

                    var content = textReader.ReadToEnd();
                    sourceContext.AddSource($"{className}{template.Key}.g.cs", content);
                }
            }
        }
    }

    protected abstract string[] GetTemplateNames();

    protected abstract string[] GetAttributes();
}
