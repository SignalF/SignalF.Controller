#region

using SignalF.Datamodel.DataOutput;

#endregion

namespace SignalF.Controller.DataOutput;

public interface IDataOutputSenderFactory
{
    IDataOutputSender GetDataOutputSender(Type type, Guid id);

    /// <summary>
    ///     Returns all data output sender instances of the given type.
    /// </summary>
    /// <remarks>A call to GetDataOutputSenders does not instantiate any new data output sender.</remarks>
    IEnumerable<TDataOutputSender> GetDataOutputSenders<TDataOutputSender>()
        where TDataOutputSender : IDataOutputSender;

    IDataOutputSender GetDataOutputSender(IDataOutputSenderConfiguration dataOutputSenderConfiguration);

    IDataOutputSender FindDataOutputSender(Guid id);
}
