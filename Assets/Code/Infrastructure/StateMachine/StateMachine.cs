using System;
using System.Collections.Generic;

public abstract class StateMachine : IStateMachine
{
    protected Dictionary<Type, IExitState> States;
    private IExitState _activeState;

    public void Enter<TState>() where TState : class, IState
    {
        ChangeState<TState>().Enter();
    }

    public void Enter<TState, TPayload>(TPayload payload) where TState : class, IPayloadState<TPayload>
    {
        ChangeState<TState>().Enter(payload);
    }

    public void Update() => _activeState.Update();

    private TState ChangeState<TState>() where TState : class, IExitState
    {
        var state = States[typeof(TState)] as TState;

        _activeState?.Exit();
        _activeState = state;

        return state;
    }
}