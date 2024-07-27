using SignalF.Controller.Configuration;
using SignalF.Datamodel.Base;

namespace SignalF.Configuration;

public interface ISignalFConfigurationBuilder<out TBuilder, in TConfiguration, in TOptions>
    where TBuilder : ISignalFConfigurationBuilder<TBuilder, TConfiguration, TOptions>
    where TConfiguration : ICoreObject
    where TOptions : SignalFConfigurationOptions
{
    void Build(TConfiguration configuration);

    TBuilder SetOptions(TOptions options);

    TBuilder SetName(string name);

    TBuilder SetType(string type);

    TBuilder SetType(Type type);

    TBuilder SetType<TType>();
}
