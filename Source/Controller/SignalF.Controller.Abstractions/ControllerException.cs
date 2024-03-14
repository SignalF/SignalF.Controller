using System;

namespace SignalF.Controller;

public class ControllerException : ApplicationException
{
    public ControllerException(string message)
        : base(message)
    {
    }
}
