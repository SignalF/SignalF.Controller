#region

using System;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices;
using Scotec.XMLDatabase;
using SignalF.Controller.DataOutput;
using SignalF.Controller.Signals;
using SignalF.Datamodel.Configuration;

#endregion

namespace SignalF.Controller.Configuration;

public class CoreConfigurationManager : ICoreConfigurationManager
{
    private readonly IBusinessDocument _businessDocument;
    private readonly IChannelGroupConfigurator _channelGroupConfigurator;
    private readonly IConfigurationFactory _configurationFactory;
    private readonly IDataOutputManager _dataOutputManager;
    private readonly IDataOutputSenderConfigurator _dataOutputSenderConfigurator;
    private readonly IDeviceBindingConfigurator _deviceBindingConfigurator;
    private readonly IDeviceChannelMappingConfigurator _deviceChannelMappingConfigurator;
    private readonly ISignalHub _signalHub;

    private readonly ISignalProcessorConfigurator _signalProcessorConfigurator;

    private readonly string _storageFolderPath = AppDomain.CurrentDomain.BaseDirectory;
    private readonly ITaskConfigurator _taskConfigurator;

    public CoreConfigurationManager(
        IBusinessDocument businessDocument
        , IDeviceBindingConfigurator deviceBindingConfigurator
        , IChannelGroupConfigurator channelGroupConfigurator
        , ISignalProcessorConfigurator signalProcessorConfigurator
        , IDeviceChannelMappingConfigurator deviceChannelMappingConfigurator
        , ITaskConfigurator taskConfigurator
        , IDataOutputSenderConfigurator dataOutputSenderConfigurator
        , IDataOutputManager dataOutputManager
        , ISignalHub signalHub
        , IConfigurationFactory configurationFactory
    )
    {
        _businessDocument = businessDocument;
        _deviceBindingConfigurator = deviceBindingConfigurator;
        _channelGroupConfigurator = channelGroupConfigurator;
        _signalProcessorConfigurator = signalProcessorConfigurator;
        _deviceChannelMappingConfigurator = deviceChannelMappingConfigurator;
        _taskConfigurator = taskConfigurator;
        _dataOutputSenderConfigurator = dataOutputSenderConfigurator;
        _dataOutputManager = dataOutputManager;
        _signalHub = signalHub;
        _configurationFactory = configurationFactory;

        _businessDocument.Root = "ControllerConfiguration";
        _businessDocument.Schema = new Uri(Path.Combine(_storageFolderPath, "Schemas", "SignalF.Datamodel.Configuration.xsd"));
    }

    public void Configure(string configurationName)
    {
        IControllerConfiguration configuration;
        if (_configurationFactory.HasConfiguration)
        {
            configuration = _configurationFactory.Configure();
        }
        else
        {
            var configFile = string.IsNullOrWhiteSpace(configurationName) ? configurationName : "DefaultConfiguration";

            // TODO: do not save user-configuration in installation directory
            var configurationFile = Path.Combine(_storageFolderPath, $"{configFile}.xml");

            // fall back to default configuration if no user configuration exists
            if (!File.Exists(configurationFile))
            {
                configurationFile = Path.Combine(_storageFolderPath, "DefaultConfiguration.xml");
            }

            _businessDocument.OpenDocument(configurationFile);

            var session = _businessDocument.CreateSession(EBusinessSessionMode.Read);
            configuration = session.GetRoot<IControllerConfiguration>();
        }

        // The SignalHub has to be configured before any signal processor.
        _signalHub.Configure(configuration);

        _deviceBindingConfigurator.Configure(configuration.DeviceBindings.ToList());

        _channelGroupConfigurator.Configure(configuration.HardwareConfiguration.ChannelGroups.ToList());

        _signalProcessorConfigurator.Configure(configuration.SignalProcessorConfigurations.ToList());

        _deviceChannelMappingConfigurator.Configure(configuration);

        _dataOutputSenderConfigurator.Configure(configuration.DataOutputSenderConfigurations.ToList());

        _taskConfigurator.Configure(configuration.TaskConfigurations.ToList());

        _dataOutputManager.Configure(configuration);

#if DEBUG
        if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
        {
            var lw = Path.GetPathRoot(Assembly.GetExecutingAssembly().Location);
            _businessDocument.SaveDocumentAs(@$"{lw}Projects\scotec\dev_config.xml");
        }
#endif
    }

    public void AddConfiguration(string configurationName, Stream configurationStream)
    {
        var configurationFile = Path.Combine(_storageFolderPath, $"{configurationName}.xml");

        using var fileStream = File.Create(configurationFile);
        configurationStream.CopyTo(fileStream);
    }

    public void RemoveConfiguration(string configurationName)
    {
        var configurationFile = Path.Combine(_storageFolderPath, $"{configurationName}.xml");

        File.Delete(configurationFile);
    }

    public void UnloadConfiguration()
    {
        _businessDocument.Close();
    }
}
