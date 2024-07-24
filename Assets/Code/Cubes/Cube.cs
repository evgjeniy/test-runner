using UnityEngine;

[RequireComponent(typeof(Collider))]
public class Cube : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (!other.TryGetComponent(out Player player))
            return;

        player.Inventory.Collect(this);
    }
}