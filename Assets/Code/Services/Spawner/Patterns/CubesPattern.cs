using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class CubesPattern : Pattern
{
    [SerializeField] private Vector3[] spawnPoints;
    [SerializeField] private Cube prefab;
    [SerializeField] private float seconds = 3.0f; // TODO : Remove (test)

    private IEnumerator Start()
    {
        yield return new WaitForSeconds(seconds);
        
        var gameLoop = Services.All.Resolve<GameLoopStateMachine>();
        var requiredColors = GetRequiredColors(gameLoop);
        var otherColors = gameLoop.Config.ColorsToComplete.Except(requiredColors).ToList();

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

    private static List<ColorTaskConfig> GetRequiredColors(GameLoopStateMachine gameLoop)
    {
        return gameLoop.Player.Stack.Cubes.Join
        (
            gameLoop.Player.Inventory.ColorsData.Where(data => !data.IsCollected),
            cube => cube.ColorTask,
            data => data.Config,
            (_, data) => data.Config
        ).ToList();
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.blue;

        foreach (var spawnPoint in spawnPoints)
            Gizmos.DrawSphere(transform.position + spawnPoint, 0.15f);
    }
}