﻿using SignalF.Controller;
using SignalF.Controller.Configuration;
using SignalF.Datamodel.Hardware;

namespace SignalF.Configuration.Hardware;

public class ChannelConfigurationBuilder :
    ChannelConfigurationBuilder<ChannelConfigurationBuilder, IChannelConfigurationBuilder, IChannelConfiguration, SignalFConfigurationOptions>,
    IChannelConfigurationBuilder
{
    protected override IChannelConfigurationBuilder This => this;
}

public abstract class ChannelConfigurationBuilder<TImpl, TBuilder, TConfiguration, TOptions>
    : SignalFConfigurationBuilder<TImpl, TBuilder, TConfiguration, TOptions>,
      IChannelConfigurationBuilder<TBuilder, TConfiguration, TOptions>
    where TBuilder : IChannelConfigurationBuilder<TBuilder, TConfiguration, TOptions>
    where TImpl : ChannelConfigurationBuilder<TImpl, TBuilder, TConfiguration, TOptions>
    where TConfiguration : IChannelConfiguration
    where TOptions : SignalFConfigurationOptions
{
}
