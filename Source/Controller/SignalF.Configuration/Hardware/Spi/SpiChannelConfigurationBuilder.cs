using SignalF.Controller.Configuration;
using SignalF.Datamodel.Hardware;

namespace SignalF.Configuration.Hardware.Spi;

public class SpiChannelConfigurationBuilder :
    ChannelConfigurationBuilder<SpiChannelConfigurationBuilder, ISpiChannelConfigurationBuilder, ISpiChannelConfiguration, SignalFConfigurationOptions>,
    ISpiChannelConfigurationBuilder
{
    private EGpioPinValue _activeState;
    private int _chipSelectLine;
    private int _clockFrequency;
    private int _dataBitLength;
    private ESpiDataFlow _dataFlow;
    private ESpiMode _spiMode;

    protected override ISpiChannelConfigurationBuilder This => this;

    public ISpiChannelConfigurationBuilder SetClockFrequency(int clockFrequency)
    {
        _clockFrequency = clockFrequency;
        return this;
    }

    public ISpiChannelConfigurationBuilder SetSpiMode(ESpiMode spiMode)
    {
        _spiMode = spiMode;
        return this;
    }

    public ISpiChannelConfigurationBuilder SetChipSelectLine(int chipSelectLine)
    {
        _chipSelectLine = chipSelectLine;
        return this;
    }

    public ISpiChannelConfigurationBuilder SetChipSelectLineActiveState(EGpioPinValue activeState)
    {
        _activeState = activeState;
        return this;
    }

    public ISpiChannelConfigurationBuilder SetDataBitLength(int dataBitLength)
    {
        _dataBitLength = dataBitLength;
        return this;
    }

    public ISpiChannelConfigurationBuilder SetDataFlow(ESpiDataFlow dataFlow)
    {
        _dataFlow = dataFlow;
        return this;
    }

    public override void Build(ISpiChannelConfiguration configuration)
    {
        base.Build(configuration);

        configuration.ChipSelectLine = _chipSelectLine;
        configuration.ChipSelectLineActiveState = _activeState;
        configuration.ClockFrequency = _clockFrequency;
        configuration.DataBitLength = _dataBitLength;
        configuration.DataFlow = _dataFlow;
        configuration.Mode = _spiMode;
    }
}
