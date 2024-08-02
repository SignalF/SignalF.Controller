using SignalF.Datamodel.Hardware;

namespace SignalF.Configuration.Hardware.Spi;

public interface
    ISpiChannelGroupBuilder : IChannelGroupBuilder<ISpiChannelGroupBuilder, ISpiChannelGroupConfiguration, ISpiChannelConfigurationBuilder,
        ISpiChannelConfiguration, SpiChannelOptions>
{
}
