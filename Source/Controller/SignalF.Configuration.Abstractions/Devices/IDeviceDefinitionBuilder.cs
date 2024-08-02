using SignalF.Configuration.SignalConfiguration;
using SignalF.Controller;
using SignalF.Controller.Configuration;
using SignalF.Datamodel.Hardware;

namespace SignalF.Configuration.Devices;

public interface IDeviceDefinitionBuilder : IDeviceDefinitionBuilder<IDeviceDefinitionBuilder, IDeviceDefinition, DeviceOptions>
{
}

public interface IDeviceDefinitionBuilder<out TBuilder, in TConfiguration, in TOptions> : ISignalProcessorDefinitionBuilder<TBuilder, TConfiguration, TOptions>
    where TBuilder : IDeviceDefinitionBuilder<TBuilder, TConfiguration, TOptions>
    where TConfiguration : IDeviceDefinition
    where TOptions : DeviceOptions
{
}
