using System;
using System.Collections.Generic;

public class GameStateMachine : IGameStateMachine
{
    private readonly Dictionary<Type, IExitState> _states;
    private IExitState _activeState;

    public GameStateMachine(Services services, ICoroutineRunner coroutineRunner)
    {
        _states = new Dictionary<Type, IExitState>
        {
            [typeof(BootstrapState)] = new BootstrapState(this, coroutineRunner, services),
            [typeof(LoadLevelState)] = new LoadLevelState(this),
        };
    }

    public void Enter<TState>() where TState : class, IState
    {
        ChangeState<TState>().Enter();
    }

    public void Enter<TState, TPayload>(TPayload payload) where TState : class, IPayloadState<TPayload>
    {
        ChangeState<TState>().Enter(payload);
    }

    private TState ChangeState<TState>() where TState : class, IExitState
    {
        var state = _states[typeof(TState)] as TState;

        _activeState?.Exit();
        _activeState = state;

        return state;
    }
}