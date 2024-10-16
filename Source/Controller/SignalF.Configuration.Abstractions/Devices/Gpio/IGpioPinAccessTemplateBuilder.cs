﻿using SignalF.Configuration.SignalConfiguration;
using SignalF.Datamodel.Hardware;

namespace SignalF.Configuration.Devices.Gpio;

public interface
    IGpioPinAccessTemplateBuilder : IGpioPinAccessTemplateBuilder<IGpioPinAccessTemplateBuilder, IGpioPinAccessTemplate, GpioPinAccessOptions>
{
}

public interface
    IGpioPinAccessTemplateBuilder<out TBuilder, in TConfiguration, in TOptions> : ISignalProcessorTemplateBuilder<TBuilder, TConfiguration, TOptions>
    where TBuilder : IGpioPinAccessTemplateBuilder<TBuilder, TConfiguration, TOptions>
    where TConfiguration : IGpioPinAccessTemplate
    where TOptions : GpioPinAccessOptions
{
}
