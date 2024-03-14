using SignalF.Datamodel.Hardware;

namespace SignalF.Controller.Hardware.Channels.Gpio;

public interface IGpioChannel : IChannel
{
    /// <summary>
    ///     Opens the pin.
    /// </summary>
    /// <param name="driveMode">The drive mode.</param>
    /// <param name="sharingMode">The sharing mode.</param>
    void OpenPin(EGpioPinDriveMode driveMode, EGpioSharingMode sharingMode);

    /// <summary>
    ///     Closes the pin.
    /// </summary>
    void ClosePin();

    /// <summary>
    ///     Reads value from the pin.
    /// </summary>
    /// <returns>Current value of pin.</returns>
    EGpioPinValue ReadPinValue();

    /// <summary>
    ///     Writes a value to the pin.
    /// </summary>
    /// <param name="value">New pin value.</param>
    void WritePinValue(EGpioPinValue value);
}
