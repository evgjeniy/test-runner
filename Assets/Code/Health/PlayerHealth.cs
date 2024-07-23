using UnityEngine;

[RequireComponent(typeof(IInventory))]
public class PlayerHealth : MonoBehaviour, IHealth
{
    private IInventory _inventory;
    
    private void Awake() => _inventory = GetComponent<IInventory>();

    public void TakeDamage()
    {
        if (_inventory.Amount == 0)
        {
            // Death
            // _levelManager.Lose();
        }
        else
        {
            _inventory.DestroyLast();
        }
    }
}