using SignalF.Datamodel.Hardware;

namespace SignalF.Controller.Hardware.Channels.I2c;

public class I2cChannel : Channel<II2cChannelConfiguration>, II2cChannel
{
    private int _deviceAddress;
    public II2cChannelGroup I2cChannelGroup => (I2cChannelGroup)ChannelGroup;

    public void Read(Span<byte> buffer)
    {
        I2cChannelGroup.Read(_deviceAddress, buffer);
    }

    public byte ReadByte()
    {
        return I2cChannelGroup.ReadByte(_deviceAddress);
    }

    public void Write(ReadOnlySpan<byte> buffer)
    {
        I2cChannelGroup.Write(_deviceAddress, buffer);
    }

    public void WriteByte(byte data)
    {
        I2cChannelGroup.WriteByte(_deviceAddress, data);
    }

    public void WriteRead(ReadOnlySpan<byte> writeBuffer, Span<byte> readBuffer)
    {
        I2cChannelGroup.WriteRead(_deviceAddress, writeBuffer, readBuffer);
    }

    protected override void OnConfigure(II2cChannelConfiguration configuration)
    {
        _deviceAddress = configuration.DeviceAddress;
    }
}
