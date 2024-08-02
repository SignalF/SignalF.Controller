namespace SignalF.Configuration;

[AttributeUsage(AttributeTargets.Class)]
public class DeviceAttribute : Attribute
{
    public Type OptionsType { get; set; }
}
