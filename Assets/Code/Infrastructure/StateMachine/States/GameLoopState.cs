using UnityEngine;

public class GameLoopState : IPayloadState<GameLoopState.Payload>
{
    public struct Payload
    {
        public readonly LevelConfig LevelConfig;
        public readonly Player Player;

        public Payload(LevelConfig levelConfig, Player player)
        {
            LevelConfig = levelConfig;
            Player = player;
        }
    }
    
    private readonly GameLoopStateMachine _gameLoopStateMachine;
    private readonly IConfigProvider _configProvider;
    private GameHud _gameHud;

    public GameLoopState(GameStateMachine gameStateMachine, Services services)
    {
        _gameLoopStateMachine = services.Register(new GameLoopStateMachine(gameStateMachine, services));
        _configProvider = services.Resolve<IConfigProvider>();
    }

    public void Enter(Payload payload)
    {
        _gameHud = Object.Instantiate(_configProvider.GetWindowPrefab<GameHud>()).Construct
        (
            payload.LevelConfig,
            onPause: _gameLoopStateMachine.Enter<GamePauseState>
        );

        _gameLoopStateMachine.SetData(payload.LevelConfig, payload.Player);
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