namespace SignalF.Controller.Hardware.Channels.Spi;

public interface ISpiChannelGroup : IChannelGroup
{
    /// <summary>
    ///     Reads data from the SPI device.
    /// </summary>
    /// <param name="chipSelectLine"></param>
    /// <param name="buffer">
    ///     The buffer to read the data from the SPI device.
    ///     The length of the buffer determines how much data to read from the SPI device.
    /// </param>
    void Read(int chipSelectLine, Span<byte> buffer);

    /// <summary>
    ///     Reads a byte from the SPI device.
    /// </summary>
    /// <param name="chipSelectLine"></param>
    /// <returns>A byte read from the SPI device.</returns>
    byte ReadByte(int chipSelectLine);

    /// <summary>
    ///     Writes and reads data from the SPI device.
    /// </summary>
    /// <param name="chipSelectLine"></param>
    /// <param name="writeBuffer">The buffer that contains the data to be written to the SPI device.</param>
    /// <param name="readBuffer">The buffer to read the data from the SPI device.</param>
    void TransferFullDuplex(int chipSelectLine, ReadOnlySpan<byte> writeBuffer, Span<byte> readBuffer);

    /// <summary>
    ///     Writes data to the SPI device.
    /// </summary>
    /// <param name="chipSelectLine"></param>
    /// <param name="buffer">
    ///     The buffer that contains the data to be written to the SPI device.
    /// </param>
    void Write(int chipSelectLine, ReadOnlySpan<byte> buffer);

    /// <summary>
    ///     Writes a byte to the SPI device.
    /// </summary>
    /// <param name="chipSelectLine"></param>
    /// <param name="value">The byte to be written to the SPI device.</param>
    void WriteByte(int chipSelectLine, byte value);
}
