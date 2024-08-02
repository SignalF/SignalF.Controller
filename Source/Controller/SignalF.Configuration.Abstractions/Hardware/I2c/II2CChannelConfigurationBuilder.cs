using SignalF.Datamodel.Hardware;

namespace SignalF.Configuration.Hardware.I2c;

public interface
    II2CChannelConfigurationBuilder : IChannelConfigurationBuilder<II2CChannelConfigurationBuilder, II2cChannelConfiguration, I2cChannelOptions>
{
    II2CChannelConfigurationBuilder SetDeviceAddress(int deviceAddress);
}
