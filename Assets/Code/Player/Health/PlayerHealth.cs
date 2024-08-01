public class PlayerHealth : IHealth
{
    private readonly IStack _stack;
    private readonly GameLoopStateMachine _gameLoop;

    public int Current => _stack.Cubes.Count;

    public PlayerHealth(IStack stack, GameLoopStateMachine gameLoop)
    {
        _stack = stack;
        _gameLoop = gameLoop;
    }

    public void TakeDamage()
    {
        if (_stack.Cubes.Count == 0)
            _gameLoop.Enter<GameLoseState>();
        else
            _stack.DestroyLast();
    }
}