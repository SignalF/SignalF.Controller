using Microsoft.Extensions.DependencyInjection;
using SignalF.Configuration.DataOutput;
using SignalF.Controller.Configuration;
using SignalF.Controller.DataOutput;
using SignalF.Datamodel.DataOutput;

namespace SignalF.Configuration;

public partial class CoreConfiguration : ICoreConfiguration
{
    public ICoreConfiguration AddDataOutputConfiguration(Action<IDataOutputConfigurationBuilder> builder)
    {
        _dataOutputs.Add(configuration =>
        {
            var configurationBuilder = _serviceProvider.GetRequiredService<IDataOutputConfigurationBuilder>();
            builder(configurationBuilder);
            configurationBuilder.Build(configuration.DataOutputConfigurations.Create<IDataOutputConfiguration>());
        });
        return this;
    }

    public ICoreConfiguration AddDataOutputSenderConfiguration<TBuilder, TOptions>(Action<TBuilder> builder)
        where TBuilder : IDataOutputSenderConfigurationBuilder
        where TOptions : CoreConfigurationOptions
    {
        _dataOutputSenders.Add(configuration =>
        {
            var configurationBuilder = _serviceProvider.GetRequiredService<TBuilder>();
            builder(configurationBuilder);
            configurationBuilder.Build(configuration.DataOutputSenderConfigurations.Create<IDataOutputSenderConfiguration>());
        });
        return this;
    }

    public ICoreConfiguration AddDataOutputSenderConfiguration<TBuilder, TOptions, TType>(Action<TBuilder> builder)
        where TBuilder : IDataOutputSenderConfigurationBuilder
        where TOptions : CoreConfigurationOptions
        where TType : class, IDataOutputSender
    {
        _dataOutputSenders.Add(configuration =>
        {
            var configurationBuilder = _serviceProvider.GetRequiredService<TBuilder>();
            configurationBuilder.SetType<TType>();
            builder(configurationBuilder);
            configurationBuilder.Build(configuration.DataOutputSenderConfigurations.Create<IDataOutputSenderConfiguration>());
        });
        return this;
    }
}
