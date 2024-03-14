using System;
using SignalF.Configuration.DataOutput;
using SignalF.Controller.Configuration;
using SignalF.Controller.DataOutput;

namespace SignalF.Configuration;

public partial interface ICoreConfiguration
{
    ICoreConfiguration AddDataOutputConfiguration(Action<IDataOutputConfigurationBuilder> builder);

    ICoreConfiguration AddDataOutputSenderConfiguration<TBuilder, TOptions>(Action<TBuilder> builder)
        where TBuilder : IDataOutputSenderConfigurationBuilder
        where TOptions : CoreConfigurationOptions;

    ICoreConfiguration AddDataOutputSenderConfiguration<TBuilder, TOptions, TType>(Action<TBuilder> builder)
        where TBuilder : IDataOutputSenderConfigurationBuilder
        where TOptions : CoreConfigurationOptions
        where TType : class, IDataOutputSender;
}
