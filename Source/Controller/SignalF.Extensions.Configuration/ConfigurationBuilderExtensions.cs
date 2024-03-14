using System;
using SignalF.Configuration;
using SignalF.Configuration.DataOutput;
using SignalF.Configuration.Devices;
using SignalF.Configuration.Devices.Gpio;
using SignalF.Configuration.Hardware;
using SignalF.Configuration.Hardware.Gpio;
using SignalF.Configuration.Hardware.I2c;
using SignalF.Configuration.Hardware.OneWire;
using SignalF.Configuration.Hardware.Spi;
using SignalF.Configuration.Hardware.Tcp;
using SignalF.Configuration.ProcessControl;
using SignalF.Configuration.SignalConfiguration;
using SignalF.Configuration.StaticSignalProvider;
using SignalF.Controller.Configuration;
using SignalF.Controller.DataOutput;
using SignalF.Controller.Hardware.Channels.Gpio;
using SignalF.Controller.Hardware.Channels.I2c;
using SignalF.Controller.Hardware.Channels.OneWire;
using SignalF.Controller.Hardware.Channels.Spi;
using SignalF.Controller.Hardware.Channels.Tcp;
using SignalF.Controller.Hardware.DeviceBindings;
using SignalF.Controller.Signals.Devices;
using SignalF.Controller.Signals.ProcessControl;
using SignalF.Controller.Signals.SignalProcessor;
using SignalF.Datamodel.Hardware;

namespace SignalF.Extensions.Configuration;

public static class ConfigurationBuilderExtensions
{
    #region DataOutputSender

    public static ICoreConfiguration AddDataOutputSender<TType, TOptions>(this ICoreConfiguration configuration
                                                                          , Action<IDataOutputSenderConfigurationBuilder> builder)
        where TType : class, IDataOutputSender
        where TOptions : CoreConfigurationOptions
    {
        return configuration.AddDataOutputSenderConfiguration<IDataOutputSenderConfigurationBuilder, TOptions, TType>(builder);
    }

    #endregion

    #region SignalProcessor

    public static ICoreConfiguration AddSignalProcessorConfiguration(this ICoreConfiguration configuration
                                                                     , Action<ISignalProcessorConfigurationBuilder> builder)
    {
        return configuration.AddSignalProcessorConfiguration<ISignalProcessorConfigurationBuilder, CoreConfigurationOptions>(builder);
    }

    public static ICoreConfiguration AddSignalProcessorConfiguration<TType>(this ICoreConfiguration configuration
                                                                            , Action<ISignalProcessorConfigurationBuilder> builder)
        where TType : class, ISignalProcessor
    {
        return configuration.AddSignalProcessorConfiguration<ISignalProcessorConfigurationBuilder, CoreConfigurationOptions, TType>(builder);
    }

    public static ICoreConfiguration AddSignalProcessorDefinition(this ICoreConfiguration configuration, Action<ISignalProcessorDefinitionBuilder> builder)
    {
        return configuration.AddSignalProcessorDefinition<ISignalProcessorDefinitionBuilder, CoreConfigurationOptions>(builder);
    }

    public static ICoreConfiguration AddSignalProcessorDefinition<TType>(this ICoreConfiguration configuration
                                                                         , Action<ISignalProcessorDefinitionBuilder> builder)
        where TType : class, ISignalProcessor
    {
        return configuration.AddSignalProcessorDefinition<ISignalProcessorDefinitionBuilder, CoreConfigurationOptions, TType>(builder);
    }

    public static ICoreConfiguration AddSignalProcessorTemplate(this ICoreConfiguration configuration, Action<ISignalProcessorTemplateBuilder> builder)
    {
        return configuration.AddSignalProcessorTemplate<ISignalProcessorTemplateBuilder, CoreConfigurationOptions, ISignalProcessor>(builder);
    }

    public static ICoreConfiguration AddSignalProcessorTemplate<TType>(this ICoreConfiguration configuration, Action<ISignalProcessorTemplateBuilder> builder)
        where TType : class, ISignalProcessor
    {
        return configuration.AddSignalProcessorTemplate<ISignalProcessorTemplateBuilder, CoreConfigurationOptions, TType>(builder);
    }

    #endregion

    #region DeviceBinding

    public static ICoreConfiguration AddDeviceBinding(this ICoreConfiguration configuration,
                                                      Action<IDeviceBindingBuilder> builder)
    {
        return configuration
            .AddDeviceBinding<IDeviceBindingBuilder, IDeviceBindingConfiguration,
                CoreConfigurationOptions>(builder);
    }

    public static ICoreConfiguration AddGpioDeviceBinding(this ICoreConfiguration configuration,
                                                          Action<IGpioDeviceBindingBuilder> builder)
    {
        return configuration
            .AddDeviceBinding<IGpioDeviceBindingBuilder, IGpioDeviceBindingConfiguration,
                CoreConfigurationOptions, IGpioDeviceBinding>(builder);
    }

    public static ICoreConfiguration AddI2cDeviceBinding(this ICoreConfiguration configuration,
                                                         Action<II2cDeviceBindingBuilder> builder)
    {
        return configuration
            .AddDeviceBinding<II2cDeviceBindingBuilder, II2cDeviceBindingConfiguration,
                CoreConfigurationOptions, II2cDeviceBinding>(builder);
    }

    public static ICoreConfiguration AddSpiDeviceBinding(this ICoreConfiguration configuration,
                                                         Action<ISpiDeviceBindingBuilder> builder)
    {
        return configuration
            .AddDeviceBinding<ISpiDeviceBindingBuilder, ISpiDeviceBindingConfiguration,
                CoreConfigurationOptions, ISpiDeviceBinding>(builder);
    }

    public static ICoreConfiguration AddOneWireDeviceBinding(this ICoreConfiguration configuration,
                                                             Action<IOneWireDeviceBindingBuilder> builder)
    {
        return configuration
            .AddDeviceBinding<IOneWireDeviceBindingBuilder, IOneWireDeviceBindingConfiguration,
                CoreConfigurationOptions, IOneWireDeviceBinding>(builder);
    }

    public static ICoreConfiguration AddTcpDeviceBinding(this ICoreConfiguration configuration,
                                                         Action<ITcpDeviceBindingBuilder> builder)
    {
        return configuration
            .AddDeviceBinding<ITcpDeviceBindingBuilder, ITcpDeviceBindingConfiguration,
                CoreConfigurationOptions, ITcpDeviceBinding>(builder);
    }

    #endregion

    #region ChannelGroups

    // Channel groups
    public static ICoreConfiguration AddOneWireChannelGroup(this ICoreConfiguration configuration,
                                                            Action<IOneWireChannelGroupBuilder> builder)
    {
        return configuration
            .AddChannelGroup<IOneWireChannelGroupBuilder, IOneWireChannelGroupConfiguration, IOneWireChannelConfigurationBuilder, IOneWireChannelConfiguration,
                CoreConfigurationOptions, IOneWireChannelGroup>(builder);
    }

    public static ICoreConfiguration AddI2cChannelGroup(this ICoreConfiguration configuration,
                                                        Action<II2cChannelGroupBuilder> builder)
    {
        return configuration
            .AddChannelGroup<II2cChannelGroupBuilder, II2cChannelGroupConfiguration, II2CChannelConfigurationBuilder, II2cChannelConfiguration,
                CoreConfigurationOptions, II2cChannelGroup>(builder);
    }

    public static II2cChannelGroupBuilder AddI2cChannel(this II2cChannelGroupBuilder channelGroup, Action<II2CChannelConfigurationBuilder> builder)
    {
        return channelGroup.AddChannel<II2cChannel>(builder);
    }

    public static ICoreConfiguration AddSpiChannelGroup(this ICoreConfiguration configuration,
                                                        Action<ISpiChannelGroupBuilder> builder)
    {
        return configuration
            .AddChannelGroup<ISpiChannelGroupBuilder, ISpiChannelGroupConfiguration, ISpiChannelConfigurationBuilder, ISpiChannelConfiguration,
                CoreConfigurationOptions, ISpiChannelGroup>(builder);
    }

    public static ICoreConfiguration AddTcpChannelGroup(this ICoreConfiguration configuration,
                                                        Action<ITcpChannelGroupBuilder> builder)
    {
        return configuration
            .AddChannelGroup<ITcpChannelGroupBuilder, ITcpChannelGroupConfiguration, ITcpChannelConfigurationBuilder, ITcpChannelConfiguration,
                CoreConfigurationOptions, ITcpChannelGroup>(builder);
    }

    public static ICoreConfiguration AddGpioChannelGroup(this ICoreConfiguration configuration,
                                                         Action<IGpioChannelGroupBuilder> builder)
    {
        return configuration
            .AddChannelGroup<IGpioChannelGroupBuilder, IGpioChannelGroupConfiguration, IGpioChannelConfigurationBuilder, IGpioChannelConfiguration,
                CoreConfigurationOptions, IGpioChannelGroup>(builder);
    }

    public static IGpioChannelGroupBuilder AddGpioChannel(this IGpioChannelGroupBuilder channelGroup, Action<IGpioChannelConfigurationBuilder> builder)
    {
        return channelGroup.AddChannel<IGpioChannel>(builder);
    }

    #endregion

    #region ProcessControl

    // Execution engine
    public static ICoreConfiguration AddProcessControlConfiguration(this ICoreConfiguration configuration
                                                                    , Action<IProcessControlConfigurationBuilder> builder)
    {
        return configuration.AddProcessControlConfiguration<IProcessControlConfigurationBuilder, CoreConfigurationOptions>(builder);
    }

    public static ICoreConfiguration AddProcessControlConfiguration<TType>(this ICoreConfiguration configuration
                                                                           , Action<IProcessControlConfigurationBuilder> builder)
        where TType : class, IProcessControlAdapter
    {
        return configuration.AddProcessControlConfiguration<IProcessControlConfigurationBuilder, CoreConfigurationOptions, TType>(builder);
    }

    public static ICoreConfiguration AddProcessControlDefinition(this ICoreConfiguration configuration, Action<IProcessControlDefinitionBuilder> builder)
    {
        return configuration.AddProcessControlDefinition<IProcessControlDefinitionBuilder, CoreConfigurationOptions>(builder);
    }

    public static ICoreConfiguration AddProcessControlDefinition<TType>(this ICoreConfiguration configuration
                                                                        , Action<IProcessControlDefinitionBuilder> builder)
        where TType : class, IProcessControlAdapter
    {
        return configuration.AddProcessControlDefinition<IProcessControlDefinitionBuilder, CoreConfigurationOptions, TType>(builder);
    }

    public static ICoreConfiguration AddProcessControlTemplate(this ICoreConfiguration configuration, Action<IProcessControlTemplateBuilder> builder)
    {
        return configuration.AddProcessControlTemplate<IProcessControlTemplateBuilder, CoreConfigurationOptions, IProcessControlAdapter>(builder);
    }

    public static ICoreConfiguration AddProcessControlTemplate<TType>(this ICoreConfiguration configuration, Action<IProcessControlTemplateBuilder> builder)
        where TType : class, IProcessControlAdapter
    {
        return configuration.AddProcessControlTemplate<IProcessControlTemplateBuilder, CoreConfigurationOptions, TType>(builder);
    }

    #endregion

    #region StaticSignalProvider

    // Static signal provider
    public static ICoreConfiguration AddStaticSignalProviderConfiguration(this ICoreConfiguration configuration
                                                                          , Action<IStaticSignalProviderConfigurationBuilder> builder)
    {
        return configuration.AddStaticSignalProviderConfiguration<IStaticSignalProviderConfigurationBuilder, CoreConfigurationOptions>(builder);
    }

    public static ICoreConfiguration AddStaticSignalProviderConfiguration<TType>(this ICoreConfiguration configuration
                                                                                 , Action<IStaticSignalProviderConfigurationBuilder> builder)
        where TType : class, IStaticSignalProvider
    {
        return configuration.AddStaticSignalProviderConfiguration<IStaticSignalProviderConfigurationBuilder, CoreConfigurationOptions, TType>(builder);
    }

    public static ICoreConfiguration AddStaticSignalProviderDefinition(this ICoreConfiguration configuration
                                                                       , Action<IStaticSignalProviderDefinitionBuilder> builder)
    {
        return configuration.AddStaticSignalProviderDefinition<IStaticSignalProviderDefinitionBuilder, CoreConfigurationOptions>(builder);
    }

    public static ICoreConfiguration AddStaticSignalProviderDefinition<TType>(this ICoreConfiguration configuration
                                                                              , Action<IStaticSignalProviderDefinitionBuilder> builder)
        where TType : class, IStaticSignalProvider
    {
        return configuration.AddStaticSignalProviderDefinition<IStaticSignalProviderDefinitionBuilder, CoreConfigurationOptions, TType>(builder);
    }

    public static ICoreConfiguration AddStaticSignalProviderTemplate(this ICoreConfiguration configuration
                                                                     , Action<IStaticSignalProviderTemplateBuilder> builder)
    {
        return configuration.AddStaticSignalProviderTemplate<IStaticSignalProviderTemplateBuilder, CoreConfigurationOptions, IStaticSignalProvider>(builder);
    }

    public static ICoreConfiguration AddStaticSignalProviderTemplate<TType>(this ICoreConfiguration configuration
                                                                            , Action<IStaticSignalProviderTemplateBuilder> builder)
        where TType : class, IStaticSignalProvider
    {
        return configuration.AddStaticSignalProviderTemplate<IStaticSignalProviderTemplateBuilder, CoreConfigurationOptions, TType>(builder);
    }

    #endregion

    #region GpioPinAccess

    // GPIO pin access
    public static ICoreConfiguration AddGpioPinAccessConfiguration(this ICoreConfiguration configuration, Action<IGpioPinAccessConfigurationBuilder> builder)
    {
        return configuration.AddGpioPinAccessConfiguration<IGpioPinAccessConfigurationBuilder, CoreConfigurationOptions>(builder);
    }

    public static ICoreConfiguration AddGpioPinAccessConfiguration<TType>(this ICoreConfiguration configuration
                                                                          , Action<IGpioPinAccessConfigurationBuilder> builder)
        where TType : class, IGpioPinAccess
    {
        return configuration.AddGpioPinAccessConfiguration<IGpioPinAccessConfigurationBuilder, CoreConfigurationOptions, TType>(builder);
    }

    public static ICoreConfiguration AddGpioPinAccessDefinition(this ICoreConfiguration configuration, Action<IGpioPinAccessDefinitionBuilder> builder)
    {
        return configuration.AddGpioPinAccessDefinition<IGpioPinAccessDefinitionBuilder, CoreConfigurationOptions>(builder);
    }

    public static ICoreConfiguration AddGpioPinAccessDefinition<TType>(this ICoreConfiguration configuration, Action<IGpioPinAccessDefinitionBuilder> builder)
        where TType : class, IGpioPinAccess
    {
        return configuration.AddGpioPinAccessDefinition<IGpioPinAccessDefinitionBuilder, CoreConfigurationOptions, TType>(builder);
    }

    public static ICoreConfiguration AddGpioPinAccessTemplate(this ICoreConfiguration configuration, Action<IGpioPinAccessTemplateBuilder> builder)
    {
        return configuration.AddGpioPinAccessTemplate<IGpioPinAccessTemplateBuilder, CoreConfigurationOptions, IGpioPinAccess>(builder);
    }

    public static ICoreConfiguration AddGpioPinAccessTemplate<TType>(this ICoreConfiguration configuration, Action<IGpioPinAccessTemplateBuilder> builder)
        where TType : class, IGpioPinAccess
    {
        return configuration.AddGpioPinAccessTemplate<IGpioPinAccessTemplateBuilder, CoreConfigurationOptions, TType>(builder);
    }

    #endregion

    #region Device

    // Device
    public static ICoreConfiguration AddDeviceConfiguration(this ICoreConfiguration configuration, Action<IDeviceConfigurationBuilder> builder)
    {
        return configuration.AddDeviceConfiguration<IDeviceConfigurationBuilder, CoreConfigurationOptions>(builder);
    }

    public static ICoreConfiguration AddDeviceConfiguration<TType>(this ICoreConfiguration configuration, Action<IDeviceConfigurationBuilder> builder)
        where TType : class, IDevice
    {
        return configuration.AddDeviceConfiguration<IDeviceConfigurationBuilder, CoreConfigurationOptions, TType>(builder);
    }

    public static ICoreConfiguration AddDeviceDefinition(this ICoreConfiguration configuration, Action<IDeviceDefinitionBuilder> builder)
    {
        return configuration.AddDeviceDefinition<IDeviceDefinitionBuilder, CoreConfigurationOptions>(builder);
    }

    public static ICoreConfiguration AddDeviceDefinition<TType>(this ICoreConfiguration configuration, Action<IDeviceDefinitionBuilder> builder)
        where TType : class, IDevice
    {
        return configuration.AddDeviceDefinition<IDeviceDefinitionBuilder, CoreConfigurationOptions, TType>(builder);
    }

    public static ICoreConfiguration AddDeviceTemplate(this ICoreConfiguration configuration, Action<IDeviceTemplateBuilder> builder)
    {
        return configuration.AddDeviceTemplate<IDeviceTemplateBuilder, CoreConfigurationOptions>(builder);
    }

    public static ICoreConfiguration AddDeviceTemplate<TType>(this ICoreConfiguration configuration, Action<IDeviceTemplateBuilder> builder)
        where TType : class, IDevice
    {
        return configuration.AddDeviceTemplate<IDeviceTemplateBuilder, CoreConfigurationOptions, TType>(builder);
    }

    #endregion

    #region GenericDevice

    // GenericDevice
    public static ICoreConfiguration AddGenericDeviceConfiguration(this ICoreConfiguration configuration, Action<IGenericDeviceConfigurationBuilder> builder)
    {
        return configuration.AddGenericDeviceConfiguration<IGenericDeviceConfigurationBuilder, CoreConfigurationOptions>(builder);
    }

    public static ICoreConfiguration AddGenericDeviceConfiguration<TType>(this ICoreConfiguration configuration
                                                                          , Action<IGenericDeviceConfigurationBuilder> builder)
        where TType : class, IGenericDevice
    {
        return configuration.AddGenericDeviceConfiguration<IGenericDeviceConfigurationBuilder, CoreConfigurationOptions, TType>(builder);
    }

    public static ICoreConfiguration AddGenericDeviceDefinition(this ICoreConfiguration configuration, Action<IGenericDeviceDefinitionBuilder> builder)
    {
        return configuration.AddGenericDeviceDefinition<IGenericDeviceDefinitionBuilder, CoreConfigurationOptions>(builder);
    }

    public static ICoreConfiguration AddGenericDeviceDefinition<TType>(this ICoreConfiguration configuration, Action<IGenericDeviceDefinitionBuilder> builder)
        where TType : class, IGenericDevice
    {
        return configuration.AddGenericDeviceDefinition<IGenericDeviceDefinitionBuilder, CoreConfigurationOptions, TType>(builder);
    }

    public static ICoreConfiguration AddGenericDeviceTemplate(this ICoreConfiguration configuration, Action<IGenericDeviceTemplateBuilder> builder)
    {
        return configuration.AddGenericDeviceTemplate<IGenericDeviceTemplateBuilder, CoreConfigurationOptions, IGenericDevice>(builder);
    }

    public static ICoreConfiguration AddGenericDeviceTemplate<TType>(this ICoreConfiguration configuration, Action<IGenericDeviceTemplateBuilder> builder)
        where TType : class, IGenericDevice
    {
        return configuration.AddGenericDeviceTemplate<IGenericDeviceTemplateBuilder, CoreConfigurationOptions, TType>(builder);
    }

    #endregion
}
