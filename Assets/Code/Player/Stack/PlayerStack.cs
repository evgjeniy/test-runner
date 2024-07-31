using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class PlayerStack : IStack
{
    private readonly LevelConfig _levelConfig;
    private readonly Transform _cubeStackRoot;
    private readonly List<Cube> _cubes = new(capacity: 16);

    public IReadOnlyList<Cube> Cubes => _cubes;
    public event System.Action<IStack> Changed = _ => { };
    public event System.Action<ColorTaskConfig, int> Collected = (_, _) => { }; 

    public PlayerStack(LevelConfig levelConfig, Transform cubeStackRoot)
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
            Changed(this);
            CheckCubesSequence();

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
        Changed(this);

        _cubeStackRoot.position -= Vector3.up;
    }

    private void CheckCubesSequence()
    {
        var lastCubeColor = _cubes[^1].Color;
        var colorTask = _levelConfig.ColorsToComplete.FirstOrDefault(task => task.Color == lastCubeColor);
        if (colorTask == null || _cubes.Count < colorTask.Collect) return;

        var lastCollectedCubes = new List<Cube>(capacity: colorTask.Collect);
        while (lastCollectedCubes.Count < colorTask.Collect)
        {
            var cube = _cubes[^(lastCollectedCubes.Count + 1)];
            if (cube.Color == lastCubeColor) lastCollectedCubes.Add(cube);
            else break;
        }

        if (lastCollectedCubes.Count != colorTask.Collect) return;
        foreach (var collectedCube in lastCollectedCubes)
        {
            _cubes.Remove(collectedCube);
            Object.Destroy(collectedCube.gameObject);
        }

        _cubeStackRoot.position -= Vector3.up * lastCollectedCubes.Count;

        Changed(this);
        Collected(colorTask, lastCollectedCubes.Count);
    }
}