#region

using System.Device.Spi;
using SignalF.Controller.Hardware.Channels.Spi;
using SignalF.Controller.Hardware.DeviceBindings;
using SignalF.Datamodel.Hardware;

#endregion

namespace SignalF.Controller.Hardware.Channels.OneWire;

public sealed class OneWireChannelGroup : ChannelGroup<IOneWireChannelGroupConfiguration>, IOneWireChannelGroup
{
    private IOneWireDeviceBinding DeviceBinding { get; }

    public OneWireChannelGroup(IOneWireDeviceBinding deviceBinding)
    {
        DeviceBinding = deviceBinding;
    }
    public void Read(int pin, Span<byte> buffer)
    {
        throw new NotImplementedException();
    }

    public void Write(int pin, Span<byte> buffer)
    {
        throw new NotImplementedException();
    }

    public void WriteRead(int pin, Span<byte> writeBuffer, Span<byte> readBuffer)
    {
        throw new NotImplementedException();
    }

    public override void Open()
    {
        DeviceBinding.Open();
    }

    public override void Close()
    {
        DeviceBinding.Close();
    }

    protected override void OnConfigure(IOneWireChannelGroupConfiguration configuration)
    {
        throw new NotImplementedException();
    }
}
