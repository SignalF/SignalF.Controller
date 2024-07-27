#region

#endregion

namespace SignalF.Controller.Configuration;

public interface ISignalFConfigurationManager
{
    /// <summary>
    ///     Reads configuration file and configures the application.
    /// </summary>
    void Configure(string configurationName);

    /// <summary>
    ///     Saves configuration stream in 'Configuration.xml'.
    /// </summary>
    /// <param name="configurationName">The name of the configuration.</param>
    /// <param name="configurationStream">The configuration stream.</param>
    void AddConfiguration(string configurationName, Stream configurationStream);

    /// <summary>
    ///     Unloads the currently loaded configuration.
    /// </summary>
    void UnloadConfiguration();

    /// <summary>
    ///     Deletes a configuration file from the configuration folder.
    /// </summary>
    /// <param name="configurationName">The name of the configuration to delete.</param>
    void RemoveConfiguration(string configurationName);
}
