using System;
using System.Collections.Generic;

public class GameLoopStateMachine : StateMachine
{
    public GameLoopStateMachine(GameLoopState gameLoop, GameStateMachine gameStateMachine, Services services)
    {
        States = new Dictionary<Type, IExitState>
        {
            [typeof(GamePlayState)] = new GamePlayState
            (
                gameLoop: gameLoop,
                inputService: services.Resolve<IInputService>()
            ),
            [typeof(GamePauseState)] = new GamePauseState
            (
                gameLoop: gameLoop,
                configProvider: services.Resolve<IConfigProvider>()
            ),
            [typeof(GameWinState)] = new GameWinState
            (
                gameLoop: gameLoop
            ),
            [typeof(GameLoseState)] = new GameLoseState
            (
                gameLoop: gameLoop
            ),
            [typeof(GameLoopExitState)] = new GameLoopExitState(gameStateMachine)
        };
    }
}