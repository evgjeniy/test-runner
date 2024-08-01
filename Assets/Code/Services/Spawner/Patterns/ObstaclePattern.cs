using UnityEngine;

public class ObstaclePattern : Pattern
{
    [SerializeField] private Vector3[] spawnPoints;
    [SerializeField] private Obstacle prefab;
    [SerializeField] private bool isImpossible;

    public bool IsImpossible => isImpossible;

    private void Start()
    {
        foreach (var spawnPoint in spawnPoints)
            Instantiate(prefab, transform.position + spawnPoint, Quaternion.identity, transform);
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;

        foreach (var spawnPoint in spawnPoints)
            Gizmos.DrawSphere(transform.position + spawnPoint, 0.15f);
    }
}