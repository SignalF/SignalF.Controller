#region

using System;
using System.Net.Sockets;
using SignalF.Controller.Hardware.DeviceBindings;
using SignalF.Datamodel.Hardware;

#endregion

namespace SignalF.Controller.Hardware.Channels.Tcp;

public class TcpDeviceBinding : DeviceBinding<ITcpDeviceBindingConfiguration>, ITcpDeviceBinding
{
    public TcpClient Device { get; private set; }

    public override void Open()
    {
        throw new NotImplementedException();
    }

    public override void Close()
    {
        throw new NotImplementedException();
    }

    protected override void OnConfigure(ITcpDeviceBindingConfiguration configuration)
    {
        throw new NotImplementedException();
    }

    protected override void Dispose(bool disposing)
    {
        base.Dispose(disposing);
        if (disposing)
        {
            Device?.Dispose();
            Device = null;
        }
    }

    public NetworkStream GetStream()
    {
        return Device.GetStream();
    }
}
