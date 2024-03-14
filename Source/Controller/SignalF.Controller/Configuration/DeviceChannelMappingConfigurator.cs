using System.Linq;
using SignalF.Controller.Hardware.Channels;
using SignalF.Controller.Signals.Devices;
using SignalF.Controller.Signals.SignalProcessor;
using SignalF.Datamodel.Configuration;
using SignalF.Datamodel.Hardware;

namespace SignalF.Controller.Configuration;

public class DeviceChannelMappingConfigurator : IDeviceChannelMappingConfigurator
{
    private readonly IChannelGroupFactory _channelGroupFactory;
    private readonly ISignalProcessorFactory _signalProcessorFactory;

    public DeviceChannelMappingConfigurator(IChannelGroupFactory channelGroupFactory, ISignalProcessorFactory signalProcessorFactory)
    {
        _channelGroupFactory = channelGroupFactory;
        _signalProcessorFactory = signalProcessorFactory;
    }

    public void Configure(IControllerConfiguration controllerConfiguration)
    {
        var endpointMappings = controllerConfiguration.ChannelToSignalEndpointsMappings
                                                      .SelectMany(mapping => mapping.SignalEndpoints.Select(endpoint =>
                                                          (Device: endpoint.FindParent<IDeviceConfiguration>(), mapping.Channel)));
        //.GroupBy(item => item.Device)
        //.ToList();

        var deviceMappings = controllerConfiguration.ChannelToDeviceMappings
                                                    .SelectMany(mapping => mapping.Devices.Select(device => (Device: device, mapping.Channel)));

        var mappingGroups = endpointMappings.Concat(deviceMappings)
                                            .Distinct()
                                            .GroupBy(item => item.Device);

        var devices = _signalProcessorFactory.GetSignalProcessors<IDevice>();
        foreach (var group in mappingGroups)
        {
            var device = devices.First(device => device.Id == group.Key.Id);
            var channels = group.Select(item => _channelGroupFactory.FindChannel(item.Channel.Id));

            device.AssignChannels(channels.ToList());
        }
    }
}
