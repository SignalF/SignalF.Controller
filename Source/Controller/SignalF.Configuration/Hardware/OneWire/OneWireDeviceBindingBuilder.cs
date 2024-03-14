﻿using SignalF.Controller.Configuration;
using SignalF.Datamodel.Hardware;

namespace SignalF.Configuration.Hardware.OneWire;

public class OneWireDeviceBindingBuilder
    : DeviceBindingBuilder<OneWireDeviceBindingBuilder, IOneWireDeviceBindingBuilder, IOneWireDeviceBindingConfiguration, CoreConfigurationOptions>
      , IOneWireDeviceBindingBuilder
{
    protected override IOneWireDeviceBindingBuilder This => this;
}
