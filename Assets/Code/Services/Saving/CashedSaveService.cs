using System.Collections.Generic;

public class CashedSaveService : ISaveService
{
    private const string SaveSystemKey = "Saves";

    private readonly ISaveService _baseSaveService;

    private abstract class SaveItem { public string Key; }
    private class SaveItem<TData> : SaveItem { public TData Data; }

    private readonly Dictionary<string, SaveItem> _items;

    public CashedSaveService(ISaveService baseSaveService)
    {
        _baseSaveService = baseSaveService;

        _items = _baseSaveService.TryGet(SaveSystemKey, out Dictionary<string, SaveItem> savedItems)
            ? savedItems
            : new Dictionary<string, SaveItem>(capacity: 8);
    }

    public void Set<TData>(string key, TData data)
    {
        _items.TryAdd(key, null);
        _items[key] = new SaveItem<TData> { Data = data, Key = key };

        _baseSaveService.Set(SaveSystemKey, _items);
    }

    public bool TryGet<TData>(string key, out TData data)
    {
        data = default;
        if (!_items.TryGetValue(key, out var item)) return false;
        if (item is not SaveItem<TData> saveItem) return false;

        data = saveItem.Data;
        return true;
    }

    public bool Remove(string key)
    {
        if (_items.Remove(key, out var item) is false)
            return false;

        _baseSaveService.Set(SaveSystemKey, _items);
        return true;
    }
}