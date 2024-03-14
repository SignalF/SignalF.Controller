using SignalF.Controller.Hardware.DeviceBindings;
using SignalF.Datamodel.Hardware;

namespace SignalF.Controller.Hardware.Channels.Gpio;

public interface IGpioChannelGroup : IChannelGroup
{
    /// <summary>
    ///     Gets or sets the GPIO controller.
    /// </summary>
    IGpioDeviceBinding GpioController { get; }

    /// <summary>
    ///     Opens specified pin.
    /// </summary>
    /// <param name="pinNumber">Pin to open.</param>
    /// <param name="driveMode">The drive mode.</param>
    /// <param name="sharingMode">The sharing mode.</param>
    void OpenPin(int pinNumber, EGpioPinDriveMode driveMode, EGpioSharingMode sharingMode);

    /// <summary>
    ///     Closes the specified pin.
    /// </summary>
    /// <param name="pinNumber">Pin to close.</param>
    void ClosePin(int pinNumber);

    /// <summary>
    ///     Reads value from specified pin.
    /// </summary>
    /// <param name="pinNumber">Pin to read from.</param>
    /// <returns>Current value of pin.</returns>
    EGpioPinValue ReadPinValue(int pinNumber);

    /// <summary>
    ///     Writes a value to the specified pin.
    /// </summary>
    /// <param name="pinNumber">Pin to write to.</param>
    /// <param name="value">New pin value.</param>
    void WritePinValue(int pinNumber, EGpioPinValue value);
}
