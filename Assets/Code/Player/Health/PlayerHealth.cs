public class PlayerHealth : IHealth
{
    private readonly IInventory _inventory;

    public PlayerHealth(IInventory inventory) => _inventory = inventory;

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