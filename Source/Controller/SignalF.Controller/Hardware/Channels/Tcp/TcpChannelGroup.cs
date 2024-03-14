#region

using System;
using System.Collections.Generic;
using System.Net.Sockets;
using SignalF.Datamodel.Hardware;

#endregion

namespace SignalF.Controller.Hardware.Channels.Tcp;

public class TcpChannelGroup : ChannelGroup<ITcpChannelGroupConfiguration>, ITcpChannelGroup
{
    private readonly List<TcpDeviceSettings> _deviceSettings = new();

    public NetworkStream GetStream(int port)
    {
        throw new NotImplementedException();
    }

    public override void Open()
    {
        throw new NotImplementedException();
    }

    public override void Close()
    {
        throw new NotImplementedException();
    }

    protected override void OnConfigure(ITcpChannelGroupConfiguration configuration)
    {
        throw new NotImplementedException();
    }

    //public override void ReportDeviceChannel(ITcpDevice device, ITcpChannel connectionConfiguration)
    //{
    //    var configuration = connectionConfiguration;

    //    //var settings = new TcpDeviceSettings(device, configuration.IPAddress, configuration.Port);
    //    //_deviceSettings.Add(settings);
    //}

    //public override void DistributeDeviceBindings()
    //{
    //    foreach (var setting in _deviceSettings)
    //    {
    //        var client = new TcpClient(AddressFamily.InterNetworkV6)
    //        {
    //            Client = { DualMode = true },
    //            ReceiveTimeout = 250,
    //            SendTimeout = 250
    //        };

    //        var host = setting.IpAddress;
    //        var port = setting.Port;

    //        var success = client.BeginConnect(host, port, null, null).AsyncWaitHandle
    //                            .WaitOne(TimeSpan.FromSeconds(4));
    //        if (!success)
    //            throw new SocketException((int)SocketError.TimedOut);

    //        // TODO: Use IOC-Controller or factory to craete device binding.
    //        //setting.Device.AssignDeviceBinding(new TcpDeviceBinding(client));
    //    }
    //}

    private struct TcpDeviceSettings
    {
        public TcpDeviceSettings(ITcpDevice device, string ipAddress, int port)
        {
            Device = device;
            IpAddress = ipAddress;
            Port = port;
        }

        public ITcpDevice Device { get; }
        public string IpAddress { get; }
        public int Port { get; }
    }
}
