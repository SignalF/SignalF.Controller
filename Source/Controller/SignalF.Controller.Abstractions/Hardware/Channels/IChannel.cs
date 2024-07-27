using SignalF.Datamodel.Hardware;

namespace SignalF.Controller.Hardware.Channels;

public interface IChannel
{
    public IChannelGroup ChannelGroup { get; set; }

    string Name { get; }

    string FullName { get; }

    Guid Id { get; }

    void Configure(IChannelConfiguration configuration);
}
