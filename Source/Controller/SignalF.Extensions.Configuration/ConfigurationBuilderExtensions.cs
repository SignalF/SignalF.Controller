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
    #region SignalProcessor

    // Add a default template
    public static ISignalFConfiguration AddDefaultTemplateTemplate(this ISignalFConfiguration configuration)
    {
        return configuration.AddSignalProcessorTemplate(builder =>
        {
            builder.SetName(Names.DefaultTemplate);
        });
    }

    #endregion

    #region DataOutputSender

    public static ISignalFConfiguration AddDataOutputSender<TType, TOptions>(this ISignalFConfiguration configuration
                                                                          , Action<IDataOutputSenderConfigurationBuilder> builder)
        where TType : class, IDataOutputSender
        where TOptions : SignalFConfigurationOptions
    {
        return configuration.AddDataOutputSenderConfiguration<IDataOutputSenderConfigurationBuilder, TOptions, TType>(builder);
    }

    #endregion

    #region SignalProcessor

    public static ISignalFConfiguration AddSignalProcessorConfiguration(this ISignalFConfiguration configuration
                                                                     , Action<ISignalProcessorConfigurationBuilder> builder)
    {
        return configuration.AddSignalProcessorConfiguration<ISignalProcessorConfigurationBuilder, SignalFConfigurationOptions>(builder);
    }

    public static ISignalFConfiguration AddSignalProcessorConfiguration<TType>(this ISignalFConfiguration configuration
                                                                            , Action<ISignalProcessorConfigurationBuilder> builder)
        where TType : class, ISignalProcessor
    {
        return configuration.AddSignalProcessorConfiguration<ISignalProcessorConfigurationBuilder, SignalFConfigurationOptions, TType>(builder);
    }

    public static ISignalFConfiguration AddSignalProcessorDefinition(this ISignalFConfiguration configuration, Action<ISignalProcessorDefinitionBuilder> builder)
    {
        return configuration.AddSignalProcessorDefinition<ISignalProcessorDefinitionBuilder, SignalFConfigurationOptions>(builder);
    }

    public static ISignalFConfiguration AddSignalProcessorDefinition<TType>(this ISignalFConfiguration configuration
                                                                         , Action<ISignalProcessorDefinitionBuilder> builder)
        where TType : class, ISignalProcessor
    {
        return configuration.AddSignalProcessorDefinition<ISignalProcessorDefinitionBuilder, SignalFConfigurationOptions, TType>(builder);
    }

    public static ISignalFConfiguration AddSignalProcessorTemplate(this ISignalFConfiguration configuration, Action<ISignalProcessorTemplateBuilder> builder)
    {
        return configuration.AddSignalProcessorTemplate<ISignalProcessorTemplateBuilder, SignalFConfigurationOptions, ISignalProcessor>(builder);
    }

    public static ISignalFConfiguration AddSignalProcessorTemplate<TType>(this ISignalFConfiguration configuration, Action<ISignalProcessorTemplateBuilder> builder)
        where TType : class, ISignalProcessor
    {
        return configuration.AddSignalProcessorTemplate<ISignalProcessorTemplateBuilder, SignalFConfigurationOptions, TType>(builder);
    }

    #endregion

    #region DeviceBinding

    public static ISignalFConfiguration AddDeviceBinding(this ISignalFConfiguration configuration,
                                                      Action<IDeviceBindingBuilder> builder)
    {
        return configuration
            .AddDeviceBinding<IDeviceBindingBuilder, IDeviceBindingConfiguration,
                SignalFConfigurationOptions>(builder);
    }

    public static ISignalFConfiguration AddGpioDeviceBinding(this ISignalFConfiguration configuration,
                                                          Action<IGpioDeviceBindingBuilder> builder)
    {
        return configuration
            .AddDeviceBinding<IGpioDeviceBindingBuilder, IGpioDeviceBindingConfiguration,
                SignalFConfigurationOptions, IGpioDeviceBinding>(builder);
    }

    public static ISignalFConfiguration AddI2cDeviceBinding(this ISignalFConfiguration configuration,
                                                         Action<II2cDeviceBindingBuilder> builder)
    {
        return configuration
            .AddDeviceBinding<II2cDeviceBindingBuilder, II2cDeviceBindingConfiguration,
                SignalFConfigurationOptions, II2cDeviceBinding>(builder);
    }

    public static ISignalFConfiguration AddSpiDeviceBinding(this ISignalFConfiguration configuration,
                                                         Action<ISpiDeviceBindingBuilder> builder)
    {
        return configuration
            .AddDeviceBinding<ISpiDeviceBindingBuilder, ISpiDeviceBindingConfiguration,
                SignalFConfigurationOptions, ISpiDeviceBinding>(builder);
    }

    public static ISignalFConfiguration AddOneWireDeviceBinding(this ISignalFConfiguration configuration,
                                                             Action<IOneWireDeviceBindingBuilder> builder)
    {
        return configuration
            .AddDeviceBinding<IOneWireDeviceBindingBuilder, IOneWireDeviceBindingConfiguration,
                SignalFConfigurationOptions, IOneWireDeviceBinding>(builder);
    }

    public static ISignalFConfiguration AddTcpDeviceBinding(this ISignalFConfiguration configuration,
                                                         Action<ITcpDeviceBindingBuilder> builder)
    {
        return configuration
            .AddDeviceBinding<ITcpDeviceBindingBuilder, ITcpDeviceBindingConfiguration,
                SignalFConfigurationOptions, ITcpDeviceBinding>(builder);
    }

    #endregion

    #region ChannelGroups

    // Channel groups
    public static ISignalFConfiguration AddOneWireChannelGroup(this ISignalFConfiguration configuration,
                                                            Action<IOneWireChannelGroupBuilder> builder)
    {
        return configuration
            .AddChannelGroup<IOneWireChannelGroupBuilder, IOneWireChannelGroupConfiguration, IOneWireChannelConfigurationBuilder, IOneWireChannelConfiguration,
                SignalFConfigurationOptions, IOneWireChannelGroup>(builder);
    }

    public static ISignalFConfiguration AddI2cChannelGroup(this ISignalFConfiguration configuration,
                                                        Action<II2cChannelGroupBuilder> builder)
    {
        return configuration
            .AddChannelGroup<II2cChannelGroupBuilder, II2cChannelGroupConfiguration, II2CChannelConfigurationBuilder, II2cChannelConfiguration,
                SignalFConfigurationOptions, II2cChannelGroup>(builder);
    }

    public static II2cChannelGroupBuilder AddI2cChannel(this II2cChannelGroupBuilder channelGroup, Action<II2CChannelConfigurationBuilder> builder)
    {
        return channelGroup.AddChannel<II2cChannel>(builder);
    }

    public static ISignalFConfiguration AddSpiChannelGroup(this ISignalFConfiguration configuration,
                                                        Action<ISpiChannelGroupBuilder> builder)
    {
        return configuration
            .AddChannelGroup<ISpiChannelGroupBuilder, ISpiChannelGroupConfiguration, ISpiChannelConfigurationBuilder, ISpiChannelConfiguration,
                SignalFConfigurationOptions, ISpiChannelGroup>(builder);
    }

    public static ISignalFConfiguration AddTcpChannelGroup(this ISignalFConfiguration configuration,
                                                        Action<ITcpChannelGroupBuilder> builder)
    {
        return configuration
            .AddChannelGroup<ITcpChannelGroupBuilder, ITcpChannelGroupConfiguration, ITcpChannelConfigurationBuilder, ITcpChannelConfiguration,
                SignalFConfigurationOptions, ITcpChannelGroup>(builder);
    }

    public static ISignalFConfiguration AddGpioChannelGroup(this ISignalFConfiguration configuration,
                                                         Action<IGpioChannelGroupBuilder> builder)
    {
        return configuration
            .AddChannelGroup<IGpioChannelGroupBuilder, IGpioChannelGroupConfiguration, IGpioChannelConfigurationBuilder, IGpioChannelConfiguration,
                SignalFConfigurationOptions, IGpioChannelGroup>(builder);
    }

    public static IGpioChannelGroupBuilder AddGpioChannel(this IGpioChannelGroupBuilder channelGroup, Action<IGpioChannelConfigurationBuilder> builder)
    {
        return channelGroup.AddChannel<IGpioChannel>(builder);
    }

    #endregion

    #region ProcessControl

    // Execution engine
    public static ISignalFConfiguration AddProcessControlConfiguration(this ISignalFConfiguration configuration
                                                                    , Action<IProcessControlConfigurationBuilder> builder)
    {
        return configuration.AddProcessControlConfiguration<IProcessControlConfigurationBuilder, SignalFConfigurationOptions>(builder);
    }

    public static ISignalFConfiguration AddProcessControlConfiguration<TType>(this ISignalFConfiguration configuration
                                                                           , Action<IProcessControlConfigurationBuilder> builder)
        where TType : class, IProcessControlAdapter
    {
        return configuration.AddProcessControlConfiguration<IProcessControlConfigurationBuilder, SignalFConfigurationOptions, TType>(builder);
    }

    public static ISignalFConfiguration AddProcessControlDefinition(this ISignalFConfiguration configuration, Action<IProcessControlDefinitionBuilder> builder)
    {
        return configuration.AddProcessControlDefinition<IProcessControlDefinitionBuilder, SignalFConfigurationOptions>(builder);
    }

    public static ISignalFConfiguration AddProcessControlDefinition<TType>(this ISignalFConfiguration configuration
                                                                        , Action<IProcessControlDefinitionBuilder> builder)
        where TType : class, IProcessControlAdapter
    {
        return configuration.AddProcessControlDefinition<IProcessControlDefinitionBuilder, SignalFConfigurationOptions, TType>(builder);
    }

    public static ISignalFConfiguration AddProcessControlTemplate(this ISignalFConfiguration configuration, Action<IProcessControlTemplateBuilder> builder)
    {
        return configuration.AddProcessControlTemplate<IProcessControlTemplateBuilder, SignalFConfigurationOptions, IProcessControlAdapter>(builder);
    }

    public static ISignalFConfiguration AddProcessControlTemplate<TType>(this ISignalFConfiguration configuration, Action<IProcessControlTemplateBuilder> builder)
        where TType : class, IProcessControlAdapter
    {
        return configuration.AddProcessControlTemplate<IProcessControlTemplateBuilder, SignalFConfigurationOptions, TType>(builder);
    }

    #endregion

    #region StaticSignalProvider

    // Static signal provider
    public static ISignalFConfiguration AddStaticSignalProviderConfiguration(this ISignalFConfiguration configuration
                                                                          , Action<IStaticSignalProviderConfigurationBuilder> builder)
    {
        return configuration.AddStaticSignalProviderConfiguration<IStaticSignalProviderConfigurationBuilder, SignalFConfigurationOptions>(builder);
    }

    public static ISignalFConfiguration AddStaticSignalProviderConfiguration<TType>(this ISignalFConfiguration configuration
                                                                                 , Action<IStaticSignalProviderConfigurationBuilder> builder)
        where TType : class, IStaticSignalProvider
    {
        return configuration.AddStaticSignalProviderConfiguration<IStaticSignalProviderConfigurationBuilder, SignalFConfigurationOptions, TType>(builder);
    }

    public static ISignalFConfiguration AddStaticSignalProviderDefinition(this ISignalFConfiguration configuration
                                                                       , Action<IStaticSignalProviderDefinitionBuilder> builder)
    {
        return configuration.AddStaticSignalProviderDefinition<IStaticSignalProviderDefinitionBuilder, SignalFConfigurationOptions>(builder);
    }

    public static ISignalFConfiguration AddStaticSignalProviderDefinition<TType>(this ISignalFConfiguration configuration
                                                                              , Action<IStaticSignalProviderDefinitionBuilder> builder)
        where TType : class, IStaticSignalProvider
    {
        return configuration.AddStaticSignalProviderDefinition<IStaticSignalProviderDefinitionBuilder, SignalFConfigurationOptions, TType>(builder);
    }

    public static ISignalFConfiguration AddStaticSignalProviderTemplate(this ISignalFConfiguration configuration
                                                                     , Action<IStaticSignalProviderTemplateBuilder> builder)
    {
        return configuration.AddStaticSignalProviderTemplate<IStaticSignalProviderTemplateBuilder, SignalFConfigurationOptions, IStaticSignalProvider>(builder);
    }

    public static ISignalFConfiguration AddStaticSignalProviderTemplate<TType>(this ISignalFConfiguration configuration
                                                                            , Action<IStaticSignalProviderTemplateBuilder> builder)
        where TType : class, IStaticSignalProvider
    {
        return configuration.AddStaticSignalProviderTemplate<IStaticSignalProviderTemplateBuilder, SignalFConfigurationOptions, TType>(builder);
    }

    #endregion

    #region GpioPinAccess

    // GPIO pin access
    public static ISignalFConfiguration AddGpioPinAccessConfiguration(this ISignalFConfiguration configuration, Action<IGpioPinAccessConfigurationBuilder> builder)
    {
        return configuration.AddGpioPinAccessConfiguration<IGpioPinAccessConfigurationBuilder, SignalFConfigurationOptions>(builder);
    }

    public static ISignalFConfiguration AddGpioPinAccessConfiguration<TType>(this ISignalFConfiguration configuration
                                                                          , Action<IGpioPinAccessConfigurationBuilder> builder)
        where TType : class, IGpioPinAccess
    {
        return configuration.AddGpioPinAccessConfiguration<IGpioPinAccessConfigurationBuilder, SignalFConfigurationOptions, TType>(builder);
    }

    public static ISignalFConfiguration AddGpioPinAccessDefinition(this ISignalFConfiguration configuration, Action<IGpioPinAccessDefinitionBuilder> builder)
    {
        return configuration.AddGpioPinAccessDefinition<IGpioPinAccessDefinitionBuilder, SignalFConfigurationOptions>(builder);
    }

    public static ISignalFConfiguration AddGpioPinAccessDefinition<TType>(this ISignalFConfiguration configuration, Action<IGpioPinAccessDefinitionBuilder> builder)
        where TType : class, IGpioPinAccess
    {
        return configuration.AddGpioPinAccessDefinition<IGpioPinAccessDefinitionBuilder, SignalFConfigurationOptions, TType>(builder);
    }

    public static ISignalFConfiguration AddGpioPinAccessTemplate(this ISignalFConfiguration configuration, Action<IGpioPinAccessTemplateBuilder> builder)
    {
        return configuration.AddGpioPinAccessTemplate<IGpioPinAccessTemplateBuilder, SignalFConfigurationOptions, IGpioPinAccess>(builder);
    }

    public static ISignalFConfiguration AddGpioPinAccessTemplate<TType>(this ISignalFConfiguration configuration, Action<IGpioPinAccessTemplateBuilder> builder)
        where TType : class, IGpioPinAccess
    {
        return configuration.AddGpioPinAccessTemplate<IGpioPinAccessTemplateBuilder, SignalFConfigurationOptions, TType>(builder);
    }

    #endregion

    #region Device

    // Device
    public static ISignalFConfiguration AddDeviceConfiguration(this ISignalFConfiguration configuration, Action<IDeviceConfigurationBuilder> builder)
    {
        return configuration.AddDeviceConfiguration<IDeviceConfigurationBuilder, SignalFConfigurationOptions>(builder);
    }

    public static ISignalFConfiguration AddDeviceConfiguration<TType>(this ISignalFConfiguration configuration, Action<IDeviceConfigurationBuilder> builder)
        where TType : class, IDevice
    {
        return configuration.AddDeviceConfiguration<IDeviceConfigurationBuilder, SignalFConfigurationOptions, TType>(builder);
    }

    public static ISignalFConfiguration AddDeviceDefinition(this ISignalFConfiguration configuration, Action<IDeviceDefinitionBuilder> builder)
    {
        return configuration.AddDeviceDefinition<IDeviceDefinitionBuilder, SignalFConfigurationOptions>(builder);
    }

    public static ISignalFConfiguration AddDeviceDefinition<TType>(this ISignalFConfiguration configuration, Action<IDeviceDefinitionBuilder> builder)
        where TType : class, IDevice
    {
        return configuration.AddDeviceDefinition<IDeviceDefinitionBuilder, SignalFConfigurationOptions, TType>(builder);
    }

    public static ISignalFConfiguration AddDeviceTemplate(this ISignalFConfiguration configuration, Action<IDeviceTemplateBuilder> builder)
    {
        return configuration.AddDeviceTemplate<IDeviceTemplateBuilder, SignalFConfigurationOptions>(builder);
    }

    public static ISignalFConfiguration AddDeviceTemplate<TType>(this ISignalFConfiguration configuration, Action<IDeviceTemplateBuilder> builder)
        where TType : class, IDevice
    {
        return configuration.AddDeviceTemplate<IDeviceTemplateBuilder, SignalFConfigurationOptions, TType>(builder);
    }

    #endregion

    #region GenericDevice

    // GenericDevice
    public static ISignalFConfiguration AddGenericDeviceConfiguration(this ISignalFConfiguration configuration, Action<IGenericDeviceConfigurationBuilder> builder)
    {
        return configuration.AddGenericDeviceConfiguration<IGenericDeviceConfigurationBuilder, SignalFConfigurationOptions>(builder);
    }

    public static ISignalFConfiguration AddGenericDeviceConfiguration<TType>(this ISignalFConfiguration configuration
                                                                          , Action<IGenericDeviceConfigurationBuilder> builder)
        where TType : class, IGenericDevice
    {
        return configuration.AddGenericDeviceConfiguration<IGenericDeviceConfigurationBuilder, SignalFConfigurationOptions, TType>(builder);
    }

    public static ISignalFConfiguration AddGenericDeviceDefinition(this ISignalFConfiguration configuration, Action<IGenericDeviceDefinitionBuilder> builder)
    {
        return configuration.AddGenericDeviceDefinition<IGenericDeviceDefinitionBuilder, SignalFConfigurationOptions>(builder);
    }

    public static ISignalFConfiguration AddGenericDeviceDefinition<TType>(this ISignalFConfiguration configuration, Action<IGenericDeviceDefinitionBuilder> builder)
        where TType : class, IGenericDevice
    {
        return configuration.AddGenericDeviceDefinition<IGenericDeviceDefinitionBuilder, SignalFConfigurationOptions, TType>(builder);
    }

    public static ISignalFConfiguration AddGenericDeviceTemplate(this ISignalFConfiguration configuration, Action<IGenericDeviceTemplateBuilder> builder)
    {
        return configuration.AddGenericDeviceTemplate<IGenericDeviceTemplateBuilder, SignalFConfigurationOptions, IGenericDevice>(builder);
    }

    public static ISignalFConfiguration AddGenericDeviceTemplate<TType>(this ISignalFConfiguration configuration, Action<IGenericDeviceTemplateBuilder> builder)
        where TType : class, IGenericDevice
    {
        return configuration.AddGenericDeviceTemplate<IGenericDeviceTemplateBuilder, SignalFConfigurationOptions, TType>(builder);
    }

    #endregion
}
