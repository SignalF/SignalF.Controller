using SignalF.Datamodel.Hardware;

namespace SignalF.Configuration.Hardware.OneWire;

public class OneWireDeviceBindingBuilder
    : DeviceBindingBuilder<OneWireDeviceBindingBuilder, IOneWireDeviceBindingBuilder, IOneWireDeviceBindingConfiguration, OneWireDeviceBindingOptions>
      , IOneWireDeviceBindingBuilder
{
    protected override IOneWireDeviceBindingBuilder This => this;
}
