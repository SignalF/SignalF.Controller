using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Extensions.DependencyInjection;
using SignalF.Controller.Configuration;
using SignalF.Datamodel.Hardware;

namespace SignalF.Controller.Hardware.DeviceBindings;

public class DeviceBindingFactory : IDeviceBindingFactory
{
    private readonly IDictionary<Guid, IDeviceBinding> _deviceBindings;
    private readonly IServiceProvider _serviceProvider;

    public DeviceBindingFactory(IServiceProvider serviceProvider)
    {
        _serviceProvider = serviceProvider;
        _deviceBindings = new Dictionary<Guid, IDeviceBinding>();
    }

    public IDeviceBinding GetDeviceBinding(IDeviceBindingConfiguration deviceBindingConfiguration)
    {
        var type = deviceBindingConfiguration.GetCoreType();

        if (type == null)
        {
            var message = $"No implementation type has been defined for device binding '{deviceBindingConfiguration.Name}'.";
            throw new ConfiguratorException(message);
        }

        return GetDeviceBinding(type, deviceBindingConfiguration.Id);
    }

    public IDeviceBinding FindDeviceBinding(Guid id)
    {
        if (_deviceBindings.TryGetValue(id, out var instance))
        {
            return instance;
        }

        throw new ControllerException($"Could not find device binding with ID '{id}'.");
    }

    public TDeviceBinding FindDeviceBinding<TDeviceBinding>(Guid id)
        where TDeviceBinding : IDeviceBinding
    {
        var deviceBinding = FindDeviceBinding(id);
        if (deviceBinding is TDeviceBinding binding)
        {
            return binding;
        }

        throw new ControllerException($"Found device binding '{deviceBinding.Name}' but is not of expected type '{typeof(TDeviceBinding)}'");
    }

    public IDeviceBinding GetDeviceBinding(Type type, Guid id)
    {
        if (!_deviceBindings.TryGetValue(id, out var deviceBinding))
        {
            deviceBinding = (IDeviceBinding)_serviceProvider.GetRequiredService(type);
            _deviceBindings.Add(id, deviceBinding);
        }

        return deviceBinding;
    }

    public IEnumerable<TDeviceBinding> GetDeviceBindings<TDeviceBinding>()
        where TDeviceBinding : IDeviceBinding
    {
        return _deviceBindings.Values.OfType<TDeviceBinding>();
    }
}
