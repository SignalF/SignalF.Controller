using SignalF.Datamodel.Configuration;

namespace SignalF.Configuration;

public partial class SignalFConfiguration : ISignalFConfiguration
{
    private readonly List<Action<IControllerConfiguration>> _channelGroups = new();
    private readonly List<Action<IControllerConfiguration>> _channelToDeviceMappings = new();
    private readonly List<Action<IControllerConfiguration>> _channelToSignalEndpointMappings = new();
    private readonly List<Action<IControllerConfiguration>> _dataOutputs = new();
    private readonly List<Action<IControllerConfiguration>> _dataOutputSenders = new();
    private readonly List<Action<IControllerConfiguration>> _deviceBindings = new();
    private readonly IServiceProvider _serviceProvider;
    private readonly List<Action<IControllerConfiguration>> _signalProcessorConfigurations = new();
    private readonly List<Action<IControllerConfiguration>> _signalProcessorConnections = new();
    private readonly List<Action<IControllerConfiguration>> _signalProcessorDefinitions = new();
    private readonly List<Action<IControllerConfiguration>> _signalProcessorTemplates = new();
    private readonly List<Action<IControllerConfiguration>> _taskMappingOptions = new();
    private readonly List<Action<IControllerConfiguration>> _taskOptions = new();

    public SignalFConfiguration(IServiceProvider serviceProvider)
    {
        // TODO: Use Factories instead getting services from service provider.
        _serviceProvider = serviceProvider;
    }

    public void Build(IControllerConfiguration configuration)
    {
        // Hardware must be configured first.
        BuildDeviceBindings(configuration);
        BuildChannelGroups(configuration);

        BuildSignalProcessorTemplates(configuration);
        BuildSignalProcessorDefinitions(configuration);
        BuildSignalProcessorConfigurations(configuration);
        BuildSignalProcessorConnections(configuration);

        BuildChannelToDeviceMappingConfigurations(configuration);
        BuildChannelToSignalEndpointMappingConfigurations(configuration);

        BuildDataOutputSenders(configuration);
        BuildDataOutputs(configuration);

        // Tasks will be configured last.
        BuildTaskConfigurations(configuration);
        BuildTaskMappingConfigurations(configuration);
    }

    private void BuildSignalProcessorTemplates(IControllerConfiguration configuration)
    {
        foreach (var template in _signalProcessorTemplates)
        {
            template(configuration);
        }
    }

    private void BuildSignalProcessorDefinitions(IControllerConfiguration configuration)
    {
        foreach (var template in _signalProcessorDefinitions)
        {
            template(configuration);
        }
    }

    private void BuildSignalProcessorConfigurations(IControllerConfiguration configuration)
    {
        foreach (var template in _signalProcessorConfigurations)
        {
            template(configuration);
        }
    }

    private void BuildDataOutputSenders(IControllerConfiguration configuration)
    {
        foreach (var sender in _dataOutputSenders)
        {
            sender(configuration);
        }
    }

    private void BuildDataOutputs(IControllerConfiguration configuration)
    {
        foreach (var sender in _dataOutputs)
        {
            sender(configuration);
        }
    }

    private void BuildSignalProcessorConnections(IControllerConfiguration configuration)
    {
        foreach (var template in _signalProcessorConnections)
        {
            template(configuration);
        }
    }

    private void BuildChannelGroups(IControllerConfiguration configuration)
    {
        foreach (var channelGroup in _channelGroups)
        {
            channelGroup(configuration);
        }
    }

    private void BuildDeviceBindings(IControllerConfiguration configuration)
    {
        foreach (var deviceBinding in _deviceBindings)
        {
            deviceBinding(configuration);
        }
    }

    private void BuildTaskConfigurations(IControllerConfiguration configuration)
    {
        foreach (var task in _taskOptions)
        {
            task(configuration);
        }
    }

    private void BuildTaskMappingConfigurations(IControllerConfiguration configuration)
    {
        foreach (var mapping in _taskMappingOptions)
        {
            mapping(configuration);
        }
    }

    private void BuildChannelToDeviceMappingConfigurations(IControllerConfiguration configuration)
    {
        foreach (var mapping in _channelToDeviceMappings)
        {
            mapping(configuration);
        }
    }

    private void BuildChannelToSignalEndpointMappingConfigurations(IControllerConfiguration configuration)
    {
        foreach (var mapping in _channelToSignalEndpointMappings)
        {
            mapping(configuration);
        }
    }
}
