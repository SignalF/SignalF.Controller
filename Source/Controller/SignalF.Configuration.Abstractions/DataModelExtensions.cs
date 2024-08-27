using System.Text.Json;
using SignalF.Datamodel.Base;

namespace SignalF.Configuration;

public static class DataModelExtensions
{
    private static JsonSerializerOptions s_serializerOptions = new JsonSerializerOptions
    {
        WriteIndented = false,
    };

    public static void Set<TConfiguration>(this IConfiguration configuration, TConfiguration data)
        where TConfiguration : SignalFConfigurationOptions
    {
        if (configuration == null)
        {
            throw new ArgumentNullException(nameof(configuration));
        }

        if (data == null)
        {
            configuration.Data = null;
            return;
        }

        //var json = JsonSerializer.SerializeToUtf8Bytes(data, data.GetType());
        //configuration.Data = Convert.ToBase64String(json);
        var json = JsonSerializer.Serialize(data, s_serializerOptions);
        configuration.Data = json;
    }

    public static TConfiguration Get<TConfiguration>(this IConfiguration configuration)
        where TConfiguration : SignalFConfigurationOptions
    {
        if (configuration == null)
        {
            throw new ArgumentNullException(nameof(configuration));
        }

        if (configuration.Data == null)
        {
            return null;
        }

        //var json = Convert.FromBase64String(configuration.Data);
        //return JsonSerializer.Deserialize<TConfiguration>(json);
        return JsonSerializer.Deserialize<TConfiguration>(configuration.Data);
    }
}
