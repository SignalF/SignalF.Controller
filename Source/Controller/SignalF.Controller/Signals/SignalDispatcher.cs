#region

using System;

#endregion

namespace SignalF.Controller.Signals;

public class SignalDispatcher : ISignalDispatcher
{
    private readonly ISignalHub _signalHub;
    private bool _isRunning;

    public SignalDispatcher(ISignalHub signalHub)
    {
        _signalHub = signalHub;

        _signalHub.DataAvailable += OnDataAvailable;
    }

    public event EventHandler<DispatcherEventArgs> Dispatch;

    public void Initialize()
    {
    }

    public void Run()
    {
        _isRunning = true;
    }

    public void Shutdown()
    {
        _isRunning = false;
    }

    private void OnDataAvailable(object sender, EventArgs e)
    {
        if (!_isRunning)
        {
            return;
        }

        var values = _signalHub.GetCurrentBufferContent();

        if (values != null)
        {
            Dispatch?.Invoke(this, new DispatcherEventArgs(values));
        }
    }
}
