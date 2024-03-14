using SignalF.Datamodel.Hardware;

namespace SignalF.Controller.Hardware.DeviceBindings;

public class SpiDeviceSettings
{
    public int ChipSelectLine { get; set; }

    public ESpiMode Mode { get; set; }

    public ESpiDataFlow DataFlow { get; set; }

    public EGpioPinValue ChipSelectLineActiveState { get; set; }

    public int DataBitLength { get; set; }

    public int ClockFrequency { get; set; }
}
