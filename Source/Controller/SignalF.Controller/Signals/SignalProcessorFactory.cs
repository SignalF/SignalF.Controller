using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Extensions.DependencyInjection;
using SignalF.Controller.Signals.SignalProcessor;

namespace SignalF.Controller.Signals;

public class SignalProcessorFactory : ISignalProcessorFactory
{
    private readonly IServiceProvider _serviceProvider;
    private readonly IDictionary<Guid, ISignalProcessor> _signalProcessors;

    public SignalProcessorFactory(IServiceProvider serviceProvider)
    {
        _serviceProvider = serviceProvider;
        _signalProcessors = new Dictionary<Guid, ISignalProcessor>();
    }

    public ISignalProcessor GetSignalProcessor(Type type, Guid id)
    {
        if (!_signalProcessors.TryGetValue(id, out var instance))
        {
            instance = (ISignalProcessor)_serviceProvider.GetRequiredService(type);
            _signalProcessors.Add(id, instance);
        }

        return instance;
    }

    public ISignalProcessor FindSignalProcessor(Guid id)
    {
        if (_signalProcessors.TryGetValue(id, out var instance))
        {
            return instance;
        }

        throw new ControllerException($"Could not find signal processor with ID '{id}'.");
    }

    public IEnumerable<TSignalProcessor> GetSignalProcessors<TSignalProcessor>()
        where TSignalProcessor : ISignalProcessor
    {
        return _signalProcessors.Values.OfType<TSignalProcessor>();
    }
}
