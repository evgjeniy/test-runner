using UnityEngine;

public class GamePauseState : IState
{
    private readonly GameLoopState _gameLoop;
    private readonly IConfigProvider _configProvider;
    private PauseWindow _pauseWindow;

    public GamePauseState(GameLoopState gameLoop, IConfigProvider configProvider)
    {
        _gameLoop = gameLoop;
        _configProvider = configProvider;
    }

    public void Enter()
    {
        _pauseWindow = Object.Instantiate(_configProvider.GetWindowPrefab<PauseWindow>());
        _pauseWindow.Close.onClick.AddListener(_gameLoop.StateMachine.Enter<GamePlayState>);
        _pauseWindow.Continue.onClick.AddListener(_gameLoop.StateMachine.Enter<GamePlayState>);
        _pauseWindow.MainMenu.onClick.AddListener(_gameLoop.StateMachine.Enter<GameLoopExitState>);

        Time.timeScale = 0.0f;
    }

    public void Exit()
    {
        Time.timeScale = 1.0f;
        Object.Destroy(_pauseWindow.gameObject);
    }
}