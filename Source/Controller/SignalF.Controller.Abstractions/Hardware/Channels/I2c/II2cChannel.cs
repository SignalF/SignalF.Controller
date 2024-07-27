namespace SignalF.Controller.Hardware.Channels.I2c;

public interface II2cChannel : IChannel
{
    /// <summary>
    ///     Return the I2cDevice for direct access. This ist used for devices es from IoT.Device.Bindings.
    /// </summary>
    II2cChannelGroup I2cChannelGroup { get; }

    /// <summary>
    ///     Reads data from the inter-integrated circuit (I2c) bus on which the device is connected into the specified buffer.
    /// </summary>
    /// <param name="buffer">
    ///     The buffer to which you want to read the data from the I2c bus. The length of the buffer
    ///     determines how much data to request from the device.
    /// </param>
    void Read(Span<byte> buffer);

    /// <summary>
    ///     Reads a byte from the inter-integrated circuit (I2c) bus on which the device is connected into the specified
    ///     buffer.
    /// </summary>
    byte ReadByte();

    /// <summary>
    ///     Writes data to the inter-integrated circuit (I2c) bus on which the device is connected, based on the bus address
    ///     specified in the I2cConnectionSettings object that you used to create the I2cDevice object.
    /// </summary>
    /// <param name="buffer">
    ///     A buffer that contains the data that you want to write to the I2c device.
    /// </param>
    void Write(Span<byte> buffer);

    /// <summary>
    ///     Writes data to the inter-integrated circuit (I2c) bus on which the device is connected, based on the bus address
    ///     specified in the I2cConnectionSettings object that you used to create the I2cDevice object.
    /// </summary>
    /// <param name="data">
    ///     The data that you want to write to the I2c device.
    /// </param>
    void WriteByte(byte data);

    /// <summary>
    ///     Performs an atomic operation to write data to and then read data from the inter-integrated circuit (I2c) bus on
    ///     which the device is connected, and sends a restart condition between the write and read operations.
    /// </summary>
    /// <param name="writeBuffer">
    ///     A buffer that contains the data that you want to write to the I2c device.
    /// </param>
    /// <param name="readBuffer">
    ///     The buffer to which you want to read the data from the I2c bus. The length of the buffer
    ///     determines how much data to request from the device.
    /// </param>
    void WriteRead(Span<byte> writeBuffer, Span<byte> readBuffer);
}
