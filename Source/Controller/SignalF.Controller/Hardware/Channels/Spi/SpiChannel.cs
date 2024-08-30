using SignalF.Datamodel.Hardware;

namespace SignalF.Controller.Hardware.Channels.Spi;

public class SpiChannel : Channel<ISpiChannelConfiguration>, ISpiChannel
{
    public void Read(Span<byte> readBuffer)
    {
        throw new NotImplementedException();
    }

    public void TransferFullDuplex(ReadOnlySpan<byte> writeBuffer, Span<byte> readBuffer)
    {
        throw new NotImplementedException();
    }

    public void TransferSequential(ReadOnlySpan<byte> writeBuffer, Span<byte> readBuffer)
    {
        throw new NotImplementedException();
    }

    public void Write(ReadOnlySpan<byte> buffer)
    {
        throw new NotImplementedException();
    }

    protected override void OnConfigure(ISpiChannelConfiguration configuration)
    {
    }
}
