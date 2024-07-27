using Scotec.Extensions.Linq;
using SignalF.Datamodel.Configuration;
using SignalF.Datamodel.Hardware;
using SignalF.Datamodel.Signals;

namespace SignalF.Configuration.Hardware;

public class ChannelToSignalEndpointMappingBuilder
    : ChannelMappingBuilder, IChannelToSignalEndpointMappingBuilder
{
    private readonly List<Mapping> _mappings = new();

    public void Build(IControllerConfiguration configuration)
    {
        _mappings.GroupBy(item => item.Channel)
                 .ForAll(group =>
                 {
                     group.GroupBy(item => item.DeviceName)
                          .ForAll(mapping => CreateMapping(configuration, group.Key, mapping.Key, mapping.Select(item => item.SignalName)));
                 });
    }

    public IChannelToSignalEndpointMappingBuilder AddMapping(string signalName, string channel)
    {
        var parts = signalName.Split('.');
        _mappings.Add(new Mapping(channel, parts[0], parts[1]));
        return this;
    }

    private void CreateMapping(IControllerConfiguration configuration, string channelName, string deviceName, IEnumerable<string> signalNames)
    {
        var channel = GetChannel(configuration, channelName);
        var device = GetDevice(configuration, deviceName);

        var endpoints = device.SignalSinks
                              .Cast<ISignalEndpointConfiguration>()
                              .Concat(device.SignalSources)
                              .Join(signalNames, endpoint => endpoint.Name, name => name, (endpoint, _) => endpoint);

        var mapping = configuration.ChannelToSignalEndpointsMappings.Create();
        mapping.Channel = channel;

        endpoints.ForAll(endpoint => { mapping.SignalEndpoints.Append(endpoint); });
    }

    private static IDeviceConfiguration GetDevice(IControllerConfiguration configuration, string deviceName)
    {
        var device = configuration.SignalProcessorConfigurations
                                  .OfType<IDeviceConfiguration>()
                                  .FirstOrDefault(device => device.Name == deviceName);
        if (device == null)
        {
            throw new ConfigurationBuilderException($"Unknown device '{deviceName}'.");
        }

        return device;
    }

    private record Mapping(string Channel, string DeviceName, string SignalName);
}
