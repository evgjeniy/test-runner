public class GameWinState : IState
{
    private readonly GameLoopStateMachine _gameLoop;

    public GameWinState(GameLoopStateMachine gameLoop)
    {
        _gameLoop = gameLoop;
    }
}