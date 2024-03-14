using SignalF.Datamodel.Configuration;
using SignalF.Datamodel.Hardware;

namespace SignalF.Configuration.Hardware;

public abstract class ChannelMappingBuilder
{
    protected static IChannelConfiguration GetChannel(IControllerConfiguration configuration, string channelName)
    {
        var parts = channelName.Split('.');
        var channelGroup = configuration.HardwareConfiguration.ChannelGroups
                                        .First(item => item.Name == parts[0]);
        var channel = channelGroup.Channels.First(item => item.Name == parts[1]);
        return channel;
    }
}
