#region

using System;
using System.Collections.Generic;
using System.Linq;
using SignalF.Controller.Hardware.Channels;
using SignalF.Controller.Signals.SignalProcessor;
using SignalF.Datamodel.Signals;

#endregion

namespace SignalF.Controller.Configuration;

public class SignalProcessorConfigurator : ISignalProcessorConfigurator
{
    private readonly IChannelGroupFactory _channelGroupFactory;
    private readonly ISignalProcessorFactory _signalProcessorFactory;

    public SignalProcessorConfigurator(ISignalProcessorFactory signalProcessorFactory, IChannelGroupFactory channelGroupFactory)
    {
        _signalProcessorFactory = signalProcessorFactory;
        _channelGroupFactory = channelGroupFactory;
    }

    public IList<ISignalProcessor> SignalProcessorList { get; } = new List<ISignalProcessor>();

    public void Configure(IList<ISignalProcessorConfiguration> signalProcessorConfigurations)
    {
        foreach (var signalProcessorConfiguration in signalProcessorConfigurations)
        {
            var definition = signalProcessorConfiguration.Definition;
            var template = signalProcessorConfiguration.Definition.Template;

            var type = signalProcessorConfiguration.GetCoreType()
                       ?? definition.GetCoreType()
                       ?? template.GetCoreType();

            if (type == null)
            {
                var message = $"No implementation type has been defined for signal process '{signalProcessorConfiguration.Name}'.";
                throw new ConfiguratorException(message);
            }

            var id = signalProcessorConfiguration.Id;
            var signalProcessor = _signalProcessorFactory.GetSignalProcessor(type, id);
            signalProcessor.Configure(signalProcessorConfiguration);
            SignalProcessorList.Add(signalProcessor);
        }

        // _channelGroups.ForAll(p => p.DistributeDeviceBindings());
    }

    public ISignalProcessor GetSignalProcessor(Guid id)
    {
        return SignalProcessorList.Single(processor => processor.Id == id);
    }

    public ISignalProcessor GetSignalProcessor(string name)
    {
        return SignalProcessorList.Single(processor => processor.Name == name);
    }
}
