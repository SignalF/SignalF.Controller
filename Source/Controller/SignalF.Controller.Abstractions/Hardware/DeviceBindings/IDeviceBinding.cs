using SignalF.Datamodel.Hardware;

namespace SignalF.Controller.Hardware.DeviceBindings;

public interface IDeviceBinding : IDisposable
{
    string Name { get; }

    Guid Id { get; }
    void Configure(IDeviceBindingConfiguration configuration);

    void Open();

    void Close();
}
