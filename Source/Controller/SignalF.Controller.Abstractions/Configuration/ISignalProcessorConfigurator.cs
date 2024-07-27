#region

using SignalF.Controller.Signals.SignalProcessor;
using SignalF.Datamodel.Signals;

#endregion

namespace SignalF.Controller.Configuration;

public interface ISignalProcessorConfigurator
{
    /// <summary>
    ///     List of all configured devices
    /// </summary>
    IList<ISignalProcessor> SignalProcessorList { get; }

    /// <summary>
    ///     Configures SignalProcessors with given configuration
    /// </summary>
    /// <param name="signalProcessorConfigurations">Configuration to configure SignalProcessors with</param>
    void Configure(IList<ISignalProcessorConfiguration> signalProcessorConfigurations);

    /// <summary>
    ///     Gets the SignalProcessor with the provided Id.
    /// </summary>
    /// <param name="id">The Id of the processor.</param>
    /// <returns></returns>
    ISignalProcessor GetSignalProcessor(Guid id);

    /// <summary>
    ///     Gets the SignalProcessor with the provided name.
    /// </summary>
    /// <param name="name">The name of the processor.</param>
    /// <returns></returns>
    ISignalProcessor GetSignalProcessor(string name);
}
