#region

using SignalF.Datamodel.Configuration;

#endregion

namespace SignalF.Controller.DataOutput;

public interface IDataOutputManager
{
    /// <summary>
    ///     Configures the DataOutputs.
    /// </summary>
    /// <param name="configuration">The configuration.</param>
    void Configure(IControllerConfiguration configuration);

    /// <summary>
    ///     Starts a Capture with the given name for set amount of cycles.
    /// </summary>
    /// <param name="id">The Id of the Capture.</param>
    /// <param name="cycleAmount">The amount of cycles to measure.</param>
    void StartCapture(Guid id, long cycleAmount);

    /// <summary>
    ///     Start a capture with the given name for set duration.
    /// </summary>
    /// <param name="id">The Id of the Capture.</param>
    /// <param name="duration">The duration to measure for.</param>
    void StartCapture(Guid id, TimeSpan duration);

    /// <summary>
    ///     Starts all Captures used for Measurements.
    /// </summary>
    void StartMeasurement();

    /// <summary>
    ///     Stops all Captures used for Measurements.
    /// </summary>
    void StopMeasurement();
}
