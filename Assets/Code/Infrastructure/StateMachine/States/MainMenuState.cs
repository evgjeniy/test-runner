using UnityEngine;

public class MainMenuState : IState
{
    private readonly GameStateMachine _gameStateMachine;
    private readonly IConfigProvider _configProvider;
    private readonly IInputService _inputService;
    private readonly ISaveService _saveService;
    private MainMenu _mainMenu;

    public MainMenuState(GameStateMachine gameStateMachine, IConfigProvider configProvider, IInputService inputService, ISaveService saveService)
    {
        _gameStateMachine = gameStateMachine;
        _configProvider = configProvider;
        _inputService = inputService;
        _saveService = saveService;
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
        var levelNumber = _saveService.TryGet(Const.Saves.Level, out int level) ? level : 0;
        var levelConfig = _configProvider.GetLevelConfig(levelNumber);

        _mainMenu = Object.Instantiate(_configProvider.GetWindowPrefab<MainMenu>()).Construct
        (
            currentLevel: levelNumber + 1,
            onStart: () =>
            {
                player.Initialize(levelConfig, _inputService);
                _gameStateMachine.Enter<GameLoopState, GameLoopState.Payload>(new GameLoopState.Payload(levelConfig, player));
            }
        );
    }
}