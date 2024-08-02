using SignalF.Datamodel.Hardware;

namespace SignalF.Configuration.Hardware.Gpio;

public class GpioDeviceBindingBuilder
    : DeviceBindingBuilder<GpioDeviceBindingBuilder, IGpioDeviceBindingBuilder, IGpioDeviceBindingConfiguration, GpioDeviceBindingOptions>
      , IGpioDeviceBindingBuilder
{
    protected override IGpioDeviceBindingBuilder This => this;
}
