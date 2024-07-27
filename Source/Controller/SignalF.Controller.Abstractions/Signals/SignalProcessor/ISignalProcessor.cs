#region

using SignalF.Datamodel.Configuration;
using SignalF.Datamodel.Signals;

#endregion

namespace SignalF.Controller.Signals.SignalProcessor;

public interface ISignalProcessor
{
    /// <summary>
    ///     Id of the SignalProcessor
    /// </summary>
    Guid Id { get; }

    /// <summary>
    ///     Name of the SignalProcessor
    /// </summary>
    string Name { get; }

    /// <summary>
    ///     Configures SignalProcessor with given configuration
    /// </summary>
    /// <param name="configuration">Configuration to configure device with</param>
    void Configure(ISignalProcessorConfiguration configuration);

    /// <summary>
    ///     Executes the action of the SignalProcessor
    /// </summary>
    void Execute(ETaskType taskType);
}
