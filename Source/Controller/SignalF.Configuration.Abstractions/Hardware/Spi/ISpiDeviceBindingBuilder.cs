using SignalF.Datamodel.Hardware;

namespace SignalF.Configuration.Hardware.Spi;

public interface ISpiDeviceBindingBuilder : IDeviceBindingBuilder<ISpiDeviceBindingBuilder, ISpiDeviceBindingConfiguration, SpiDeviceBindingOptions>
{
    ISpiDeviceBindingBuilder SetBusId(int busId);
}
