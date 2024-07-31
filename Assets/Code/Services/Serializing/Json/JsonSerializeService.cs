using System.Collections.Generic;
using Newtonsoft.Json;

public class JsonSerializeService : ISerializeService
{
    private readonly JsonSerializerSettings _serializerSettings = new()
    {
        TypeNameHandling = TypeNameHandling.All,
        Converters = new List<JsonConverter>
        {
            new SpriteConverter()
        },
        Formatting = Formatting.Indented
    };

    public string Serialize<TData>(TData data)
    {
        var serialized = JsonConvert.SerializeObject(data, _serializerSettings);
        return serialized;
    }

    public TData Deserialize<TData>(string serialized)
    {
        var data = JsonConvert.DeserializeObject<TData>(serialized, _serializerSettings);
        return data;
    }
}