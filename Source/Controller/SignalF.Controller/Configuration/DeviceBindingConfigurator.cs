using SignalF.Controller.Hardware.DeviceBindings;
using SignalF.Datamodel.Hardware;

namespace SignalF.Controller.Configuration;

public class DeviceBindingConfigurator : IDeviceBindingConfigurator
{
    private readonly IDeviceBindingFactory _deviceBindingFactory;

    public DeviceBindingConfigurator(IDeviceBindingFactory deviceBindingFactory)
    {
        _deviceBindingFactory = deviceBindingFactory;
    }

    public void Configure(IList<IDeviceBindingConfiguration> deviceBindingConfigurations)
    {
        foreach (var deviceBindingConfiguration in deviceBindingConfigurations)
        {
            var deviceBindingGroupType = deviceBindingConfiguration.GetCoreType();

            if (deviceBindingGroupType == null)
            {
                var message = $"No implementation type has been defined for device binding '{deviceBindingConfiguration.Name}'.";
                throw new ConfiguratorException(message);
            }

            var groupId = deviceBindingConfiguration.Id;
            var deviceBinding = _deviceBindingFactory.GetDeviceBinding(deviceBindingGroupType, groupId);

            deviceBinding.Configure(deviceBindingConfiguration);
        }
    }
}
