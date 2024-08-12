﻿﻿
// <auto-generated />
#pragma warning disable

using SignalF.Configuration.Devices;
using SignalF.Datamodel.Hardware;

namespace SourceGenerator.dev;

public partial interface
    IClass3DeviceTemplateBuilder : IClass3DeviceTemplateBuilder<IClass3DeviceTemplateBuilder,
        IDeviceTemplate, Class3DeviceOptions>
{
}

public partial interface
    IClass3DeviceTemplateBuilder<out TBuilder, in TConfiguration, in TOptions> : IDeviceTemplateBuilder<TBuilder, TConfiguration,
        TOptions>
    where TBuilder : IDeviceTemplateBuilder<TBuilder, TConfiguration, TOptions>
    where TConfiguration : IDeviceTemplate
    where TOptions : Class3DeviceOptions
{
}

public partial class Class3DeviceTemplateBuilder
    : Class3DeviceTemplateBuilder<Class3DeviceTemplateBuilder, IClass3DeviceTemplateBuilder,
          IDeviceTemplate, Class3DeviceOptions>, IClass3DeviceTemplateBuilder
{
    protected override IClass3DeviceTemplateBuilder This => this;
}

public abstract partial class Class3DeviceTemplateBuilder<TImpl, TBuilder, TConfiguration, TOptions>
    : DeviceTemplateBuilder<TImpl, TBuilder, TConfiguration, TOptions>
      , IClass3DeviceTemplateBuilder<TBuilder, TConfiguration, TOptions>
    where TBuilder : IClass3DeviceTemplateBuilder<TBuilder, TConfiguration, TOptions>
    where TImpl : Class3DeviceTemplateBuilder<TImpl, TBuilder, TConfiguration, TOptions>
    where TConfiguration : IDeviceTemplate
    where TOptions : Class3DeviceOptions
{
}
