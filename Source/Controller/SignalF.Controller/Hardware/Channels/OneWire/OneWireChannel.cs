using System;
using SignalF.Datamodel.Hardware;

namespace SignalF.Controller.Hardware.Channels.OneWire;

public class OneWireChannel : Channel<IOneWireChannelConfiguration>, IOneWireChannel
{
    public IOneWireChannelGroup OneWireChannelGroup => (IOneWireChannelGroup)ChannelGroup;

    public void Read(Span<byte> buffer)
    {
        throw new NotImplementedException();
    }

    public void Write(Span<byte> buffer)
    {
        throw new NotImplementedException();
    }

    public void WriteRead(Span<byte> writeBuffer, Span<byte> readBuffer)
    {
        throw new NotImplementedException();
    }

    protected override void OnConfigure(IOneWireChannelConfiguration configuration)
    {
    }
}
