using SignalF.Datamodel.Hardware;

namespace SignalF.Configuration.Hardware.Tcp;

public interface ITcpDeviceBindingBuilder
    : IDeviceBindingBuilder<ITcpDeviceBindingBuilder, ITcpDeviceBindingConfiguration, TcpDeviceBindingOptions>
{
    ITcpDeviceBindingBuilder SetIpAddress(string ipAddress);
}
