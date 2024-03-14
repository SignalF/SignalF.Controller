#region

using System;
using System.Device.I2c;

#endregion

namespace SignalF.Controller.Hardware.DeviceBindings;

public interface II2cDeviceBinding : IDeviceBinding
{
    /// <summary>
    ///     Return the I2cDevice for direct access. This ist used for devices es from IoT.Device.Bindings.
    /// </summary>
    I2cBus I2cBus { get; }

    void ConfigureDevices(int[] deviceAddresses);

    /// <summary>
    ///     Reads data from the inter-integrated circuit (I2c) bus on which the device is connected into the specified buffer.
    /// </summary>
    /// <param name="deviceAddress"></param>
    /// <param name="buffer">
    ///     The buffer to which you want to read the data from the I2c bus. The length of the buffer
    ///     determines how much data to request from the device.
    /// </param>
    void Read(int deviceAddress, Span<byte> buffer);

    /// <summary>
    ///     Reads a byte from the inter-integrated circuit (I2c) bus on which the device is connected into the specified
    ///     buffer.
    /// </summary>
    /// <param name="deviceAddress"></param>
    byte ReadByte(int deviceAddress);

    /// <summary>
    ///     Writes data to the inter-integrated circuit (I2c) bus on which the device is connected, based on the bus address
    ///     specified in the I2cConnectionSettings object that you used to create the I2cDevice object.
    /// </summary>
    /// <param name="deviceAddress"></param>
    /// <param name="buffer">
    ///     A buffer that contains the data that you want to write to the I2c device. This data should not
    ///     include the bus address.
    /// </param>
    void Write(int deviceAddress, Span<byte> buffer);

    /// <summary>
    ///     Writes data to the inter-integrated circuit (I2c) bus on which the device is connected, based on the bus address
    ///     specified in the I2cConnectionSettings object that you used to create the I2cDevice object.
    /// </summary>
    /// <param name="deviceAddress"></param>
    /// <param name="data">
    ///     A byte that you want to write to the I2c device.
    /// </param>
    void WriteByte(int deviceAddress, byte data);

    /// <summary>
    ///     Performs an atomic operation to write data to and then read data from the inter-integrated circuit (I2c) bus on
    ///     which the device is connected, and sends a restart condition between the write and read operations.
    /// </summary>
    /// <param name="deviceAddress"></param>
    /// <param name="writeBuffer">
    ///     A buffer that contains the data that you want to write to the I2c device. This data should
    ///     not include the bus address.
    /// </param>
    /// <param name="readBuffer">
    ///     The buffer to which you want to read the data from the I2c bus. The length of the buffer
    ///     determines how much data to request from the device.
    /// </param>
    void WriteRead(int deviceAddress, Span<byte> writeBuffer, Span<byte> readBuffer);
}
