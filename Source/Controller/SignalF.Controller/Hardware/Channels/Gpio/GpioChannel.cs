using SignalF.Datamodel.Hardware;

namespace SignalF.Controller.Hardware.Channels.Gpio;

public class GpioChannel : Channel<IGpioChannelConfiguration>, IGpioChannel
{
    private int _pinNumber;
    private IGpioChannelGroup GpioChannelGroup => (IGpioChannelGroup)ChannelGroup;

    public void OpenPin(EGpioPinDriveMode driveMode, EGpioSharingMode sharingMode)
    {
        GpioChannelGroup.OpenPin(_pinNumber, driveMode, sharingMode);
    }

    public void ClosePin()
    {
        GpioChannelGroup.ClosePin(_pinNumber);
    }

    public EGpioPinValue ReadPinValue()
    {
        return GpioChannelGroup.ReadPinValue(_pinNumber);
    }

    public void WritePinValue(EGpioPinValue value)
    {
        GpioChannelGroup.WritePinValue(_pinNumber, value);
    }

    protected override void OnConfigure(IGpioChannelConfiguration configuration)
    {
        _pinNumber = configuration.PinNumber;
    }
}
