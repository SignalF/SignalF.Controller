using SignalF.Configuration.Devices;
using SignalF.Controller.Signals.Devices;
using SignalF.Datamodel.Devices;

namespace SignalF.Configuration;

//TODO: Can this interface be removed?
public partial interface ISignalFConfiguration
{
    ISignalFConfiguration AddGenericDeviceConfiguration<TBuilder, TOptions>(Action<TBuilder> builder)
        where TBuilder : IGenericDeviceConfigurationBuilder<TBuilder, IGenericDeviceConfiguration, TOptions>
        where TOptions : GenericDeviceOptions;

    ISignalFConfiguration AddGenericDeviceConfiguration<TBuilder, TOptions, TType>(Action<TBuilder> builder)
        where TBuilder : IGenericDeviceConfigurationBuilder<TBuilder, IGenericDeviceConfiguration, TOptions>
        where TOptions : GenericDeviceOptions
        where TType : class, IGenericDevice;

    ISignalFConfiguration AddGenericDeviceDefinition<TBuilder, TOptions>(Action<TBuilder> builder)
        where TBuilder : IGenericDeviceDefinitionBuilder<TBuilder, IGenericDeviceDefinition, TOptions>
        where TOptions : GenericDeviceOptions;

    ISignalFConfiguration AddGenericDeviceDefinition<TBuilder, TOptions, TType>(Action<TBuilder> builder)
        where TBuilder : IGenericDeviceDefinitionBuilder<TBuilder, IGenericDeviceDefinition, TOptions>
        where TOptions : GenericDeviceOptions
        where TType : class, IGenericDevice;

    ISignalFConfiguration AddGenericDeviceTemplate<TBuilder, TOptions>(Action<TBuilder> builder)
        where TBuilder : IGenericDeviceTemplateBuilder<TBuilder, IGenericDeviceTemplate, TOptions>
        where TOptions : GenericDeviceOptions;

    ISignalFConfiguration AddGenericDeviceTemplate<TBuilder, TOptions, TType>(Action<TBuilder> builder)
        where TBuilder : IGenericDeviceTemplateBuilder<TBuilder, IGenericDeviceTemplate, TOptions>
        where TOptions : GenericDeviceOptions
        where TType : class, IGenericDevice;
}
