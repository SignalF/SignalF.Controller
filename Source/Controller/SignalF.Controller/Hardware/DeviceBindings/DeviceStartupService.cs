using Scotec.Extensions.Linq;
using SignalF.Controller.Hardware.Channels;

namespace SignalF.Controller.Hardware.DeviceBindings;

public class DeviceStartupService : IService
{
    private readonly IChannelGroupFactory _channelGroupFactory;

    public DeviceStartupService(IChannelGroupFactory channelGroupFactory)
    {
        _channelGroupFactory = channelGroupFactory;
    }

    public void Initialize()
    {
        _channelGroupFactory.GetChannelGroups<IChannelGroup>().ForAll(channelGroup => channelGroup.Open());
    }

    public void Run()
    {
    }

    public void Shutdown()
    {
        _channelGroupFactory.GetChannelGroups<IChannelGroup>().ForAll(channelGroup => channelGroup.Close());
    }
}
