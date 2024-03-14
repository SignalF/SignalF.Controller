using Scotec.Extensions.Linq;
using SignalF.Datamodel.Configuration;
using SignalF.Datamodel.Hardware;

namespace SignalF.Configuration.Hardware;

public class ChannelToDeviceMappingBuilder
    : ChannelMappingBuilder, IChannelToDeviceMappingBuilder
{
    private readonly List<Mapping> _mappings = new();

    public void Build(IControllerConfiguration configuration)
    {
        _mappings.GroupBy(item => item.Channel)
                 .ForAll(mapping => CreateMapping(configuration, mapping.Key, mapping.Select(item => item.Device)));
    }

    public IChannelToDeviceMappingBuilder AddMapping(string channel, string device)
    {
        _mappings.Add(new Mapping(channel, device));
        return this;
    }

    private static void CreateMapping(IControllerConfiguration configuration, string channelName, IEnumerable<string> deviceNames)
    {
        var channel = GetChannel(configuration, channelName);

        var devices = configuration.SignalProcessorConfigurations
                                   .OfType<IDeviceConfiguration>()
                                   .Join(deviceNames, device => device.Name, name => name, (device, _) => device);

        var mapping = configuration.ChannelToDeviceMappings.Create();
        mapping.Channel = channel;

        devices.ForAll(device => { mapping.Devices.Append(device); });
    }

    private record Mapping(string Channel, string Device);
}
