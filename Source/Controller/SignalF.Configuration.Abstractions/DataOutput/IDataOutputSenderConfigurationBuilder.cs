using SignalF.Datamodel.DataOutput;

namespace SignalF.Configuration.DataOutput;

public interface IDataOutputSenderConfigurationBuilder
    : IDataOutputSenderConfigurationBuilder<DataOutputSenderOptions>
{
}

public interface IDataOutputSenderConfigurationBuilder<in TOptions>
    : IDataOutputSenderConfigurationBuilder<IDataOutputSenderConfigurationBuilder<TOptions>, IDataOutputSenderConfiguration, TOptions>
    where TOptions : DataOutputSenderOptions
{
}

public interface IDataOutputSenderConfigurationBuilder<out TBuilder, in TConfiguration, in TOptions>
    : ISignalFConfigurationBuilder<TBuilder, TConfiguration, TOptions>
    where TBuilder : IDataOutputSenderConfigurationBuilder<TBuilder, TConfiguration, TOptions>
    where TConfiguration : IDataOutputSenderConfiguration
    where TOptions : DataOutputSenderOptions
{
}
