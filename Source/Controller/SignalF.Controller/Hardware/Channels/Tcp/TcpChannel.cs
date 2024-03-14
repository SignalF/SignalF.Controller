using System;
using System.Net.Sockets;
using SignalF.Datamodel.Hardware;

namespace SignalF.Controller.Hardware.Channels.Tcp;

public class TcpChannel : Channel<ITcpChannelConfiguration>, ITcpChannel
{
    public NetworkStream GetStream()
    {
        throw new NotImplementedException();
    }

    protected override void OnConfigure(ITcpChannelConfiguration configuration)
    {
    }
}
