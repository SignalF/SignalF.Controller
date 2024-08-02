﻿using SignalF.Configuration.SignalConfiguration;
using SignalF.Datamodel.Hardware;

namespace SignalF.Configuration.Devices.Gpio;

public class GpioPinAccessDefinitionBuilder
    : GpioPinAccessDefinitionBuilder<GpioPinAccessDefinitionBuilder, IGpioPinAccessDefinitionBuilder, IGpioPinAccessDefinition, GpioPinAccessOptions>,
      IGpioPinAccessDefinitionBuilder
{
    protected override IGpioPinAccessDefinitionBuilder This => this;
}

public abstract class GpioPinAccessDefinitionBuilder<TImpl, TBuilder, TConfiguration, TOptions>
    : SignalProcessorDefinitionBuilder<TImpl, TBuilder, TConfiguration, TOptions>, IGpioPinAccessDefinitionBuilder<TBuilder, TConfiguration, TOptions>
    where TBuilder : IGpioPinAccessDefinitionBuilder<TBuilder, TConfiguration, TOptions>
    where TImpl : GpioPinAccessDefinitionBuilder<TImpl, TBuilder, TConfiguration, TOptions>
    where TConfiguration : IGpioPinAccessDefinition
    where TOptions : GpioPinAccessOptions
{
    public override void Build(TConfiguration configuration)
    {
        base.Build(configuration);
    }
}
