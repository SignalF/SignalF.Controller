#region

#endregion

using System.Collections.Generic;
using SignalF.Datamodel.Configuration;

namespace SignalF.Controller.Configuration;

public interface ITaskConfigurator
{
    /// <summary>
    ///     Configures Tasks with given configuration
    /// </summary>
    /// <param name="taskConfigurations">Configuration to configure tasks with</param>
    void Configure(IList<ITaskConfiguration> taskConfigurations);
}
