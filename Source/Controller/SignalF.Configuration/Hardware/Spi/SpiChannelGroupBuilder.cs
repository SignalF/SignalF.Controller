﻿using SignalF.Configuration.Hardware;
using SignalF.Configuration.Hardware.Spi;
using SignalF.Datamodel.Hardware;

public class SpiChannelGroupBuilder
    : ChannelGroupBuilder<SpiChannelGroupBuilder, ISpiChannelGroupBuilder, ISpiChannelGroupConfiguration, ISpiChannelConfigurationBuilder,
          ISpiChannelConfiguration,
          SpiChannelOptions>
      , ISpiChannelGroupBuilder
{
    public SpiChannelGroupBuilder(Func<ISpiChannelConfigurationBuilder> channelBuilderFactory) : base(channelBuilderFactory)
    {
    }

    protected override ISpiChannelGroupBuilder This => this;

    public override void Build(ISpiChannelGroupConfiguration configuration)
    {
        base.Build(configuration);
    }
}
