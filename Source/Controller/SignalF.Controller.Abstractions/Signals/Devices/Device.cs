#region

using Microsoft.Extensions.Logging;
using SignalF.Controller.Hardware.Channels;
using SignalF.Controller.Signals.SignalProcessor;
using SignalF.Datamodel.Hardware;

#endregion

namespace SignalF.Controller.Signals.Devices;

public abstract class Device<TConfiguration> : SignalProcessor<TConfiguration>, IDevice
    where TConfiguration : IDeviceConfiguration
{
    protected Device(ISignalHub signalHub, ILogger<Device<TConfiguration>> logger)
        : base(signalHub, logger)
    {
    }

    public abstract void AssignChannels(IList<IChannel> channels);
}
