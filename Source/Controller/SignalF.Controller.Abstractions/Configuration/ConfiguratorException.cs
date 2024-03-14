using System;

namespace SignalF.Controller.Configuration;

public class ConfiguratorException : ApplicationException
{
    public ConfiguratorException(string message)
        : base(message)
    {
    }
}
