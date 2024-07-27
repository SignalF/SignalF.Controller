#region

using SignalF.Datamodel.Hardware;

#endregion

namespace SignalF.Controller.Hardware.Channels;

public class ChannelGroup : ChannelGroup<IChannelGroupConfiguration>
{
    protected ChannelGroup()
    {
    }

    public override void Open()
    {
    }

    public override void Close()
    {
    }

    protected override void OnConfigure(IChannelGroupConfiguration configuration)
    {
    }
}

public abstract class ChannelGroup<TConfiguration> : IChannelGroup
    where TConfiguration : IChannelGroupConfiguration
{
    private Dictionary<string, IChannel> _channels;

    public void Configure(IChannelGroupConfiguration configuration, Func<IList<IChannel>> channelFactory)
    {
        Id = configuration.Id;
        Name = configuration.Name;

        OnConfigure((TConfiguration)configuration);

        _channels = channelFactory().ToDictionary(channel => channel.Name, channel => channel);
    }

    public abstract void Open();
    public abstract void Close();
    public Guid Id { get; private set; }

    public string Name { get; private set; }

    public IChannel GetChannel(string name)
    {
        return _channels[name];
    }

    public TChannel GetChannel<TChannel>(string name)
        where TChannel : IChannel
    {
        return (TChannel)_channels[name];
    }

    protected abstract void OnConfigure(TConfiguration configuration);
}
