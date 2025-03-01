using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class CubesPattern : Pattern
{
    [SerializeField] private Vector3[] spawnPoints;
    [SerializeField] private Cube prefab;

    private void Start()
    {
        var gameLoop = Services.All.Resolve<GameLoopStateMachine>();

        var requiredColors = GetRequiredColors(gameLoop.Player);
        var otherColors = gameLoop.Config.ColorsToComplete.Except(requiredColors).ToList();

        SpawnCubes(requiredColors, otherColors);
    }

    private void SpawnCubes(List<ColorTaskConfig> requiredColors, List<ColorTaskConfig> otherColors)
    {
        for (var i = 0; i < spawnPoints.Length; i++)
        {
            var cube = Instantiate(prefab, transform.position + spawnPoints[i], Quaternion.identity, transform);
            if (requiredColors.Count == 0)
            {
                cube.Construct(otherColors.Random());
            }
            else if (otherColors.Count == 0)
            {
                cube.Construct(requiredColors.Random());
            }
            else
            {
                var chance = Mathf.Clamp01(1 - i / (spawnPoints.Length - 1.0f));
                cube.Construct(Random.value > chance ? otherColors.Random() : requiredColors.Random());
            }
        }
    }

    private static List<ColorTaskConfig> GetRequiredColors(Player player) => player.Stack.Cubes.Join
    (
        player.Inventory.ColorsData.Where(data => !data.IsCollected),
        cube => cube.ColorTask,
        data => data.Config,
        (_, data) => data.Config
    ).ToList();

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.blue;

        foreach (var spawnPoint in spawnPoints)
            Gizmos.DrawSphere(transform.position + spawnPoint, 0.15f);
    }
}