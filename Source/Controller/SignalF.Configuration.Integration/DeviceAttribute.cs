using System.Diagnostics;

namespace SignalF.Configuration.Integration;

[AttributeUsage(AttributeTargets.Class)]
[Conditional("SCOTECT4ATTRIBUTE")]
public class DeviceAttribute : Attribute
{
    public Type OptionsType { get; set; }
}
