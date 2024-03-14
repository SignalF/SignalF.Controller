#region

#endregion

using System.Collections.Generic;
using SignalF.Datamodel.DataOutput;

namespace SignalF.Controller.Configuration;

public interface IDataOutputSenderConfigurator
{
    /// <summary>
    ///     Configures the DataOutputs.
    /// </summary>
    /// <param name="configurations"></param>
    void Configure(IList<IDataOutputSenderConfiguration> configurations);
}
