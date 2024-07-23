using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class PlayerInventory : MonoBehaviour, IInventory
{
    [SerializeField] private Transform cubeStackRoot;

    private readonly List<Cube> _cubes = new();
    private const int CubesMaxCount = 14;

    public int Amount => _cubes.Count;

    public void Collect(Cube cube)
    {
        if (_cubes.Count == CubesMaxCount)
        {
            Destroy(cube.gameObject);
        }
        else
        {
            _cubes.Add(cube);

            cubeStackRoot.position += Vector3.up;
            cube.transform.parent = cubeStackRoot;
            cube.transform.localPosition = -Vector3.up * _cubes.Count;
        }
    }

    public void DestroyLast()
    {
        var cubeToDestroy = _cubes[^1];

        _cubes.Remove(cubeToDestroy);
        Destroy(cubeToDestroy.gameObject);

        cubeStackRoot.position -= Vector3.up;
    }
}