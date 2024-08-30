#region

using Iot.Device.DHTxx;
using Iot.Device.OneWire;
using SignalF.Datamodel.Hardware;

#endregion

namespace SignalF.Controller.Hardware.DeviceBindings;

public class OneWireDeviceBinding : DeviceBinding<IOneWireDeviceBindingConfiguration>, IOneWireDeviceBinding
{
    private OneWireBus _bus;
    private List<string> _devices;


    public override void Open()
    {
        var busId = "/sys/bus/w1/devices/w1_bus_master1";
        _bus = new OneWireBus(busId);

        // Scan for devices
        _bus.ScanForDeviceChanges();

        // Enumerate devices
        _devices = _bus.EnumerateDeviceIds().ToList();
        var d = new OneWireDevice(busId, "DEVICE_ID");
    }

    public override void Close()
    {
        _devices = null;
        _bus = null;
    }

    public void Read(Span<byte> buffer)
    {
        throw new NotImplementedException();
    }

    public void Write(Span<byte> buffer)
    {
        throw new NotImplementedException();
    }

    public void WriteRead(Span<byte> writeBuffer, Span<byte> readBuffer)
    {
        throw new NotImplementedException();
    }

    protected override void OnConfigure(IOneWireDeviceBindingConfiguration configuration)
    {
        throw new NotImplementedException();
    }
}
