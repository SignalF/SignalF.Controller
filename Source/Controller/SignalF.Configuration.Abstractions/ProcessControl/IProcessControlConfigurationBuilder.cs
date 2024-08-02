﻿using SignalF.Configuration.SignalConfiguration;
using SignalF.Controller;
using SignalF.Controller.Configuration;
using SignalF.Datamodel.Workflow;

namespace SignalF.Configuration.ProcessControl;

public interface IProcessControlConfigurationBuilder : IProcessControlConfigurationBuilder<IProcessControlConfigurationBuilder, IProcessControlConfiguration
    , SignalFConfigurationOptions>
{
}

public interface
    IProcessControlConfigurationBuilder<out TBuilder, in TConfiguration, in TOptions> : ISignalProcessorConfigurationBuilder<TBuilder, TConfiguration,
        TOptions>
    where TBuilder : IProcessControlConfigurationBuilder<TBuilder, TConfiguration, TOptions>
    where TConfiguration : IProcessControlConfiguration
    where TOptions : SignalFConfigurationOptions
{
}
