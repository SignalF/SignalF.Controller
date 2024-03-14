using SignalF.Datamodel.Configuration;

namespace SignalF.Configuration.Hardware;

public interface IChannelToSignalEndpointMappingBuilder
{
    void Build(IControllerConfiguration configuration);

    IChannelToSignalEndpointMappingBuilder AddMapping(string signalEndpoint, string channel);
}
