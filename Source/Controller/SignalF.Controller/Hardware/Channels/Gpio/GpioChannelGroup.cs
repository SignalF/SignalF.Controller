using SignalF.Controller.Hardware.DeviceBindings;
using SignalF.Datamodel.Hardware;

namespace SignalF.Controller.Hardware.Channels.Gpio;

public class GpioChannelGroup : ChannelGroup<IGpioChannelGroupConfiguration>, IGpioChannelGroup
{
    public GpioChannelGroup(IGpioDeviceBinding deviceBinding)
    {
        GpioController = deviceBinding;
    }

    public IGpioDeviceBinding GpioController { get; }

    public void OpenPin(int pinNumber, EGpioPinDriveMode driveMode, EGpioSharingMode sharingMode)
    {
        GpioController.OpenPin(pinNumber, driveMode, sharingMode);
    }

    public void ClosePin(int pinNumber)
    {
        GpioController.ClosePin(pinNumber);
    }

    public EGpioPinValue ReadPinValue(int pinNumber)
    {
        return GpioController.ReadPinValue(pinNumber);
    }

    public void WritePinValue(int pinNumber, EGpioPinValue value)
    {
        GpioController.WritePinValue(pinNumber, value);
    }

    public override void Open()
    {
        GpioController.Open();
    }

    public override void Close()
    {
        GpioController.Close();
    }

    protected override void OnConfigure(IGpioChannelGroupConfiguration configuration)
    {
    }
}
