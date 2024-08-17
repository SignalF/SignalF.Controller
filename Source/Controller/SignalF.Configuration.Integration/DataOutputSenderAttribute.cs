using System.Diagnostics;

namespace SignalF.Configuration.Integration;

[AttributeUsage(AttributeTargets.Class)]
[Conditional("SCOTECT4ATTRIBUTE")]
public class DataOutputSenderAttribute : Attribute
{
    public Type OptionsType { get; set; }
}
