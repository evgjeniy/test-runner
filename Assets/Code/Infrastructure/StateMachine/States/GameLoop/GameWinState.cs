public class GameWinState : IState
{
    private readonly GameLoopState _gameLoop;

    public GameWinState(GameLoopState gameLoop)
    {
        _gameLoop = gameLoop;
    }
}