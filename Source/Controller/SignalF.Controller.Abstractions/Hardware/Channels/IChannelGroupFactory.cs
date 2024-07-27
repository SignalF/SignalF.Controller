#region

using SignalF.Datamodel.Hardware;

#endregion

namespace SignalF.Controller.Hardware.Channels;

public interface IChannelGroupFactory
{
    IChannelGroup GetChannelGroup(IChannelGroupConfiguration channelGroupConfiguration);

    IChannel FindChannel(Guid id);

    IChannelGroup FindChannelGroup(Guid id);

    IChannel GetChannel(IChannelConfiguration channelConfiguration);

    /// <summary>
    ///     Returns all channel group instances of the given type.
    /// </summary>
    /// <remarks>A call to GetChannelGroups does not instantiate any new channel groups.</remarks>
    IEnumerable<TChannelGroup> GetChannelGroups<TChannelGroup>()
        where TChannelGroup : IChannelGroup;
}
