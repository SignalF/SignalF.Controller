﻿﻿
// <auto-generated />
#pragma warning disable

using SignalF.Configuration.Devices;
using SignalF.Datamodel.Hardware;

namespace SourceGenerator.dev;

public partial interface
    IClass3DeviceDefinitionBuilder : IClass3DeviceDefinitionBuilder<IClass3DeviceDefinitionBuilder,
        IDeviceDefinition, Class3DeviceOptions>
{
}

public partial interface
    IClass3DeviceDefinitionBuilder<out TBuilder, in TConfiguration, in TOptions> : IDeviceDefinitionBuilder<TBuilder, TConfiguration,
        TOptions>
    where TBuilder : IDeviceDefinitionBuilder<TBuilder, TConfiguration, TOptions>
    where TConfiguration : IDeviceDefinition
    where TOptions : Class3DeviceOptions
{
}

public partial class Class3DeviceDefinitionBuilder
    : Class3DeviceDefinitionBuilder<Class3DeviceDefinitionBuilder, IClass3DeviceDefinitionBuilder,
          IDeviceDefinition, Class3DeviceOptions>, IClass3DeviceDefinitionBuilder
{
    protected override IClass3DeviceDefinitionBuilder This => this;
}

public abstract partial class Class3DeviceDefinitionBuilder<TImpl, TBuilder, TConfiguration, TOptions>
    : DeviceDefinitionBuilder<TImpl, TBuilder, TConfiguration, TOptions>
      , IClass3DeviceDefinitionBuilder<TBuilder, TConfiguration, TOptions>
    where TBuilder : IClass3DeviceDefinitionBuilder<TBuilder, TConfiguration, TOptions>
    where TImpl : Class3DeviceDefinitionBuilder<TImpl, TBuilder, TConfiguration, TOptions>
    where TConfiguration : IDeviceDefinition
    where TOptions : Class3DeviceOptions
{
}
