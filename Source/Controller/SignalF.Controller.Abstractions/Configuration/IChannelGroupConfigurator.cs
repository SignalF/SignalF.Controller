using SignalF.Datamodel.Hardware;

namespace SignalF.Controller.Configuration;

public interface IChannelGroupConfigurator
{
    /// <summary>
    ///     Configures channel groups with given configuration
    /// </summary>
    /// <param name="channelGroupConfigurations">Configuration to configure channel groups with.</param>
    void Configure(IList<IChannelGroupConfiguration> channelGroupConfigurations);
}
