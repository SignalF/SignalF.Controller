using System;
using SignalF.Controller.Configuration;
using SignalF.Datamodel.Base;

namespace SignalF.Configuration;

public interface ICoreConfigurationBuilder<out TBuilder, in TConfiguration, in TOptions>
    where TBuilder : ICoreConfigurationBuilder<TBuilder, TConfiguration, TOptions>
    where TConfiguration : ICoreObject
    where TOptions : CoreConfigurationOptions
{
    void Build(TConfiguration configuration);

    TBuilder SetOptions(TOptions options);

    TBuilder SetName(string name);

    TBuilder SetType(string type);

    TBuilder SetType(Type type);

    TBuilder SetType<TType>();
}
