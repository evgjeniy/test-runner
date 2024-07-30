using System;
using System.Collections.Generic;

public class GameLoopStateMachine : StateMachine
{
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
            [typeof(GameWinState)] = new GameWinState(gameLoop: this),
            [typeof(GameLoseState)] = new GameLoseState(gameLoop: this),
            [typeof(GameLoopExitState)] = new GameLoopExitState(gameStateMachine)
        };
    }
}