using UnityEngine;

public class GameLoopState : IPayloadState<LevelConfig>
{
    private readonly GameLoopStateMachine _gameLoopStateMachine;
    private readonly IConfigProvider _configProvider;

    private GameHud _gameHud;

    public LevelConfig LevelConfig { get; private set; }
    public GameLoopStateMachine StateMachine => _gameLoopStateMachine;

    public GameLoopState(GameStateMachine gameStateMachine, Services services)
    {
        _gameLoopStateMachine = new GameLoopStateMachine(this, gameStateMachine, services);
        _configProvider = services.Resolve<IConfigProvider>();
    }

    public void Enter(LevelConfig config)
    {
        LevelConfig = config;

        _gameHud = Object.Instantiate(_configProvider.GetWindowPrefab<GameHud>());
        _gameHud.Construct(config);
        _gameHud.Pause.onClick.AddListener(_gameLoopStateMachine.Enter<GamePauseState>);

        _gameLoopStateMachine.Enter<GamePlayState>();
    }

    public void Update()
    {
        _gameLoopStateMachine.Update();
    }

    public void Exit()
    {
        LevelConfig = null;

        if (_gameHud != null)
            Object.Destroy(_gameHud.gameObject);
    }
}