namespace SignalF.Controller.Hardware.Channels.Spi;

public interface ISpiChannel : IChannel
{
    /// <summary>
    ///     Reads from the connected device.
    /// </summary>
    /// <param name="buffer">Array containing data read from the device.</param>
    void Read(byte[] buffer);

    /// <summary>
    ///     Transfer data using a full duplex communication system. Full duplex allows both the master and the slave to
    ///     communicate simultaneously.
    /// </summary>
    /// <param name="writeBuffer">Array containing data to write to the device.</param>
    /// <param name="readBuffer">Array containing data read from the device.</param>
    void TransferFullDuplex(Span<byte> writeBuffer, Span<byte> readBuffer);

    /// <summary>
    ///     Transfer data sequentially to the device.
    /// </summary>
    /// <param name="writeBuffer">Array containing data to write to the device.</param>
    /// <param name="readBuffer">Array containing data read from the device.</param>
    void TransferSequential(Span<byte> writeBuffer, Span<byte> readBuffer);

    /// <summary>
    ///     Writes to the connected device.
    /// </summary>
    /// <param name="buffer">Array containing the data to write to the device.</param>
    void Write(Span<byte> buffer);
}
