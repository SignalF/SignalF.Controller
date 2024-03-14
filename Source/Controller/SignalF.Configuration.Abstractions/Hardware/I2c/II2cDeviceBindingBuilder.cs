using SignalF.Configuration.Hardware;
using SignalF.Datamodel.Hardware;

public interface II2cDeviceBindingBuilder : IDeviceBindingBuilder<II2cDeviceBindingBuilder, II2cDeviceBindingConfiguration>
{
    II2cDeviceBindingBuilder SetBusId(int busId);
}
