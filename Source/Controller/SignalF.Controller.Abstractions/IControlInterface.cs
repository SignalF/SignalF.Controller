#region

using System;
using System.IO;
using SignalF.Controller.Signals.ProcessControl;

#endregion

namespace SignalF.Controller;

/// <summary>
///     Controls the program sequence and the measurements.
/// </summary>
public interface IControlInterface : IDisposable
{
    /// <summary>
    ///     The current status.
    /// </summary>
    Status Status { get; }

    /// <summary>
    ///     Event that gets fired if the application should shut down.
    /// </summary>
    event EventHandler ShutdownRequested;

    /// <summary>
    ///     Starts the controller.
    /// </summary>
    void Start(string configurationName);

    /// <summary>
    ///     Stop the controller.
    /// </summary>
    void Stop();

    /// <summary>
    ///     Starts measuring.
    /// </summary>
    void StartMeasurement();

    /// <summary>
    ///     Stop measuring.
    /// </summary>
    void StopMeasurement();

    /// <summary>
    ///     Starts the test program.
    /// </summary>
    /// <param name="startInfo">The start info. Contains procedure name and assembly information.</param>
    void StartProcessControl(ProcessControlStartInfo startInfo);

    /// <summary>
    ///     Requests a stop of the process controller.
    /// </summary>
    /// <param name="procedureName">Name of the test to be stopped.</param>
    void StopProcessControl(string procedureName);

    /// <summary>
    ///     Stops all currently running tests.
    /// </summary>
    void StopAllProcessControls();

    /// <summary>
    ///     Starts a Capture with the given Id for set amount of cycles.
    /// </summary>
    /// <param name="id">The Id of the Capture.</param>
    /// <param name="cycleAmount">The amount of cycles to measure.</param>
    void Capture(Guid id, long cycleAmount);

    /// <summary>
    ///     Start a capture with the given Id for set duration.
    /// </summary>
    /// <param name="id">The Id of the Capture.</param>
    /// <param name="duration">The duration to measure for.</param>
    void Capture(Guid id, TimeSpan duration);

    /// <summary>
    ///     Updates the Raster of a specified Task.
    /// </summary>
    /// <param name="taskId">The ID of the Task.</param>
    /// <param name="raster">The new Raster to set.</param>
    void UpdateRaster(Guid taskId, long raster);

    /// <summary>
    ///     Configures the ControlInterface
    /// </summary>
    /// <param name="configurationName">The name of the configuration file without file extension.</param>
    /// <param name="configurationStream">The new configuration as Stream.</param>
    void AddConfiguration(string configurationName, Stream configurationStream);

    /// <summary>
    ///     Removes a configuration.
    /// </summary>
    /// <param name="configurationName">The name of the xconfiguration to remove.</param>
    void RemoveConfiguration(string configurationName);
}

[Flags]
public enum Status
{
    Initializing = 0,
    Running = 1,
    Measuring = 2,
    Stopped = 4
}
