using UnityEngine;

public class MainMenuState : IState
{
    private readonly GameStateMachine _gameStateMachine;
    private readonly IConfigProvider _configProvider;
    private MainMenu _mainMenu;

    public MainMenuState(GameStateMachine gameStateMachine, IConfigProvider configProvider)
    {
        _gameStateMachine = gameStateMachine;
        _configProvider = configProvider;
    }

    public void Enter()
    {
        var levelConfig = _configProvider.GetLevelConfig(Const.TempLevelIndex); // TODO : load index from saves

        _mainMenu = Object.Instantiate(_configProvider.GetWindowPrefab<MainMenu>());
        _mainMenu.StartGameButton.onClick.AddListener(() =>
        {
            _gameStateMachine.Enter<GameLoopState, LevelConfig>(levelConfig);
        });
    }

    public void Exit() => Object.Destroy(_mainMenu.gameObject);
}