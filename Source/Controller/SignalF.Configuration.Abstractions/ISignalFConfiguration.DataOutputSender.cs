using SignalF.Configuration.DataOutput;
using SignalF.Controller.DataOutput;
using SignalF.Datamodel.DataOutput;

namespace SignalF.Configuration;

public partial interface ISignalFConfiguration
{
    ISignalFConfiguration AddDataOutputConfiguration(Action<IDataOutputConfigurationBuilder> builder);

    ISignalFConfiguration AddDataOutputSenderConfiguration<TBuilder, TOptions>(Action<TBuilder> builder)
        where TBuilder : IDataOutputSenderConfigurationBuilder<TBuilder, IDataOutputSenderConfiguration, TOptions>
        where TOptions : DataOutputSenderOptions;

    ISignalFConfiguration AddDataOutputSenderConfiguration<TBuilder, TOptions, TType>(Action<TBuilder> builder)
        where TBuilder : IDataOutputSenderConfigurationBuilder<TBuilder, IDataOutputSenderConfiguration, TOptions>
        where TOptions : DataOutputSenderOptions
        where TType : class, IDataOutputSender;
}
