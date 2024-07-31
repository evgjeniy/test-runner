public interface ISerializeService : IService
{
    string Serialize<TData>(TData data);
    TData Deserialize<TData>(string serialized);
}