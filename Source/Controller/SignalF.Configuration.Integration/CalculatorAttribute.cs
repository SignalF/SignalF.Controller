using System.Diagnostics;

namespace SignalF.Configuration.Integration;

[AttributeUsage(AttributeTargets.Class)]
[Conditional("SCOTECT4ATTRIBUTE")]
public class CalculatorAttribute : Attribute
{
    public Type OptionsType { get; set; }
}
