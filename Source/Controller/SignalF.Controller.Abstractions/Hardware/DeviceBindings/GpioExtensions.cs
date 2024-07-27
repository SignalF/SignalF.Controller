#region

using System.Device.Gpio;
using SignalF.Datamodel.Hardware;

#endregion

namespace SignalF.Controller.Hardware.DeviceBindings;

public static class GpioExtensions
{
    // TODO: some drive modes are not yet supported with the .Net Core 3.0 preview driver
    // support for these modes is expected at some point
    // Issue tracking: https://github.com/dotnet/iot/issues/135
    public static EGpioPinDriveMode Convert(this PinMode value)
    {
        return value switch
        {
            PinMode.Input => EGpioPinDriveMode.Input, PinMode.InputPullDown => EGpioPinDriveMode.InputPullDown,
            PinMode.InputPullUp => EGpioPinDriveMode.InputPullUp, PinMode.Output => EGpioPinDriveMode.Output,
            _ => throw new ArgumentException($@"Invalid enum value '{value}'")
        };
    }

    public static PinMode Convert(this EGpioPinDriveMode value)
    {
        return value switch
        {
            EGpioPinDriveMode.Input => PinMode.Input, EGpioPinDriveMode.InputPullDown => PinMode.InputPullDown,
            EGpioPinDriveMode.InputPullUp => PinMode.InputPullUp, EGpioPinDriveMode.Output => PinMode.Output,
            EGpioPinDriveMode.OutputOpenDrain => throw new NotSupportedException("OutputOpenDrain drive mode is not supported."),
            EGpioPinDriveMode.OutputOpenDrainPullUp => throw new NotSupportedException("OutputOpenDrainPullUp drive mode is not supported."),
            EGpioPinDriveMode.OutputOpenSource => throw new NotSupportedException("OutputOpenSource drive mode is not supported."),
            EGpioPinDriveMode.OutputOpenSourcePullDown => throw new NotSupportedException("OutputOpenSourcePullDown drive mode is not supported."),
            _ => throw new ArgumentException($@"Invalid enum value '{value}'")
        };
    }

    public static EGpioPinValue Convert(this PinValue value)
    {
        return value == PinValue.High ? EGpioPinValue.High : EGpioPinValue.Low;
    }

    public static PinValue Convert(this EGpioPinValue value)
    {
        return value switch
        {
            EGpioPinValue.High => PinValue.High, EGpioPinValue.Low => PinValue.Low, _ => throw new ArgumentException($@"Invalid enum value '{value}'")
        };
    }
}
