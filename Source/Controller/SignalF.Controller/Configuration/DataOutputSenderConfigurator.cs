#region

using Scotec.XMLDatabase;
using SignalF.Controller.DataOutput;
using SignalF.Datamodel.DataOutput;

#endregion

namespace SignalF.Controller.Configuration;

public class DataOutputSenderConfigurator : IDataOutputSenderConfigurator
{
    private readonly IDataOutputSenderFactory _dataOutputSenderFactory;

    public DataOutputSenderConfigurator(IDataOutputSenderFactory dataOutputSenderFactory)
    {
        _dataOutputSenderFactory = dataOutputSenderFactory;
    }

    public void Configure(IList<IDataOutputSenderConfiguration> configurations)
    {
        foreach (var dataOutputSenderConfiguration in configurations)
        {
            // We don't need to instantiate all data output senders. We just need the referenced.
            // Therefore check if the senders are referenced by any data output.
            if (!dataOutputSenderConfiguration.GetReverseLinks<IDataOutputConfiguration>(ESearchType.Deep).Any())
            {
                continue;
            }

            var type = dataOutputSenderConfiguration.GetCoreType();
            if (type == null)
            {
                var message = $"No implementation type has been defined for data output sender '{dataOutputSenderConfiguration.Name} '.";
                throw new ConfiguratorException(message);
            }

            var dataOutputSender = _dataOutputSenderFactory.GetDataOutputSender(dataOutputSenderConfiguration);
            dataOutputSender.Configure(dataOutputSenderConfiguration);
        }
    }
}
