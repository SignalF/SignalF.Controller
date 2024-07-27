#region

using SignalF.Datamodel.Hardware;

#endregion

namespace SignalF.Controller.Hardware.DeviceBindings;

public interface IDeviceBindingFactory
{
    IDeviceBinding GetDeviceBinding(Type type, Guid id);

    IDeviceBinding GetDeviceBinding(IDeviceBindingConfiguration deviceBindingonfiguration);

    IDeviceBinding FindDeviceBinding(Guid id);

    TDeviceBinding FindDeviceBinding<TDeviceBinding>(Guid id)
        where TDeviceBinding : IDeviceBinding;

    /// <summary>
    ///     Returns all device binding instances of the given type.
    /// </summary>
    /// <remarks>A call to GetDeviceBindings does not instantiate any new channel groups.</remarks>
    IEnumerable<TDeviceBinding> GetDeviceBindings<TDeviceBinding>()
        where TDeviceBinding : IDeviceBinding;
}
