using System.Collections.Generic;
using System.Linq;
using Microsoft.Extensions.Logging;
using Scotec.Extensions.Linq;
using Scotec.XMLDatabase;
using SignalF.Controller.Hardware.Channels;
using SignalF.Controller.Hardware.Channels.Gpio;
using SignalF.Datamodel.Configuration;
using SignalF.Datamodel.Hardware;
using SignalF.Datamodel.Signals;

namespace SignalF.Controller.Signals.Devices;

public class GpioPinAccess : Device<IGpioPinAccessConfiguration>, IGpioPinAccess
{
    private IGpioPinAccessConfiguration _configuration;

    // Sinks can be assigned to multiple output channel. Therefore use a list of channels.
    private Dictionary<int, List<IGpioChannel>> _signalSinkMappings;

    // An input channel can be bound to multiple signal sources. 
    // However, this would result in two dictionary entries. Thus, no list is needed.
    private Dictionary<int, IGpioChannel> _signalSourceMappings;

    public GpioPinAccess(ISignalHub signalHub, ILogger<GpioPinAccess> logger)
        : base(signalHub, logger)
    {
    }

    public override void AssignChannels(IList<IChannel> channels)
    {
        _signalSinkMappings = GetSinkMappings(channels, _configuration.SignalSinks);
        _signalSourceMappings = GetSourceMappings(channels, _configuration.SignalSources);
    }

    public override void Execute(ETaskType taskType)
    {
        switch (taskType)
        {
            case ETaskType.Read:
            {
                foreach (var (index, channels) in _signalSinkMappings)
                {
                    var signal = SignalHub.GetSignal(index);
                    if (!double.IsNaN(signal.Value)) // Do not switch state for invalid values.
                    {
                        var state = signal.Value != 0.0 ? EGpioPinValue.High : EGpioPinValue.Low;
                        channels.ForAll(channel => channel.WritePinValue(state));
                    }
                }

                break;
            }
            case ETaskType.Write:
            {
                foreach (var (index, channel) in _signalSourceMappings)
                {
                    var state = channel.ReadPinValue();
                    SignalHub.SetSignal(new Signal(index, state == EGpioPinValue.Low ? 0.0 : 1.0, SignalHub.GetTimestamp()));
                }

                break;
            }
        }
    }

    private Dictionary<int, IGpioChannel> GetSourceMappings(IList<IChannel> channels, IEnumerable<ISignalEndpointConfiguration> signalEndpoints)
    {
        var signalEndpointToChannelMappings = signalEndpoints.SelectMany(signalSink => signalSink
                                                                                       .GetReverseLinks<IChannelToSignalEndpointsMapping>(ESearchType.Deep)
                                                                                       .Select(mapping => (SignalSink: signalSink, mapping.Channel)));

        return signalEndpointToChannelMappings
            .ToDictionary(mapping => SignalHub.GetSignalIndex(mapping.SignalSink)
                , mapping => channels.Cast<IGpioChannel>().First(channel => channel.Id == mapping.Channel.Id));
    }

    private Dictionary<int, List<IGpioChannel>> GetSinkMappings(IList<IChannel> channels, IEnumerable<ISignalEndpointConfiguration> signalEndpoints)
    {
        var signalEndpointToChannelMappings = signalEndpoints.SelectMany(signalSink => signalSink
                                                                                       .GetReverseLinks<IChannelToSignalEndpointsMapping>(ESearchType.Deep)
                                                                                       .Select(mapping => (SignalSink: signalSink, mapping.Channel)))
                                                             .GroupBy(mapping => mapping.SignalSink);

        return signalEndpointToChannelMappings
               .Select(channelMapping => (Index: SignalHub.GetSignalIndex(channelMapping.Key)
                   , Channels: channels.Cast<IGpioChannel>()
                                       .Join(channelMapping, channel => channel.Id, mapping => mapping.Channel.Id, (channel, _) => channel)))
               .Where(mapping => mapping.Index >= 0)
               .ToDictionary(mapping => mapping.Index, mapping => mapping.Channels.ToList());
    }

    protected override void OnConfigure(IGpioPinAccessConfiguration configuration)
    {
        base.OnConfigure(configuration);

        _configuration = configuration;
    }
}
