using SignalF.Datamodel.Hardware;

namespace SignalF.Configuration.Hardware.Spi;

public interface
    ISpiChannelConfigurationBuilder : IChannelConfigurationBuilder<ISpiChannelConfigurationBuilder, ISpiChannelConfiguration, SpiChannelOptions>
{
    ISpiChannelConfigurationBuilder SetClockFrequency(int clockFrequency);

    ISpiChannelConfigurationBuilder SetSpiMode(ESpiMode spiMode);

    ISpiChannelConfigurationBuilder SetChipSelectLine(int chipSelectLine);

    ISpiChannelConfigurationBuilder SetChipSelectLineActiveState(EGpioPinValue activeState);

    ISpiChannelConfigurationBuilder SetDataBitLength(int dataBitLength);

    ISpiChannelConfigurationBuilder SetDataFlow(ESpiDataFlow dataFlow);
}
