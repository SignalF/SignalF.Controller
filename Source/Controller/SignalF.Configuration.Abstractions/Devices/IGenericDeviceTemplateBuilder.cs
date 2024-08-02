﻿using SignalF.Datamodel.Devices;

namespace SignalF.Configuration.Devices;

public interface
    IGenericDeviceTemplateBuilder : IGenericDeviceTemplateBuilder<IGenericDeviceTemplateBuilder, IGenericDeviceTemplate, GenericDeviceOptions>
{
}

public interface IGenericDeviceTemplateBuilder<out TBuilder, in TConfiguration, in TOptions> : IDeviceTemplateBuilder<TBuilder, TConfiguration, TOptions>
    where TBuilder : IGenericDeviceTemplateBuilder<TBuilder, TConfiguration, TOptions>
    where TConfiguration : IGenericDeviceTemplate
    where TOptions : GenericDeviceOptions
{
}
