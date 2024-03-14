namespace SignalF.Configuration;

internal interface IConfigurationObjectFactory
{
    TConfiguration CreateConfigurationObject<TConfiguration>();
}
