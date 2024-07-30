using UnityEngine;

public class GameLoopState : IPayloadState<LevelConfig>
{
    private readonly GameLoopStateMachine _gameLoopStateMachine;
    private readonly IConfigProvider _configProvider;
    private GameHud _gameHud;

    public GameLoopState(GameStateMachine gameStateMachine, Services services)
    {
        _gameLoopStateMachine = new GameLoopStateMachine(gameStateMachine, services);
        _configProvider = services.Resolve<IConfigProvider>();
    }

    public void Enter(LevelConfig levelConfig)
    {
        _gameHud = Object.Instantiate(_configProvider.GetWindowPrefab<GameHud>()).Construct
        (
            levelConfig,
            onPause: _gameLoopStateMachine.Enter<GamePauseState>
        );
        _gameLoopStateMachine.Enter<GamePlayState>();
    }

    public void Update()
    {
        _gameLoopStateMachine.Update();
    }

    public void Exit()
    {
        if (_gameHud != null)
            Object.Destroy(_gameHud.gameObject);
    }
}