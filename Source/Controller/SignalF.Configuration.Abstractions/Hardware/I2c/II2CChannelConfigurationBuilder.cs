﻿using SignalF.Controller;
using SignalF.Controller.Configuration;
using SignalF.Datamodel.Hardware;

namespace SignalF.Configuration.Hardware.I2c;

public interface
    II2CChannelConfigurationBuilder : IChannelConfigurationBuilder<II2CChannelConfigurationBuilder, II2cChannelConfiguration, SignalFConfigurationOptions>
{
    II2CChannelConfigurationBuilder SetDeviceAddress(int deviceAddress);
}
