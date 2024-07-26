public class GameLoseState : IState
{
    private readonly GameLoopState _gameLoop;

    public GameLoseState(GameLoopState gameLoop)
    {
        _gameLoop = gameLoop;
    }
}