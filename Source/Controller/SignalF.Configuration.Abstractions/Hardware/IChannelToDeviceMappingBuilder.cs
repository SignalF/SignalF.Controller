using SignalF.Datamodel.Configuration;

namespace SignalF.Configuration.Hardware;

public interface IChannelToDeviceMappingBuilder
{
    void Build(IControllerConfiguration configuration);

    IChannelToDeviceMappingBuilder AddMapping(string channel, string device);
}
