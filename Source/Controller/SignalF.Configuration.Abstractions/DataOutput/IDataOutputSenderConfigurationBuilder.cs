using SignalF.Controller.Configuration;
using SignalF.Datamodel.DataOutput;

namespace SignalF.Configuration.DataOutput;

public interface IDataOutputSenderConfigurationBuilder
    : IDataOutputSenderConfigurationBuilder<CoreConfigurationOptions>
{
}

public interface IDataOutputSenderConfigurationBuilder<in TOptions>
    : IDataOutputSenderConfigurationBuilder<IDataOutputSenderConfigurationBuilder<TOptions>, IDataOutputSenderConfiguration, TOptions>
    where TOptions : CoreConfigurationOptions
{
}

public interface IDataOutputSenderConfigurationBuilder<out TBuilder, in TConfiguration, in TOptions>
    : ICoreConfigurationBuilder<TBuilder, TConfiguration, TOptions>
    where TBuilder : IDataOutputSenderConfigurationBuilder<TBuilder, TConfiguration, TOptions>
    where TConfiguration : IDataOutputSenderConfiguration
    where TOptions : CoreConfigurationOptions
{
}
