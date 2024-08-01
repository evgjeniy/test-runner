using System.Collections.Generic;
using UnityEngine;

public class Spawner : ISpawner
{
    private readonly SpawnerConfig _config;
    private readonly List<Pattern> _spawnedPatterns;

    public Spawner(IConfigProvider configProvider)
    {
        _config = configProvider.GetSpawnerConfig();
        _spawnedPatterns = new List<Pattern>(capacity: 16);
    }

    public Pattern SpawnNext(Player component)
    {
        return null;
    }

    public void Add(Pattern pattern)
    {
        _spawnedPatterns.Add(pattern);
    }

    public void Remove(Pattern pattern)
    {
        if (_spawnedPatterns.Remove(pattern))
            Object.Destroy(pattern.gameObject, _config.DestroyDelay);
    }
}