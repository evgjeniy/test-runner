using System.Collections.Generic;
using System.Linq;
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

    public Pattern SpawnNext(Pattern current, Player player) => Object.Instantiate
    (
        original: GetPatternPrefab(player),
        position: current.transform.position + new Vector3(0, 0, _config.SpawnDistance),
        rotation: Quaternion.identity
    );

    private Pattern GetPatternPrefab(Player player)
    {
        if (_spawnedPatterns.Count != 0 && _spawnedPatterns[^1] is not EmptyPattern)
            return _config.EmptyPattern;
        
        if (Random.Range(0, 2) == 0)
            return _config.CubesPatterns.Random();

        var obstaclesCount = _spawnedPatterns.Count(pattern => pattern is ObstaclePattern);

        return player.Health.Current - obstaclesCount > 0
            ? _config.ObstaclePatterns.Random()
            : _config.ObstaclePatterns.Where(pattern => !pattern.IsImpossible).Random();
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