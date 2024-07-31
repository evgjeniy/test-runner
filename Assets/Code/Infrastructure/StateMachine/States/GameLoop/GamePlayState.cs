public class GamePlayState : IState
{
    private readonly GameLoopStateMachine _gameLoop;
    private readonly IInputService _inputService;

    public GamePlayState(GameLoopStateMachine gameLoop, IInputService inputService)
    {
        _gameLoop = gameLoop;
        _inputService = inputService;
    }

    public void Enter() => _gameLoop.Player.enabled = true;
    public void Exit() => _gameLoop.Player.enabled = false;
    public void Update() => _inputService.HandleSwipe();
}