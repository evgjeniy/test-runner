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
        _gameLoopStateMachine.Player.Stack.Changed += _gameHud.UpdateStackView;
        _gameLoopStateMachine.Player.Inventory.ColorCollected += _gameHud.UpdateColorTaskView;
        
        _gameLoopStateMachine.Enter<GamePlayState>();
    }

    public void Update()
    {
        _gameLoopStateMachine.Update();
    }

    public void Exit()
    {
        _gameLoopStateMachine.Player.Stack.Changed -= _gameHud.UpdateStackView;
        _gameLoopStateMachine.Player.Inventory.ColorCollected -= _gameHud.UpdateColorTaskView;
        
        if (_gameHud != null)
            Object.Destroy(_gameHud.gameObject);
    }
}