public interface ISaveService : IService
{
    void Set<TData>(string key, TData data);
    bool TryGet<TData>(string key, out TData data);
    bool Remove(string key);
}