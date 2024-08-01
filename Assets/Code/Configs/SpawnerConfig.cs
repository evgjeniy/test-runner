using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Config/" + nameof(SpawnerConfig), fileName = nameof(SpawnerConfig))]
public class SpawnerConfig : ScriptableObject
{
    [SerializeField] private float destroyDelay = 3.0f;
    [SerializeField] private float spawnDistance = 40.0f;
    [SerializeField] private Pattern emptyPattern;
    [SerializeField] private List<CubesPattern> cubesPatterns;
    [SerializeField] private List<ObstaclePattern> obstaclePatterns;

    public float DestroyDelay => destroyDelay;
    public float SpawnDistance => spawnDistance;
    public Pattern EmptyPattern => emptyPattern;
    public IReadOnlyList<CubesPattern> CubesPatterns => cubesPatterns;
    public IReadOnlyList<ObstaclePattern> ObstaclePatterns => obstaclePatterns;
}