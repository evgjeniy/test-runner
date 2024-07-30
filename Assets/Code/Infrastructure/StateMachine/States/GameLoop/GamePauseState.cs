using UnityEngine;

public class GamePauseState : IState
{
    private readonly GameLoopStateMachine _gameLoop;
    private readonly IConfigProvider _configProvider;
    private PauseWindow _pauseWindow;

    public GamePauseState(GameLoopStateMachine gameLoop, IConfigProvider configProvider)
    {
        _gameLoop = gameLoop;
        _configProvider = configProvider;
    }

    public void Enter()
    {
        _pauseWindow = Object.Instantiate(_configProvider.GetWindowPrefab<PauseWindow>()).Construct
        (
            onClose: _gameLoop.Enter<GamePlayState>,
            onMainMenu: _gameLoop.Enter<GameLoopExitState>
        );

        Time.timeScale = 0.0f;
    }

    public void Exit()
    {
        Time.timeScale = 1.0f;
        Object.Destroy(_pauseWindow.gameObject);
    }
}