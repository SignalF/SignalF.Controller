namespace SignalF.Controller.Hardware.Channels.OneWire;

public interface IOneWireChannelGroup : IChannelGroup
{
    /// <summary>
    ///     Reads data from the inter-integrated circuit (I2c) bus on which the device is connected into the specified buffer.
    /// </summary>
    /// <param name="buffer">
    ///     The buffer to which you want to read the data from the I2c bus. The length of the buffer
    ///     determines how much data to request from the device.
    /// </param>
    void Read(int pin, Span<byte> buffer);

    /// <summary>
    ///     Writes data to the inter-integrated circuit (I2c) bus on which the device is connected, based on the bus address
    ///     specified in the I2cConnectionSettings object that you used to create the I2cDevice object.
    /// </summary>
    /// <param name="buffer">
    ///     A buffer that contains the data that you want to write to the I2c device. This data should not
    ///     include the bus address.
    /// </param>
    void Write(int pin, Span<byte> buffer);

    /// <summary>
    ///     Performs an atomic operation to write data to and then read data from the inter-integrated circuit (I2c) bus on
    ///     which the device is connected, and sends a restart condition between the write and read operations.
    /// </summary>
    /// <param name="writeBuffer">
    ///     A buffer that contains the data that you want to write to the I2c device. This data should
    ///     not include the bus address.
    /// </param>
    /// <param name="readBuffer">
    ///     The buffer to which you want to read the data from the I2c bus. The length of the buffer
    ///     determines how much data to request from the device.
    /// </param>
    void WriteRead(int pin, Span<byte> writeBuffer, Span<byte> readBuffer);
}
