using SignalF.Configuration.DataOutput;
using SignalF.Controller;
using SignalF.Controller.Configuration;
using SignalF.Controller.DataOutput;
using SignalF.Datamodel.Calculation;
using SignalF.Datamodel.DataOutput;

namespace SignalF.Configuration;

public partial interface ISignalFConfiguration
{
    ISignalFConfiguration AddDataOutputConfiguration(Action<IDataOutputConfigurationBuilder> builder);

    ISignalFConfiguration AddDataOutputSenderConfiguration<TBuilder, TOptions>(Action<TBuilder> builder)
        where TBuilder : IDataOutputSenderConfigurationBuilder<TBuilder, IDataOutputSenderConfiguration, TOptions>
        where TOptions : SignalFConfigurationOptions;

    ISignalFConfiguration AddDataOutputSenderConfiguration<TBuilder, TOptions, TType>(Action<TBuilder> builder)
        where TBuilder : IDataOutputSenderConfigurationBuilder<TBuilder, IDataOutputSenderConfiguration, TOptions>
        where TOptions : SignalFConfigurationOptions
        where TType : class, IDataOutputSender;
}
