#region

using System.Net.Sockets;
using SignalF.Controller.Hardware;

#endregion

namespace SignalF.Controller.Hardware.Channels.Tcp;

public interface ITcpDeviceBinding : IDeviceBinding
{
    /// <summary>
    ///     Returns the NetworkStream used to send and receive data.
    /// </summary>
    /// <returns>The underlying NetworkStream.</returns>
    NetworkStream GetStream();
}
