using System.Collections.Generic;
using UnityEngine;

public class PlayerInventory : IInventory
{
    private readonly LevelConfig _levelConfig;
    private readonly Transform _cubeStackRoot;
    private readonly List<Cube> _cubes = new(capacity: 16);

    public int Amount => _cubes.Count;

    public PlayerInventory(LevelConfig levelConfig, Transform cubeStackRoot)
    {
        _levelConfig = levelConfig;
        _cubeStackRoot = cubeStackRoot;
    }

    public void Collect(Cube cube)
    {
        if (_cubes.Count == _levelConfig.MaxStackAmount)
        {
            Object.Destroy(cube.gameObject);
        }
        else
        {
            _cubes.Add(cube);

            _cubeStackRoot.position += Vector3.up;
            cube.transform.parent = _cubeStackRoot;
            cube.transform.localPosition = -Vector3.up * _cubes.Count;
        }
    }

    public void DestroyLast()
    {
        if (_cubes.Count == 0) return;
        
        var cubeToDestroy = _cubes[^1];

        _cubes.Remove(cubeToDestroy);
        Object.Destroy(cubeToDestroy.gameObject);

        _cubeStackRoot.position -= Vector3.up;
    }
}