using System.Collections.Generic;
using SignalF.Controller.Hardware.Channels;
using SignalF.Controller.Hardware.DeviceBindings;
using SignalF.Datamodel.Hardware;

namespace SignalF.Controller.Configuration;

public class ChannelGroupConfigurator : IChannelGroupConfigurator
{
    private readonly IChannelGroupFactory _channelGroupFactory;
    private readonly IDeviceBindingFactory _deviceBindingFactory;

    public ChannelGroupConfigurator(IChannelGroupFactory channelGroupFactory, IDeviceBindingFactory deviceBindingFactory)
    {
        _channelGroupFactory = channelGroupFactory;
        _deviceBindingFactory = deviceBindingFactory;
    }

    public void Configure(IList<IChannelGroupConfiguration> channelGroupConfigurations)
    {
        foreach (var channelGroupConfiguration in channelGroupConfigurations)
        {
            var channelGroupType = channelGroupConfiguration.GetCoreType();

            if (channelGroupType == null)
            {
                var message = $"No implementation type has been defined for channel group '{channelGroupConfiguration.Name}'.";
                throw new ConfiguratorException(message);
            }

            var channelGroup = _channelGroupFactory.GetChannelGroup(channelGroupConfiguration);

            channelGroup.Configure(channelGroupConfiguration, () => CreateChannels(channelGroupConfiguration, channelGroup));
        }
    }

    private IList<IChannel> CreateChannels(IChannelGroupConfiguration channelGroupConfiguration, IChannelGroup channelGroup)
    {
        var channels = new List<IChannel>();
        foreach (var channelConfiguration in channelGroupConfiguration.Channels)
        {
            var channelType = channelConfiguration.GetCoreType();

            if (channelType == null)
            {
                var message = $"No implementation type has been defined for channel '{channelConfiguration.Name}'.";
                throw new ControllerException(message);
            }

            var channel = _channelGroupFactory.GetChannel(channelConfiguration);
            channel.ChannelGroup = channelGroup;
            channel.Configure(channelConfiguration);
            channels.Add(channel);
        }

        return channels;
    }
}
