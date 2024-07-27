using SignalF.Datamodel.Configuration;
using SignalF.Datamodel.Hardware;

namespace SignalF.Configuration.Hardware;

public abstract class ChannelMappingBuilder
{
    protected static IChannelConfiguration GetChannel(IControllerConfiguration configuration, string channelName)
    {
        var parts = channelName.Split('.');
        if (parts.Length != 2)
        {
            throw new ConfigurationBuilderException($"Invalid channel name '{channelName}'. Thje channel name must be in the form 'ChannelGroup.Channel'.");
        }

        var channelGroup = configuration.HardwareConfiguration.ChannelGroups.FirstOrDefault(item => item.Name == parts[0]);
        if (channelGroup == null)
        {
            throw new ConfigurationBuilderException($"Unknown channel group '{channelName}'. Cannot find channel group '{parts[0]}'.");
        }

        var channel = channelGroup.Channels.FirstOrDefault(item => item.Name == parts[1]);
        if (channel == null)
        {
            throw new ConfigurationBuilderException($"Unknown channel name '{channelName}'. Cannot find channel '{parts[0]}'.");
        }

        return channel;
    }
}
