﻿using SignalF.Controller;
using SignalF.Controller.Configuration;
using SignalF.Datamodel.Hardware;

namespace SignalF.Configuration.Hardware.Tcp;

public class TcpDeviceBindingBuilder
    : DeviceBindingBuilder<TcpDeviceBindingBuilder, ITcpDeviceBindingBuilder, ITcpDeviceBindingConfiguration, SignalFConfigurationOptions>
      , ITcpDeviceBindingBuilder
{
    private string _ipAddress = "127.0.0.1";

    protected override ITcpDeviceBindingBuilder This => this;

    public ITcpDeviceBindingBuilder SetIpAddress(string ipAddress)
    {
        _ipAddress = ipAddress;
        return this;
    }

    public override void Build(ITcpDeviceBindingConfiguration configuration)
    {
        base.Build(configuration);
        configuration.IpAddress = _ipAddress;
    }
}
