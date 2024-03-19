using SignalF.Controller.Configuration;
using SignalF.Datamodel.DataOutput;

namespace SignalF.Configuration.DataOutput;

public class DataOutputSenderConfigurationBuilder
    : DataOutputSenderConfigurationBuilder<SignalFConfigurationOptions>, IDataOutputSenderConfigurationBuilder
{
    protected override IDataOutputSenderConfigurationBuilder This => this;
}

public class DataOutputSenderConfigurationBuilder<TOptions>
    : DataOutputSenderConfigurationBuilder<DataOutputSenderConfigurationBuilder<TOptions>, IDataOutputSenderConfigurationBuilder<TOptions>,
          IDataOutputSenderConfiguration,
          TOptions>, IDataOutputSenderConfigurationBuilder<TOptions>
    where TOptions : SignalFConfigurationOptions
{
    protected override IDataOutputSenderConfigurationBuilder<TOptions> This => this;
}

public abstract class DataOutputSenderConfigurationBuilder<TImpl, TBuilder, TConfiguration, TOptions>
    : SignalFConfigurationBuilder<TImpl, TBuilder, TConfiguration, TOptions>
      , IDataOutputSenderConfigurationBuilder<TBuilder, TConfiguration, TOptions>
    where TBuilder : IDataOutputSenderConfigurationBuilder<TBuilder, TConfiguration, TOptions>
    where TImpl : DataOutputSenderConfigurationBuilder<TImpl, TBuilder, TConfiguration, TOptions>
    where TConfiguration : IDataOutputSenderConfiguration
    where TOptions : SignalFConfigurationOptions
{
}
