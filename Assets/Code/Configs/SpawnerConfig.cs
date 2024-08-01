using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Configs/" + nameof(SpawnerConfig), fileName = nameof(SpawnerConfig))]
public class SpawnerConfig : ScriptableObject
{
    [SerializeField] private float destroyDelay = 3.0f;
    [SerializeField] private List<CubesPattern> cubesPatterns;
    [SerializeField] private List<ObstaclePattern> obstaclePatterns;

    public float DestroyDelay => destroyDelay;
    public IReadOnlyList<CubesPattern> CubesPatterns => cubesPatterns;
    public IReadOnlyList<ObstaclePattern> ObstaclePatterns => obstaclePatterns;
}