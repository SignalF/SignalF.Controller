using SignalF.Datamodel.Hardware;

namespace SignalF.Configuration.Hardware.Gpio;

public interface IGpioChannelGroupBuilder
    : IChannelGroupBuilder<IGpioChannelGroupBuilder, IGpioChannelGroupConfiguration, IGpioChannelConfigurationBuilder, IGpioChannelConfiguration>
{
}
