using UnityEngine;

[RequireComponent(typeof(Collider))]
public class Cube : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (!other.TryGetComponent(out IInventory inventory))
            return;

        inventory.Collect(this);
    }
}