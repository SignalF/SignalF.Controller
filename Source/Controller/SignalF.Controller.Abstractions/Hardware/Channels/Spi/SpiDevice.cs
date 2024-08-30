#region

using Microsoft.Extensions.Logging;
using SignalF.Controller.Hardware.Channels.Spi;
using SignalF.Controller.Signals;
using SignalF.Controller.Signals.Devices;
using SignalF.Datamodel.Hardware;

#endregion

namespace SignalF.Controller.Hardware.Channels.Spi;
public abstract class SpiDevice : SpiDevice<IDeviceConfiguration>
{
    protected SpiDevice(ISignalHub signalHub, ILogger<SpiDevice> logger)
        : base(signalHub, logger)
    {
    }
}

public abstract class SpiDevice<TConfiguration> : Device<TConfiguration>, ISpiDevice
    where TConfiguration : IDeviceConfiguration
{
    protected SpiDevice(ISignalHub signalHub, ILogger<SpiDevice<TConfiguration>> logger)
        : base(signalHub, logger)
    {
    }
}
