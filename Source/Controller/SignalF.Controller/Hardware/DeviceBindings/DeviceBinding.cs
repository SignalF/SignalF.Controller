#region

using SignalF.Datamodel.Hardware;

#endregion

namespace SignalF.Controller.Hardware.DeviceBindings;

public class DeviceBinding : DeviceBinding<IDeviceBindingConfiguration>
{
    public override void Open()
    {
    }

    public override void Close()
    {
    }

    protected override void OnConfigure(IDeviceBindingConfiguration configuration)
    {
    }
}

public abstract class DeviceBinding<TConfiguration> : IDeviceBinding
    where TConfiguration : IDeviceBindingConfiguration
{
    public Guid Id { get; private set; }
    public abstract void Open();
    public abstract void Close();

    public string Name { get; private set; }

    public void Configure(IDeviceBindingConfiguration configuration)
    {
        Id = configuration.Id;
        Name = configuration.Name;

        OnConfigure((TConfiguration)configuration);
    }

    public void Dispose()
    {
        Dispose(true);
        GC.SuppressFinalize(this);
    }

    protected abstract void OnConfigure(TConfiguration configuration);

    protected virtual void Dispose(bool disposing)
    {
        if (disposing)
        {
            Close();
        }
    }
}
