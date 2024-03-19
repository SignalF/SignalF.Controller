using SignalF.Controller.Configuration;
using SignalF.Datamodel.Devices;

namespace SignalF.Configuration.Devices;

public interface
    IGenericDeviceDefinitionBuilder : IGenericDeviceDefinitionBuilder<IGenericDeviceDefinitionBuilder, IGenericDeviceDefinition, SignalFConfigurationOptions>
{
}

public interface IGenericDeviceDefinitionBuilder<out TBuilder, in TConfiguration, in TOptions> : IDeviceDefinitionBuilder<TBuilder, TConfiguration, TOptions>
    where TBuilder : IGenericDeviceDefinitionBuilder<TBuilder, TConfiguration, TOptions>
    where TConfiguration : IGenericDeviceDefinition
    where TOptions : SignalFConfigurationOptions
{
}
