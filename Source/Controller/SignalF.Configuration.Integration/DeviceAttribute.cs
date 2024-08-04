namespace SignalF.Configuration.Integration;

[AttributeUsage(AttributeTargets.Class)]
public class DeviceAttribute : Attribute
{
    public Type OptionsType { get; set; }
}
