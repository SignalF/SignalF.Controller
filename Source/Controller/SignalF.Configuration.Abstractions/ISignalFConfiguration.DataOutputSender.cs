using System;
using SignalF.Configuration.DataOutput;
using SignalF.Controller.Configuration;
using SignalF.Controller.DataOutput;

namespace SignalF.Configuration;

public partial interface ISignalFConfiguration
{
    ISignalFConfiguration AddDataOutputConfiguration(Action<IDataOutputConfigurationBuilder> builder);

    ISignalFConfiguration AddDataOutputSenderConfiguration<TBuilder, TOptions>(Action<TBuilder> builder)
        where TBuilder : IDataOutputSenderConfigurationBuilder
        where TOptions : SignalFConfigurationOptions;

    ISignalFConfiguration AddDataOutputSenderConfiguration<TBuilder, TOptions, TType>(Action<TBuilder> builder)
        where TBuilder : IDataOutputSenderConfigurationBuilder
        where TOptions : SignalFConfigurationOptions
        where TType : class, IDataOutputSender;
}
