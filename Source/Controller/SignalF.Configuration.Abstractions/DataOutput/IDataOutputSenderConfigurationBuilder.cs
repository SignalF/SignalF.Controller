using SignalF.Controller.Configuration;
using SignalF.Datamodel.DataOutput;

namespace SignalF.Configuration.DataOutput;

public interface IDataOutputSenderConfigurationBuilder
    : IDataOutputSenderConfigurationBuilder<SignalFConfigurationOptions>
{
}

public interface IDataOutputSenderConfigurationBuilder<in TOptions>
    : IDataOutputSenderConfigurationBuilder<IDataOutputSenderConfigurationBuilder<TOptions>, IDataOutputSenderConfiguration, TOptions>
    where TOptions : SignalFConfigurationOptions
{
}

public interface IDataOutputSenderConfigurationBuilder<out TBuilder, in TConfiguration, in TOptions>
    : ISignalFConfigurationBuilder<TBuilder, TConfiguration, TOptions>
    where TBuilder : IDataOutputSenderConfigurationBuilder<TBuilder, TConfiguration, TOptions>
    where TConfiguration : IDataOutputSenderConfiguration
    where TOptions : SignalFConfigurationOptions
{
}
