using System;
using SignalF.Datamodel.Hardware;

namespace SignalF.Controller.Hardware.Channels;

public class Channel : Channel<ITcpChannelConfiguration>
{
    protected override void OnConfigure(ITcpChannelConfiguration configuration)
    {
    }
}

public abstract class Channel<TConfiguration> : IChannel
    where TConfiguration : IChannelConfiguration
{
    public IChannelGroup ChannelGroup { get; set; }

    public string Name { get; private set; }
    public string FullName => $"{ChannelGroup.Name}.{Name}";

    public Guid Id { get; private set; }

    public void Configure(IChannelConfiguration configuration)
    {
        Name = configuration.Name;
        Id = configuration.Id;

        OnConfigure((TConfiguration)configuration);
    }

    protected abstract void OnConfigure(TConfiguration configuration);
}
