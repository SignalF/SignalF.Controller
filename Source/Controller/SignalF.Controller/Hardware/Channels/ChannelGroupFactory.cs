using System;
using System.Collections.Generic;
using System.Linq;
using SignalF.Controller.Configuration;
using SignalF.Controller.Hardware.DeviceBindings;
using SignalF.Datamodel.Hardware;

namespace SignalF.Controller.Hardware.Channels;

public class ChannelGroupFactory : IChannelGroupFactory
{
    private readonly Func<Type, IChannel> _channelFactory;
    private readonly Func<Type, IDeviceBinding, IChannelGroup> _channelGroupFactory;
    private readonly IDictionary<Guid, IChannelGroup> _channelGroups;
    private readonly IDictionary<Guid, IChannel> _channels;
    private readonly IDeviceBindingFactory _deviceBindingFactory;

    public ChannelGroupFactory(Func<Type, IDeviceBinding, IChannelGroup> channelGroupFactory, Func<Type, IChannel> channelFactory
                               , IDeviceBindingFactory deviceBindingFactory)
    {
        _channelGroupFactory = channelGroupFactory;
        _channelFactory = channelFactory;
        _deviceBindingFactory = deviceBindingFactory;
        _channelGroups = new Dictionary<Guid, IChannelGroup>();
        _channels = new Dictionary<Guid, IChannel>();
    }

    public IChannelGroup GetChannelGroup(IChannelGroupConfiguration channelGroupConfiguration)
    {
        var type = channelGroupConfiguration.GetCoreType();

        if (type == null)
        {
            var message = $"No implementation type has been defined for channel group '{channelGroupConfiguration.Name}'.";
            throw new ConfiguratorException(message);
        }

        if (channelGroupConfiguration.DeviceBinding == null)
        {
            throw new ConfiguratorException($"No device bnding has been specified for channel group '{channelGroupConfiguration.Name}'.");
        }

        if (!_channelGroups.TryGetValue(channelGroupConfiguration.Id, out var channelGroup))
        {
            var deviceBinding = _deviceBindingFactory.FindDeviceBinding(channelGroupConfiguration.DeviceBinding.Id);
            channelGroup = _channelGroupFactory(type, deviceBinding);

            _channelGroups.Add(channelGroupConfiguration.Id, channelGroup);
        }

        return channelGroup;
    }

    public IChannel FindChannel(Guid id)
    {
        if (_channels.TryGetValue(id, out var instance))
        {
            return instance;
        }

        throw new ControllerException($"Could not find channel with ID '{id}'.");
    }

    public IChannelGroup FindChannelGroup(Guid id)
    {
        if (_channelGroups.TryGetValue(id, out var instance))
        {
            return instance;
        }

        throw new ControllerException($"Could not find channel group with ID '{id}'.");
    }

    public IChannel GetChannel(IChannelConfiguration channelConfiguration)
    {
        if (!_channels.TryGetValue(channelConfiguration.Id, out var channel))
        {
            channel = _channelFactory(channelConfiguration.GetCoreType());
            _channels.Add(channelConfiguration.Id, channel);
        }

        return channel;
    }

    public IEnumerable<TChannelGroup> GetChannelGroups<TChannelGroup>()
        where TChannelGroup : IChannelGroup
    {
        return _channelGroups.Values.OfType<TChannelGroup>();
    }
}
