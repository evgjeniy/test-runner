using UnityEngine;

public class GameLoseState : IState
{
    private readonly GameLoopStateMachine _gameLoop;
    private readonly IConfigProvider _configProvider;
    private LoseWindow _loseWindow;

    public GameLoseState(GameLoopStateMachine gameLoop, IConfigProvider configProvider)
    {
        _gameLoop = gameLoop;
        _configProvider = configProvider;
    }

    public void Enter()
    {
        _loseWindow = Object.Instantiate(_configProvider.GetWindowPrefab<LoseWindow>()).Construct
        (
            onRestart: _gameLoop.Enter<GameLoopExitState>
        );
    }

    public void Exit() => Object.Destroy(_loseWindow.gameObject);
}