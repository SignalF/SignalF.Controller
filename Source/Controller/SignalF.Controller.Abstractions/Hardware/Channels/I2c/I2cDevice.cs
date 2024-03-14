#region

using Microsoft.Extensions.Logging;
using SignalF.Controller.Signals;
using SignalF.Controller.Signals.Devices;
using SignalF.Datamodel.Hardware;

#endregion

namespace SignalF.Controller.Hardware.Channels.I2c;

public abstract class I2cDevice : I2cDevice<IDeviceConfiguration>
{
    protected I2cDevice(ISignalHub signalHub, ILogger<I2cDevice> logger)
        : base(signalHub, logger)
    {
    }
}

public abstract class I2cDevice<TConfiguration> : Device<TConfiguration>, II2cDevice
    where TConfiguration : IDeviceConfiguration
{
    protected I2cDevice(ISignalHub signalHub, ILogger<I2cDevice<TConfiguration>> logger)
        : base(signalHub, logger)
    {
    }
}
