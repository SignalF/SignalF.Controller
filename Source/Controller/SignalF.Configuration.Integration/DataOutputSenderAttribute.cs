using System.Diagnostics;

namespace SignalF.Configuration.Integration;

[AttributeUsage(AttributeTargets.Class)]
[Conditional("NETFRAMEWORK")]
public class DataOutputSenderAttribute : Attribute
{
    public Type OptionsType { get; set; }
}
