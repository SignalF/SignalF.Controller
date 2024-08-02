using SignalF.Controller;
using SignalF.Controller.Configuration;
using SignalF.Datamodel.Hardware;

namespace SignalF.Configuration.Hardware;

public class DeviceBindingBuilder : DeviceBindingBuilder<DeviceBindingBuilder, IDeviceBindingBuilder, IDeviceBindingConfiguration, SignalFConfigurationOptions>,
                                    IDeviceBindingBuilder
{
    protected override IDeviceBindingBuilder This => this;
}

public abstract class DeviceBindingBuilder<TImpl, TBuilder, TConfiguration, TOptions>
    : SignalFConfigurationBuilder<TImpl, TBuilder, TConfiguration, TOptions>,
      IDeviceBindingBuilder<TBuilder, TConfiguration, TOptions>
    where TImpl : DeviceBindingBuilder<TImpl, TBuilder, TConfiguration, TOptions>
    where TBuilder : IDeviceBindingBuilder<TBuilder, TConfiguration, TOptions>
    where TConfiguration : IDeviceBindingConfiguration
    where TOptions : SignalFConfigurationOptions
{
    public override void Build(TConfiguration configuration)
    {
        base.Build(configuration);
    }
}
