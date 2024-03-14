#region

using System;
using System.Collections.Generic;
using Microsoft.Extensions.Logging;
using SignalF.Controller.Hardware.Channels;
using SignalF.Datamodel.Hardware;

#endregion

namespace SignalF.Controller.Signals.Devices;

public abstract class NullDevice<TConfiguration> : Device<TConfiguration>, INullDevice
    where TConfiguration : IDeviceConfiguration
{
    protected NullDevice(ISignalHub signalHub, ILogger<NullDevice<TConfiguration>> logger)
        : base(signalHub, logger)
    {
    }

    public override void AssignChannels(IList<IChannel> channels)
    {
        throw new InvalidOperationException();
    }
}
