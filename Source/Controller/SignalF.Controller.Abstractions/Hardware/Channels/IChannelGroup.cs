using System;
using System.Collections.Generic;
using SignalF.Datamodel.Hardware;

namespace SignalF.Controller.Hardware.Channels;

public interface IChannelGroup
{
    Guid Id { get; }

    string Name { get; }
    void Open();

    void Close();

    /// <summary>
    ///     Configures the DataOutput.
    /// </summary>
    /// <param name="configuration"></param>
    /// <param name="channelFactory"></param>
    void Configure(IChannelGroupConfiguration configuration, Func<IList<IChannel>> channelFactory);

    IChannel GetChannel(string name);

    TChannel GetChannel<TChannel>(string name)
        where TChannel : IChannel;
}
