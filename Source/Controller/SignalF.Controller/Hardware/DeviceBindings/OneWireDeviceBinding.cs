#region

using SignalF.Datamodel.Hardware;

#endregion

namespace SignalF.Controller.Hardware.DeviceBindings;

public class OneWireDeviceBinding : DeviceBinding<IOneWireDeviceBindingConfiguration>, IOneWireDeviceBinding
{
    public override void Open()
    {
        throw new NotImplementedException();
    }

    public override void Close()
    {
        throw new NotImplementedException();
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
