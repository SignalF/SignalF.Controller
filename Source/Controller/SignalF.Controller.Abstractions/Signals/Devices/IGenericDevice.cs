#region

#endregion

namespace SignalF.Controller.Signals.Devices;

public interface IGenericDevice : IDevice
{
}

//public interface IGenericDevice<in TDeviceBinding> : IGenericDevice
//    where TDeviceBinding : IDeviceBinding
//{
//    /// <summary>
//    ///     Assign device binding to communicate with
//    /// </summary>
//    /// <param name="device">Device binding to communicate with</param>
//    void AssignDeviceBinding(TDeviceBinding device);
//}
