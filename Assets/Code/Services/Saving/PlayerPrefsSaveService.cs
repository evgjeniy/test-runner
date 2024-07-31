using UnityEngine;

public class PlayerPrefsSaveService : ISaveService
{
    private readonly ISerializeService _serializeService;

    public PlayerPrefsSaveService(ISerializeService serializeService)
    {
        _serializeService = serializeService;
    }

    public void Set<TData>(string key, TData data)
    {
        PlayerPrefs.SetString(key, _serializeService.Serialize(data));
    }

    public bool TryGet<TData>(string key, out TData data)
    {
        data = _serializeService.Deserialize<TData>(PlayerPrefs.GetString(key));
        return data != null;
    }

    public bool Remove(string key)
    {
        if (PlayerPrefs.HasKey(key) is false)
            return false;

        PlayerPrefs.DeleteKey(key);
        return true;
    }
}