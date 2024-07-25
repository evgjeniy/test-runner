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
        var mainMenuConfig = _configProvider.GetWindowConfig(WindowType.MainMenu);

        _mainMenu = Object.Instantiate(mainMenuConfig.Prefab as MainMenu);
        _mainMenu.StartGameButton.onClick.AddListener(StartGame);
    }

    private void StartGame()
    {
        var config = _configProvider.GetLevelConfig(index: 0);
        _gameStateMachine.Enter<GamePlayState, LevelConfig>(config);
    }

    public void Exit() => Object.Destroy(_mainMenu.gameObject);
}