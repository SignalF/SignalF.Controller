using System.Collections;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Scotec.T4;
using System.Linq;
using System.Reflection;
using System.Text;
using static System.Net.Mime.MediaTypeNames;

namespace SignalF.Configuration.SourceGenerator;


public abstract class GeneratorBase : IncrementalGenerator
{
    private readonly Generator _generator;
    private readonly Dictionary<string, TextGenerator> _templates = new();

    protected GeneratorBase()
    {
        _generator = new Generator(new T4Options() { ReferencePaths = new List<string>
        {
            "/home/runner/work/SignalF.Devices/SignalF.Devices/packages/signalf.configuration.integration",
            "/home/runner/work/SignalF.Devices/SignalF.Devices/packages/signalf.configuration.integration/*"
        }, ReferenceAssemblies = new List<string>{"Scotec.T4.dll"} });
    }

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
        catch (AggregateException e)
        {
            var builder = new StringBuilder();
            foreach (var ex in e.InnerExceptions)
            {
                if (ex is T4CompilerException ce)
                {
                    //var text = ce.GeneratedCode.Split(new char[] { '\r', '\n' }, StringSplitOptions.RemoveEmptyEntries);
                    //var text = ce.GeneratedCode.Split(new char[] { '\r', '\n' }, StringSplitOptions.RemoveEmptyEntries);
                    //builder.Append($@"{string.Join("|", text)} "); 

                    builder.Append($@"{string.Join(" | ", ce.Errors.Select(error => error.ToString()))} ");
                }
                else
                {
                    //var text = ex.StackTrace.Split(new char[] { '\r', '\n' }, StringSplitOptions.RemoveEmptyEntries)
                    //             .Skip(5).ToList();
                    //var text = ex.Message.Split(new char[] { '\r', '\n' }, StringSplitOptions.RemoveEmptyEntries)
                    //             .Skip(0).ToList();
                    builder.Append($@"{string.Join("|", ex.Message)} ");
                    //builder.Append($"{AppDomain.CurrentDomain.BaseDirectory} | {AppDomain.CurrentDomain.DynamicDirectory}");
                }
            }
            throw new Exception(builder.ToString());
        }
        catch (Exception e)
        {
            throw new Exception($"Error {e.Message}");
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
                    template.Value.Generate(textWriter, parameters);

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
