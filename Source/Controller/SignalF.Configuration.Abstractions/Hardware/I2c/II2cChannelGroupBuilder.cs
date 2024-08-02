using SignalF.Configuration.Hardware;
using SignalF.Configuration.Hardware.I2c;
using SignalF.Datamodel.Hardware;

public interface
    II2cChannelGroupBuilder : IChannelGroupBuilder<II2cChannelGroupBuilder, II2cChannelGroupConfiguration, II2CChannelConfigurationBuilder,
        II2cChannelConfiguration, I2cChannelOptions>
{
}
