using SignalF.Datamodel.Hardware;

namespace SignalF.Controller.Configuration;

public interface IDeviceBindingConfigurator
{
    /// <summary>
    ///     Configures device bindings with given configuration
    /// </summary>
    /// <param name="deviceBindingConfigurations">Configuration to configure device binding with.</param>
    void Configure(IList<IDeviceBindingConfiguration> deviceBindingConfigurations);
}
