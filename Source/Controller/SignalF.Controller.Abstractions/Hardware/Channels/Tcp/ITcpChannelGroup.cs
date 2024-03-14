﻿using System.Net.Sockets;

namespace SignalF.Controller.Hardware.Channels.Tcp;

public interface ITcpChannelGroup : IChannelGroup
{
    /// <summary>
    ///     Returns the NetworkStream used to send and receive data.
    /// </summary>
    /// <returns>The underlying NetworkStream.</returns>
    NetworkStream GetStream(int port);
}
