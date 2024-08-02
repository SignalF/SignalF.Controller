using SignalF.Datamodel.Hardware;

namespace SignalF.Configuration.Hardware.Spi;

public class SpiDeviceBindingBuilder
    : DeviceBindingBuilder<SpiDeviceBindingBuilder, ISpiDeviceBindingBuilder, ISpiDeviceBindingConfiguration, SpiDeviceBindingOptions>
      , ISpiDeviceBindingBuilder
{
    private int _busId;

    protected override ISpiDeviceBindingBuilder This => this;

    public override void Build(ISpiDeviceBindingConfiguration configuration)
    {
        base.Build(configuration);

        configuration.BusId = _busId;
    }

    public ISpiDeviceBindingBuilder SetBusId(int busId)
    {
        _busId = busId;
        return this;
    }
}
