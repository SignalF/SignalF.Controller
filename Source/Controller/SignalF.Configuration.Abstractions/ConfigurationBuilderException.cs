using System;

namespace SignalF.Configuration;

public class ConfigurationBuilderException : ApplicationException
{
    public ConfigurationBuilderException(string message)
        : base(message)
    {
    }
}
