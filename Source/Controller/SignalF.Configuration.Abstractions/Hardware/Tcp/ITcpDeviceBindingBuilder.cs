using SignalF.Datamodel.Hardware;

namespace SignalF.Configuration.Hardware.Tcp;

public interface ITcpDeviceBindingBuilder
    : IDeviceBindingBuilder<ITcpDeviceBindingBuilder, ITcpDeviceBindingConfiguration>
{
    ITcpDeviceBindingBuilder SetIpAddress(string ipAddress);
}
