using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Extensions.DependencyInjection;
using SignalF.Controller.Configuration;
using SignalF.Datamodel.DataOutput;

namespace SignalF.Controller.DataOutput;

public class DataOutputSenderFactory : IDataOutputSenderFactory
{
    private readonly IDictionary<Guid, IDataOutputSender> _dataOutputSenders;
    private readonly IServiceProvider _serviceProvider;

    public DataOutputSenderFactory(IServiceProvider serviceProvider)
    {
        _serviceProvider = serviceProvider;
        _dataOutputSenders = new Dictionary<Guid, IDataOutputSender>();
    }

    public IDataOutputSender GetDataOutputSender(Type type, Guid id)
    {
        if (!_dataOutputSenders.TryGetValue(id, out var instance))
        {
            instance = (IDataOutputSender)_serviceProvider.GetRequiredService(type);
            _dataOutputSenders.Add(id, instance);
        }

        return instance;
    }

    public IEnumerable<TDataOutputSender> GetDataOutputSenders<TDataOutputSender>()
        where TDataOutputSender : IDataOutputSender
    {
        return _dataOutputSenders.Values.OfType<TDataOutputSender>();
    }

    public IDataOutputSender GetDataOutputSender(IDataOutputSenderConfiguration dataOutputSenderConfiguration)
    {
        var type = dataOutputSenderConfiguration.GetCoreType();

        if (type == null)
        {
            var message = $"No implementation type has been defined for data output sender '{dataOutputSenderConfiguration.Name}'.";
            throw new ConfiguratorException(message);
        }

        return GetDataOutputSender(type, dataOutputSenderConfiguration.Id);
    }

    public IDataOutputSender FindDataOutputSender(Guid id)
    {
        if (_dataOutputSenders.TryGetValue(id, out var instance))
        {
            return instance;
        }

        throw new ControllerException($"Could not find data output sender with ID '{id}'.");
    }
}
