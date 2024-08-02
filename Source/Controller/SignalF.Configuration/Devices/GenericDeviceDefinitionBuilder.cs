using SignalF.Controller;
using SignalF.Controller.Configuration;
using SignalF.Datamodel.Devices;

namespace SignalF.Configuration.Devices;

public class GenericDeviceDefinitionBuilder
    : GenericDeviceDefinitionBuilder<GenericDeviceDefinitionBuilder, IGenericDeviceDefinitionBuilder, IGenericDeviceDefinition, SignalFConfigurationOptions>,
      IGenericDeviceDefinitionBuilder
{
    protected override IGenericDeviceDefinitionBuilder This => this;
}

public abstract class GenericDeviceDefinitionBuilder<TImpl, TBuilder, TConfiguration, TOptions>
    : DeviceDefinitionBuilder<TImpl, TBuilder, TConfiguration, TOptions>, IGenericDeviceDefinitionBuilder<TBuilder, TConfiguration, TOptions>
    where TBuilder : IGenericDeviceDefinitionBuilder<TBuilder, TConfiguration, TOptions>
    where TImpl : GenericDeviceDefinitionBuilder<TImpl, TBuilder, TConfiguration, TOptions>
    where TConfiguration : IGenericDeviceDefinition
    where TOptions : SignalFConfigurationOptions
{
}
