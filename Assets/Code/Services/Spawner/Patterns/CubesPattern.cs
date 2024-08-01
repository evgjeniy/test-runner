using System.Linq;
using UnityEngine;

public class CubesPattern : Pattern
{
    [SerializeField] private Vector3[] spawnPoints;
    [SerializeField] private Cube prefab;

    private void Start()
    {
        /*var player = Services.All.Resolve<GameLoopStateMachine>().Player;
        var cubesInStack = player.Stack.Cubes.ToDictionary(x => x.Color, _ => 0);
        foreach (var cube in player.Stack.Cubes)
            cubesInStack[cube.Color]++;*/

        for (int i = 0; i < spawnPoints.Length; i++)
        {
            var cube = Instantiate(prefab, transform.position + spawnPoints[i], Quaternion.identity, transform);
            cube.Construct(Random.Range(0, 3) switch
            {
                0 => Color.red,
                1 => Color.green,
                _ => Color.blue
            });
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.blue;

        foreach (var spawnPoint in spawnPoints)
            Gizmos.DrawSphere(transform.position + spawnPoint, 0.15f);
    }
}