#region

using SignalF.Datamodel.DataOutput;

#endregion

namespace SignalF.Controller.DataOutput;

public interface IDataOutput
{
    /// <summary>
    ///     The ID of the DataOutput
    /// </summary>
    Guid Id { get; }

    /// <summary>
    ///     The name of the DataOutput
    /// </summary>
    string Name { get; }

    /// <summary>
    ///     Configures the DataOutput.
    /// </summary>
    /// <param name="configuration">The configuration.</param>
    void Configure(IDataOutputConfiguration configuration);

    /// <summary>
    ///     Stops dispatching values.
    /// </summary>
    void Stop();

    /// <summary>
    ///     Sets new filter without any restrictions and starts dispatching values.
    /// </summary>
    void SetFilter();

    /// <summary>
    ///     Sets new filter with specific amount of measurement cycles and starts dispatching values.
    /// </summary>
    /// <param name="cycleAmount">The amount of measuring cycles.</param>
    void SetFilter(long cycleAmount);

    /// <summary>
    ///     Sets new filter with specific measurement duration and starts dispatching values.
    /// </summary>
    /// <param name="duration">The TimeSpan how long to measure.</param>
    void SetFilter(TimeSpan duration);
}
