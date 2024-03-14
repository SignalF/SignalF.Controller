﻿using SignalF.Configuration.SignalConfiguration;
using SignalF.Controller.Configuration;
using SignalF.Datamodel.Workflow;

namespace SignalF.Configuration.ProcessControl;

public interface
    IProcessControlTemplateBuilder : IProcessControlTemplateBuilder<IProcessControlTemplateBuilder, IProcessControlTemplate, CoreConfigurationOptions>
{
}

public interface
    IProcessControlTemplateBuilder<out TBuilder, in TConfiguration, in TOptions> : ISignalProcessorTemplateBuilder<TBuilder, TConfiguration, TOptions>
    where TBuilder : IProcessControlTemplateBuilder<TBuilder, TConfiguration, TOptions>
    where TConfiguration : IProcessControlTemplate
    where TOptions : CoreConfigurationOptions
{
}
