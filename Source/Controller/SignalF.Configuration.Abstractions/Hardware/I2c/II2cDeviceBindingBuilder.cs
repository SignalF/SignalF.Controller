using SignalF.Configuration.Hardware;
using SignalF.Configuration.Hardware.I2c;
using SignalF.Datamodel.Hardware;

public interface II2cDeviceBindingBuilder : IDeviceBindingBuilder<II2cDeviceBindingBuilder, II2cDeviceBindingConfiguration, I2cDeviceBindingOptions>
{
    II2cDeviceBindingBuilder SetBusId(int busId);
}
