using System.Collections.Generic;
using System.Linq;
using Scotec.XMLDatabase;
using SignalF.Datamodel.Configuration;

namespace SignalF.Controller.Configuration;

public class ConfigurationFactory : IConfigurationFactory
{
    private readonly ISystemConfiguration _configuration;
    private readonly IBusinessDocument _document;

    public ConfigurationFactory(IBusinessDocument document, IList<ISystemConfiguration> configurations)
    {
        _document = document;

        // Currently only one configuration is supported.
        _configuration = configurations.FirstOrDefault();
    }

    public IControllerConfiguration Configure()
    {
        if (_configuration == null)
        {
            return null;
        }

        _document.CreateDocument("");
        var session = _document.CreateSession(EBusinessSessionMode.Write);
        var configuration = session.GetRoot<IControllerConfiguration>();

        _configuration.Configure(configuration);

        return configuration;
    }

    public bool HasConfiguration => _configuration != null;
}
