#region

using System.Diagnostics;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Scotec.Extensions.Linq;
using SignalF.Controller.Configuration;
using SignalF.Controller.DataOutput;
using SignalF.Controller.Schedule;
using SignalF.Controller.Signals.ProcessControl;

#endregion

namespace SignalF.Controller;

public sealed class ControlInterface : IControlInterface
{
    private readonly IConfiguration _configuration;
    private readonly ISignalFConfigurationManager _configurationManager;
    private readonly IDataOutputManager _dataOutputManager;
    private readonly IProcessControlHost _processControlHost;
    private readonly IEnumerable<IService> _services;

    /// <summary>
    ///     Constructor
    /// </summary>
    /// <param name="services">List of services like signal hub, task scheduler ánd signal dispatcher</param>
    /// <param name="configurationManager"></param>
    /// <param name="dataOutputManager"></param>
    /// <param name="processControlHost"></param>
    /// <param name="configuration"></param>
    /// <param name="logger"></param>
    public ControlInterface(IEnumerable<IService> services,
                            ISignalFConfigurationManager configurationManager,
                            IDataOutputManager dataOutputManager,
                            IProcessControlHost processControlHost,
                            IConfiguration configuration,
                            ILogger<ControlInterface> logger)
    {
        Logger = logger;
        _services = services;
        _configurationManager = configurationManager;
        _dataOutputManager = dataOutputManager;
        _processControlHost = processControlHost;
        _configuration = configuration;
    }

    private ILogger<ControlInterface> Logger { get; }

    private bool IsMeasuring
    {
        get => (Status & Status.Measuring) == Status.Measuring;
        set
        {
            if (value)
            {
                Status |= Status.Measuring;
            }
            else
            {
                Status &= ~Status.Measuring;
            }
        }
    }

    private bool IsRunning
    {
        get => (Status & Status.Running) == Status.Running;
        set
        {
            if (value)
            {
                Status |= Status.Running;
            }
            else
            {
                Status &= ~Status.Running;
            }
        }
    }

    private bool IsStopped
    {
        get => (Status & Status.Stopped) == Status.Stopped;
        set
        {
            if (value)
            {
                Status |= Status.Stopped;
            }
            else
            {
                Status &= ~Status.Stopped;
            }
        }
    }

    public Status Status { get; private set; }
    public event EventHandler ShutdownRequested;

    /// <inheritdoc />
    public void Start(string configurationName)
    {
        if (IsRunning)
        {
            return;
        }

        Logger.LogInformation("Starting Control Interface.");

        SetProcessPriority();

        // Configure the system before starting.
        _configurationManager.Configure(configurationName);

        // start basic system; init hardware etc.
        _services.ForAll(s => s.Initialize());
        _services.ForAll(s => s.Run());

        IsStopped = false;
        IsRunning = true;
        Logger.LogInformation("Started Control Interface.");
    }

    /// <inheritdoc />
    public void Stop()
    {
        if (IsStopped)
        {
            return;
        }

        if (!IsRunning)
        {
            return;
        }

        Logger.LogInformation("Stopping Control Interface.");

        StopMeasurement();
        _processControlHost.StopAllProcessControls();

        _services.ForAll(s => s.Shutdown());

        // Unload the configuration.
        _configurationManager.UnloadConfiguration();

        IsRunning = false;
        IsStopped = true;

        SetProcessPriority(ProcessPriorityClass.Normal);

        Logger.LogInformation("Stopped Control Interface.");
    }

    /// <inheritdoc />
    public void StartMeasurement()
    {
        if (!IsRunning)
        {
            return;
        }

        if (IsMeasuring)
        {
            return;
        }

        Logger.LogInformation("Starting measurement.");

        _dataOutputManager.StartMeasurement();

        IsMeasuring = true;
        Logger.LogInformation("Started measurement.");
    }

    /// <inheritdoc />
    public void StopMeasurement()
    {
        if (!IsMeasuring)
        {
            return;
        }

        Logger.LogInformation("Stopping measurement.");

        _dataOutputManager.StopMeasurement();

        IsMeasuring = false;

        Logger.LogInformation("Stopped measurement.");
    }

    /// <inheritdoc />
    public void StartProcessControl(ProcessControlStartInfo startInfo)
    {
        if (!IsMeasuring)
        {
            StartMeasurement();
        }

        _processControlHost.StartProcessControl(startInfo);
    }

    /// <inheritdoc />
    public void StopProcessControl(string programName)
    {
        _processControlHost.StopProcessControl(programName);
    }

    /// <inheritdoc />
    public void StopAllProcessControls()
    {
        _processControlHost.StopAllProcessControls();
    }

    /// <inheritdoc />
    public void Capture(Guid id, long cycleAmount)
    {
        if (!IsRunning)
        {
            return;
        }

        _dataOutputManager.StartCapture(id, cycleAmount);
    }

    /// <inheritdoc />
    public void Capture(Guid id, TimeSpan duration)
    {
        if (!IsRunning)
        {
            return;
        }

        ;

        _dataOutputManager.StartCapture(id, duration);
    }

    /// <inheritdoc />
    public void UpdateRaster(Guid taskId, long raster)
    {
        ((ITaskScheduler)_services.Single(s => s is ITaskScheduler)).UpdateRaster(taskId, raster);
    }

    public void RemoveConfiguration(string configurationName)
    {
        _configurationManager.RemoveConfiguration(configurationName);
    }

    /// <inheritdoc />
    public void AddConfiguration(string configurationName, Stream configurationStream)
    {
        //if (IsRunning)
        //{
        //    Logger.LogWarning("System should not be running when trying to change configuration!");
        //    Logger.LogWarning("New configuration was not applied.");
        //}

        _configurationManager.AddConfiguration(configurationName, configurationStream);

        //ShutdownRequested?.Invoke(this, EventArgs.Empty);
    }

    public void Dispose()
    {
        Stop();
    }

    private void SetProcessPriority()
    {
        var value = _configuration.GetSection("ProcessPriority").Get<string>();
        if (string.IsNullOrEmpty(value))
        {
            return;
        }

        if (Enum.TryParse(value, out ProcessPriorityClass priority))
        {
            SetProcessPriority(priority);
        }
    }

    private void SetProcessPriority(ProcessPriorityClass priority)
    {
        Logger.LogInformation($"Set process priority to '{priority}'.");

        var process = Process.GetCurrentProcess();
        process.PriorityClass = priority;
    }
}
