using SignalF.Controller.Configuration;
using SignalF.Datamodel.Hardware;

namespace SignalF.Configuration.Hardware.Gpio;

public class GpioDeviceBindingBuilder
    : DeviceBindingBuilder<GpioDeviceBindingBuilder, IGpioDeviceBindingBuilder, IGpioDeviceBindingConfiguration, CoreConfigurationOptions>
      , IGpioDeviceBindingBuilder
{
    protected override IGpioDeviceBindingBuilder This => this;
}
