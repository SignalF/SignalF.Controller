using SignalF.Controller;
using SignalF.Controller.Configuration;
using SignalF.Datamodel.Hardware;

namespace SignalF.Configuration.Hardware.I2c;

public class I2cDeviceBindingBuilder
    : DeviceBindingBuilder<I2cDeviceBindingBuilder, II2cDeviceBindingBuilder, II2cDeviceBindingConfiguration, SignalFConfigurationOptions>
      , II2cDeviceBindingBuilder
{
    private int _busId = 1;

    protected override II2cDeviceBindingBuilder This => this;

    public II2cDeviceBindingBuilder SetBusId(int busId)
    {
        _busId = busId;
        return this;
    }

    public override void Build(II2cDeviceBindingConfiguration configuration)
    {
        base.Build(configuration);
        configuration.BusId = _busId;
    }
}
