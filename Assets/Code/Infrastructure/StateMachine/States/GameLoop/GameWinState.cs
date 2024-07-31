using UnityEngine;

public class GameWinState : IState
{
    private readonly GameLoopStateMachine _gameLoop;
    private readonly IConfigProvider _configProvider;
    private readonly ISaveService _saveService;
    private WinWindow _winWindow;

    public GameWinState(GameLoopStateMachine gameLoop, IConfigProvider configProvider, ISaveService saveService)
    {
        _gameLoop = gameLoop;
        _configProvider = configProvider;
        _saveService = saveService;
    }

    public void Enter()
    {
        _winWindow = Object.Instantiate(_configProvider.GetWindowPrefab<WinWindow>()).Construct
        (
            onContinue: _gameLoop.Enter<GameLoopExitState>
        );

        SaveCompletedLevelNumber();
    }

    public void Exit() => Object.Destroy(_winWindow.gameObject);

    private void SaveCompletedLevelNumber()
    {
        if (_saveService.TryGet(Const.Saves.Level, out int levelNumber))
            _saveService.Set(Const.Saves.Level, levelNumber + 1);
        else
            _saveService.Set(Const.Saves.Level, 1);
    }
}