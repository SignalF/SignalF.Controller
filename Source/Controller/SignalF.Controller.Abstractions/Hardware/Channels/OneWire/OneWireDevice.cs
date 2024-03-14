#region

using Microsoft.Extensions.Logging;
using SignalF.Controller.Signals;
using SignalF.Controller.Signals.Devices;
using SignalF.Datamodel.Hardware;

#endregion

namespace SignalF.Controller.Hardware.Channels.OneWire;

public abstract class OneWireDevice : OneWireDevice<IDeviceConfiguration>
{
    protected OneWireDevice(ISignalHub signalHub, ILogger<OneWireDevice> logger) : base(signalHub, logger)
    {
    }
}

public abstract class OneWireDevice<TConfiguration> : Device<TConfiguration>, IOneWireDevice
    where TConfiguration : IDeviceConfiguration
{
    protected OneWireDevice(ISignalHub signalHub, ILogger<OneWireDevice<TConfiguration>> logger)
        : base(signalHub, logger)
    {
    }
}
