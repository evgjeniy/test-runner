public class GameLoseState : IState
{
    private readonly GameLoopStateMachine _gameLoop;

    public GameLoseState(GameLoopStateMachine gameLoop)
    {
        _gameLoop = gameLoop;
    }
}