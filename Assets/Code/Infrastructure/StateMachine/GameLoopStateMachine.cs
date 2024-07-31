using System;
using System.Collections.Generic;

public class GameLoopStateMachine : StateMachine
{
    public LevelConfig Config { get; private set; }
    public Player Player { get; private set; }

    public GameLoopStateMachine(GameStateMachine gameStateMachine, Services services)
    {
        States = new Dictionary<Type, IExitState>
        {
            [typeof(GamePlayState)] = new GamePlayState
            (
                gameLoop: this,
                inputService: services.Resolve<IInputService>()
            ),
            [typeof(GamePauseState)] = new GamePauseState
            (
                gameLoop: this,
                configProvider: services.Resolve<IConfigProvider>()
            ),
            [typeof(GameLoseState)] = new GameLoseState
            (
                gameLoop: this,
                configProvider: services.Resolve<IConfigProvider>()
            ),
            [typeof(GameWinState)] = new GameWinState
            (
                gameLoop: this,
                configProvider: services.Resolve<IConfigProvider>(),
                saveService: services.Resolve<ISaveService>()
            ),
            [typeof(GameLoopExitState)] = new GameLoopExitState(gameStateMachine)
        };
    }

    public void SetData(LevelConfig config, Player player)
    {
        Config = config;
        Player = player;
    }
}