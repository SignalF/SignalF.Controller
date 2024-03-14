using System;
using SignalF.Datamodel.Hardware;

namespace SignalF.Controller.Hardware.Channels.Spi;

public class SpiChannel : Channel<ISpiChannelConfiguration>, ISpiChannel
{
    public void Read(byte[] buffer)
    {
        throw new NotImplementedException();
    }

    public void TransferFullDuplex(Span<byte> writeBuffer, Span<byte> readBuffer)
    {
        throw new NotImplementedException();
    }

    public void TransferSequential(Span<byte> writeBuffer, Span<byte> readBuffer)
    {
        throw new NotImplementedException();
    }

    public void Write(Span<byte> buffer)
    {
        throw new NotImplementedException();
    }

    protected override void OnConfigure(ISpiChannelConfiguration configuration)
    {
    }
}
