namespace SignalF.Controller;

public interface IService
{
    /// <summary>
    ///     Initializes the service.
    /// </summary>
    void Initialize();

    /// <summary>
    ///     Starts the service.
    /// </summary>
    void Run();

    /// <summary>
    ///     Stops the service.
    /// </summary>
    void Shutdown();
}
