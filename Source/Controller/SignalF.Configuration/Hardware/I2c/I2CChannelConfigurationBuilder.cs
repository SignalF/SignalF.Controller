using SignalF.Controller.Configuration;
using SignalF.Datamodel.Hardware;

namespace SignalF.Configuration.Hardware.I2c;

public class I2CChannelConfigurationBuilder :
    ChannelConfigurationBuilder<I2CChannelConfigurationBuilder, II2CChannelConfigurationBuilder, II2cChannelConfiguration, SignalFConfigurationOptions>,
    II2CChannelConfigurationBuilder
{
    private int _deviceAddress;
    protected override II2CChannelConfigurationBuilder This => this;

    public II2CChannelConfigurationBuilder SetDeviceAddress(int deviceAddress)
    {
        _deviceAddress = deviceAddress;
        return this;
    }

    public override void Build(II2cChannelConfiguration configuration)
    {
        base.Build(configuration);

        configuration.DeviceAddress = _deviceAddress;
    }
}
