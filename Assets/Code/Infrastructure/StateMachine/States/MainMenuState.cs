using UnityEngine;

public class MainMenuState : IState
{
    private readonly GameStateMachine _gameStateMachine;
    private readonly IConfigProvider _configProvider;
    private readonly IInputService _inputService;
    private MainMenu _mainMenu;

    public MainMenuState(GameStateMachine gameStateMachine, IConfigProvider configProvider, IInputService inputService)
    {
        _gameStateMachine = gameStateMachine;
        _configProvider = configProvider;
        _inputService = inputService;
    }

    public void Enter()
    {
        var playerPrefab = _configProvider.GetPlayerConfig().Prefab;
        var player = Object.Instantiate(playerPrefab);

        CreateMainMenu(player);
        Camera.main.GetComponent<CameraFollow>().SetTarget(player.transform);
    }

    public void Exit() => Object.Destroy(_mainMenu.gameObject);

    private void CreateMainMenu(Player player)
    {
        var levelNumber = Const.TempLevelIndex;
        var levelConfig = _configProvider.GetLevelConfig(levelNumber);

        _mainMenu = Object.Instantiate(_configProvider.GetWindowPrefab<MainMenu>());
        _mainMenu.SetLevelText(levelNumber + 1);
        _mainMenu.StartGameButton.onClick.AddListener(() =>
        {
            player.Initialize(levelConfig, _inputService);
            _gameStateMachine.Enter<GameLoopState, LevelConfig>(levelConfig);
        });
    }
}