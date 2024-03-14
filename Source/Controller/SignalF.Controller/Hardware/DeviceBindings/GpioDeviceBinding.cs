#region

using System;
using System.Collections.Generic;
using System.Device.Gpio;
using SignalF.Datamodel.Hardware;

#endregion

namespace SignalF.Controller.Hardware.DeviceBindings;

public class GpioDeviceBinding : DeviceBinding<IGpioDeviceBindingConfiguration>, IGpioDeviceBinding
{
    private Dictionary<int, PinInfo> _exclusiveOpenedPins;
    private GpioController _gpioController;

    public EGpioPinValue ReadPinValue(int pinNumber)
    {
        if (_exclusiveOpenedPins.TryGetValue(pinNumber, out var pinInfo))
        {
            switch (pinInfo.DriveMode)
            {
                case EGpioPinDriveMode.Input:
                case EGpioPinDriveMode.InputPullDown:
                case EGpioPinDriveMode.InputPullUp:
                    return _gpioController.Read(pinNumber).Convert();
                case EGpioPinDriveMode.Output:
                case EGpioPinDriveMode.OutputOpenDrain:
                case EGpioPinDriveMode.OutputOpenDrainPullUp:
                case EGpioPinDriveMode.OutputOpenSource:
                case EGpioPinDriveMode.OutputOpenSourcePullDown:
                    throw new InvalidOperationException("Cannot not read from output pin");
                default:
                    throw new ArgumentException($@"Unhandled enum value '{pinInfo.DriveMode}'.");
            }
        }

        OpenPinInternal(pinNumber, EGpioPinDriveMode.Input, EGpioSharingMode.SharedReadOnly);
        var value = _gpioController.Read(pinNumber).Convert();
        ClosePinInternal(pinNumber);

        return value;
    }

    public void OpenPin(int pinNumber, EGpioPinDriveMode driveMode, EGpioSharingMode sharingMode)
    {
        OpenPinInternal(pinNumber, driveMode, sharingMode);
    }

    public void ClosePin(int pinNumber)
    {
        ClosePinInternal(pinNumber);
    }

    public void WritePinValue(int pinNumber, EGpioPinValue pinValue)
    {
        if (_exclusiveOpenedPins.TryGetValue(pinNumber, out var pinInfo))
        {
            switch (pinInfo.DriveMode)
            {
                case EGpioPinDriveMode.Input:
                case EGpioPinDriveMode.InputPullDown:
                case EGpioPinDriveMode.InputPullUp:
                    throw new InvalidOperationException("Cannot not write to input pin");
                case EGpioPinDriveMode.Output:
                case EGpioPinDriveMode.OutputOpenDrain:
                case EGpioPinDriveMode.OutputOpenDrainPullUp:
                case EGpioPinDriveMode.OutputOpenSource:
                case EGpioPinDriveMode.OutputOpenSourcePullDown:
                    _gpioController.Write(pinNumber, pinValue.Convert());
                    break;
                default:
                    throw new ArgumentException($@"Unhandled enum value '{pinInfo.DriveMode}'.");
            }

            return;
        }

        // Temporarily open an pin and write the value.
        OpenPinInternal(pinNumber, EGpioPinDriveMode.Output, EGpioSharingMode.Exclusive);
        _gpioController.Write(pinNumber, pinValue.Convert());
        ClosePinInternal(pinNumber);
    }

    public override void Open()
    {
        _gpioController = new GpioController();
        _exclusiveOpenedPins = new Dictionary<int, PinInfo>();
    }

    public override void Close()
    {
        _gpioController?.Dispose();
        _gpioController = null;
        _exclusiveOpenedPins = null;
    }

    protected override void OnConfigure(IGpioDeviceBindingConfiguration configuration)
    {
    }

    private void OpenPinInternal(int pinNumber, EGpioPinDriveMode driveMode, EGpioSharingMode sharingMode)
    {
        if (sharingMode == EGpioSharingMode.Exclusive && _exclusiveOpenedPins.ContainsKey(pinNumber))
        {
            throw new Exception("Pin is already opened in exclusive mode.");
        }

        _gpioController.OpenPin(pinNumber, driveMode.Convert());

        if (!_gpioController.IsPinOpen(pinNumber))
        {
            throw new ArgumentException("Pin could not be opened");
        }

        _gpioController.SetPinMode(pinNumber, driveMode.Convert());

        if (sharingMode == EGpioSharingMode.Exclusive)
        {
            _exclusiveOpenedPins.Add(pinNumber, new PinInfo { DriveMode = driveMode, Pin = pinNumber });
        }
    }

    private void ClosePinInternal(int pinNumber)
    {
        _gpioController.ClosePin(pinNumber);

        if (_gpioController.IsPinOpen(pinNumber))
        {
            throw new Exception("Pin could not be closed.");
        }

        if (_exclusiveOpenedPins.ContainsKey(pinNumber))
        {
            _exclusiveOpenedPins.Remove(pinNumber);
        }
    }

    private struct PinInfo
    {
        public int Pin;
        public EGpioPinDriveMode DriveMode;
    }
}
