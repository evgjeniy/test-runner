using UnityEngine;

public class GamePlayState : IPayloadState<LevelConfig>
{
    private readonly IGameStateMachine _gameStateMachine;
    private readonly IInputService _inputService;
    private readonly IConfigProvider _configProvider;
    private GameHud _gameHud;

    public GamePlayState(IGameStateMachine gameStateMachine, IInputService inputService, IConfigProvider configProvider)
    {
        _gameStateMachine = gameStateMachine;
        _inputService = inputService;
        _configProvider = configProvider;
    }

    public void Enter(LevelConfig levelConfig)
    {
        var player = Object.FindObjectOfType<Player>(true);
        player.Initialize(levelConfig, _inputService);

        var gameHudConfig = _configProvider.GetWindowConfig(WindowType.GameHud);
        _gameHud = Object.Instantiate(gameHudConfig.Prefab as GameHud);
        _gameHud.Pause.onClick.AddListener(PauseGame);
    }

    public void Update() => _inputService.HandleSwipe();

    public void Exit() => Object.Destroy(_gameHud.gameObject);

    private void PauseGame() => _gameStateMachine.Enter<GamePauseState>();
}