﻿using SignalF.Controller;
using SignalF.Controller.Configuration;
using SignalF.Datamodel.Hardware;

namespace SignalF.Configuration.Hardware.OneWire;

public class OneWireChannelGroupBuilder
    : ChannelGroupBuilder<OneWireChannelGroupBuilder, IOneWireChannelGroupBuilder, IOneWireChannelGroupConfiguration, IOneWireChannelConfigurationBuilder,
          IOneWireChannelConfiguration,
          SignalFConfigurationOptions>, IOneWireChannelGroupBuilder
{
    public OneWireChannelGroupBuilder(Func<IOneWireChannelConfigurationBuilder> channelBuilderFactory) : base(channelBuilderFactory)
    {
    }

    protected override IOneWireChannelGroupBuilder This => this;
}
