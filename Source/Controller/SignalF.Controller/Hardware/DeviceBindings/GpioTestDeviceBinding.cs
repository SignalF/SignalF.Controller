using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using SignalF.Datamodel.Hardware;

namespace SignalF.Controller.Hardware.DeviceBindings;

/// <summary>
///     Gpio is not supported on Windows. Therefore the application uses the GpioTestController for testing..
/// </summary>
public class GpioTestDeviceBinding : DeviceBinding<IGpioDeviceBindingConfiguration>,
                                     IGpioDeviceBinding
{
    private readonly IDictionary<int, EGpioPinValue> _pinValues = new ConcurrentDictionary<int, EGpioPinValue>();

    public void OpenPin(int pinNumber, EGpioPinDriveMode driveMode, EGpioSharingMode sharingMode)
    {
        _pinValues.Add(pinNumber, EGpioPinValue.Low);
    }

    public void ClosePin(int pinNumber)
    {
        _pinValues.Remove(pinNumber);
    }

    public EGpioPinValue ReadPinValue(int pinNumber)
    {
        var value = _pinValues[pinNumber];
        Console.WriteLine($"Read value '{value}' from pin{pinNumber}");

        return value;
    }

    public void WritePinValue(int pinNumber, EGpioPinValue value)
    {
        Console.WriteLine($"Write value '{value}' to pin{pinNumber}");
        _pinValues[pinNumber] = value;
    }

    public override void Open()
    {
    }

    public override void Close()
    {
    }

    protected override void OnConfigure(IGpioDeviceBindingConfiguration configuration)
    {
    }
}
