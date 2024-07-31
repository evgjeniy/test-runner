public class PlayerHealth : IHealth
{
    private readonly GameLoopStateMachine _gameLoopStateMachine = Services.All.Resolve<GameLoopStateMachine>();
    private readonly IInventory _inventory;

    public PlayerHealth(IInventory inventory) => _inventory = inventory;

    public void TakeDamage()
    {
        if (_inventory.Cubes.Count == 0)
            _gameLoopStateMachine.Enter<GameLoseState>();
        else
            _inventory.DestroyLast();
    }
}