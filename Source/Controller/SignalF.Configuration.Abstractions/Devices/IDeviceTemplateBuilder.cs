﻿using SignalF.Configuration.SignalConfiguration;
using SignalF.Controller.Configuration;
using SignalF.Datamodel.Hardware;

namespace SignalF.Configuration.Devices;

public interface IDeviceTemplateBuilder : IDeviceTemplateBuilder<IDeviceTemplateBuilder, IDeviceTemplate, CoreConfigurationOptions>
{
}

public interface IDeviceTemplateBuilder<out TBuilder, in TConfiguration, in TOptions> : ISignalProcessorTemplateBuilder<TBuilder, TConfiguration, TOptions>
    where TBuilder : IDeviceTemplateBuilder<TBuilder, TConfiguration, TOptions>
    where TConfiguration : IDeviceTemplate
    where TOptions : CoreConfigurationOptions
{
}
