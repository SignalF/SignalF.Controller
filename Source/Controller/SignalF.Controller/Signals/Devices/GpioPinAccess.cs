using System.Collections.Generic;
using System.Linq;
using Microsoft.Extensions.Logging;
using Scotec.Extensions.Linq;
using Scotec.XMLDatabase;
using SignalF.Controller.Hardware.Channels;
using SignalF.Controller.Hardware.Channels.Gpio;
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

    protected override void OnRead()
    {
        var signals = SignalSinks;
        foreach (var (index, channels) in _signalSinkMappings)
        {
            var value = signals[index].Value;
            if (!double.IsNaN(value)) // Do not switch state for invalid values.
            {
                var state = value != 0.0 ? EGpioPinValue.High : EGpioPinValue.Low;
                channels.ForAll(channel => channel.WritePinValue(state));
            }
        }
    }

    protected override void OnWrite()
    {
        var timestamp = SignalHub.GetTimestamp();
        var signals = SignalSources;
        var x = signals[0];
        foreach (var (index, channel) in _signalSourceMappings)
        {
            var state = channel.ReadPinValue();
            signals[index].AssignWith(state == EGpioPinValue.Low ? 0.0 : 1.0, timestamp);
        }
    }

    private Dictionary<int, IGpioChannel> GetSourceMappings(IList<IChannel> channels, IEnumerable<ISignalEndpointConfiguration> signalEndpoints)
    {
        var signalEndpointToChannelMappings = signalEndpoints.SelectMany(signalSink => signalSink
                                                                                       .GetReverseLinks<IChannelToSignalEndpointsMapping>(ESearchType.Deep)
                                                                                       .Select(mapping => (SignalSink: signalSink, mapping.Channel)));
        
        // TODO: Use FirstOrDefault() instead of First() and check for null.
        return signalEndpointToChannelMappings
            .ToDictionary(mapping => GetSignalIndex(mapping.SignalSink)
                , mapping => channels.Cast<IGpioChannel>()
                                     .First(channel => channel.Id == mapping.Channel.Id));
    }

    private Dictionary<int, List<IGpioChannel>> GetSinkMappings(IList<IChannel> channels, IEnumerable<ISignalEndpointConfiguration> signalEndpoints)
    {
        var signalEndpointToChannelMappings = signalEndpoints.SelectMany(signalSink => signalSink
                                                                                       .GetReverseLinks<IChannelToSignalEndpointsMapping>(ESearchType.Deep)
                                                                                       .Select(mapping => (SignalSink: signalSink, mapping.Channel)))
                                                             .GroupBy(mapping => mapping.SignalSink);

        return signalEndpointToChannelMappings
               .Select(channelMapping => (Index: GetSignalIndex(channelMapping.Key)
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
