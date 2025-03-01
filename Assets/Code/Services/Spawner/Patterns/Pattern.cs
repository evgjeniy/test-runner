﻿using UnityEngine;

public abstract class Pattern : MonoBehaviour
{
    private ISpawner _spawner;
    private void Awake() => _spawner = Services.All.Resolve<ISpawner>();
    private void OnValidate() => GetComponent<Collider>().isTrigger = true;

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out Player player))
        {
            var newPattern = _spawner.SpawnNext(this, player);
            _spawner.Add(newPattern);
        }

        _spawner.Remove(this);
    }
}