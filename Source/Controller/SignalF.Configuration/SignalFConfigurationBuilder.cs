using SignalF.Controller.Configuration;
using SignalF.Datamodel.Base;

namespace SignalF.Configuration;

public abstract class SignalFConfigurationBuilder<TImpl, TBuilder, TConfiguration, TOptions>
    : ISignalFConfigurationBuilder<TBuilder, TConfiguration, TOptions>
    where TImpl : SignalFConfigurationBuilder<TImpl, TBuilder, TConfiguration, TOptions>
    where TBuilder : ISignalFConfigurationBuilder<TBuilder, TConfiguration, TOptions>
    where TConfiguration : ICoreObject
    where TOptions : SignalFConfigurationOptions

{
    protected TOptions Options { get; private set; }

    // The compiler is unable to resolve TBuild here. Thus the property must be abstract and implemented in the final subclass.
    protected abstract TBuilder This { get; }

    public string Name { get; private set; }

    public string Type { get; private set; }

    public TBuilder SetOptions(TOptions options)
    {
        Options = options;
        return This;
    }

    public TBuilder SetType(string type)
    {
        Type = type;
        return This;
    }

    public TBuilder SetName(string name)
    {
        Name = name;
        return This;
    }

    public TBuilder SetType(Type type)
    {
        return SetType($"{type.Assembly.GetName().Name};{type.FullName}");
    }

    public TBuilder SetType<TType>()
    {
        return SetType(typeof(TType));
    }

    public virtual void Build(TConfiguration configuration)
    {
        configuration.Name = Name;
        configuration.Type = Type;
        configuration.Configuration.Set(Options);
    }
}
