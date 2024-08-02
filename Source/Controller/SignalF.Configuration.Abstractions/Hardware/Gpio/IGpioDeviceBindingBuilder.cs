using SignalF.Datamodel.Hardware;

namespace SignalF.Configuration.Hardware.Gpio;

public interface IGpioDeviceBindingBuilder
    : IDeviceBindingBuilder<IGpioDeviceBindingBuilder, IGpioDeviceBindingConfiguration, GpioDeviceBindingOptions>
{
}
