namespace SignalF.Configuration.SourceGenerator;

public interface IGenerator
{
    public string Execute(string className, string classNamespace, string globalNamespace);
}
