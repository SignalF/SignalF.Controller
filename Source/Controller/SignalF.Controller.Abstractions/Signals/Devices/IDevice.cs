#region

using System.Collections.Generic;
using SignalF.Controller.Hardware.Channels;
using SignalF.Controller.Signals.SignalProcessor;

#endregion

namespace SignalF.Controller.Signals.Devices;

public interface IDevice : ISignalProcessor
{
    void AssignChannels(IList<IChannel> channels);
}
