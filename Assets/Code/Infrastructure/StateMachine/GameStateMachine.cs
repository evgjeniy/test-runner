using System;
using System.Collections.Generic;

public class GameStateMachine : StateMachine
{
    public GameStateMachine(ICoroutineRunner coroutineRunner, Services services)
    {
        States = new Dictionary<Type, IExitState>
        {
            [typeof(BootstrapState)] = new BootstrapState
            (
                this,
                coroutineRunner,
                services
            ),
            [typeof(MainMenuState)] = new MainMenuState
            (
                this,
                configProvider: services.Resolve<IConfigProvider>(),
                inputService: services.Resolve<IInputService>(),
                saveService: services.Resolve<ISaveService>()
            ),
            [typeof(GameLoopState)] = new GameLoopState(this, services),
            [typeof(GameExitState)] = new GameExitState()
        };
    }
}