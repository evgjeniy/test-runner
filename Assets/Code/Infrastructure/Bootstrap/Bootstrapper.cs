using System.Collections;
using UnityEngine;

public class Bootstrapper : MonoBehaviour, ICoroutineRunner
{
    private GameStateMachine _gameStateMachine;

    private void Awake()
    {
        _gameStateMachine = new GameStateMachine(this, Services.All);
        _gameStateMachine.Enter<BootstrapState>();

        DontDestroyOnLoad(this);
    }

    private void Update() => _gameStateMachine.Update();
    private void OnDestroy() => _gameStateMachine.Enter<GameExitState>();
    private void OnApplicationQuit() => _gameStateMachine.Enter<GameExitState>();
}

public interface ICoroutineRunner : IService
{
    Coroutine StartCoroutine(IEnumerator routine);
    void StopCoroutine(Coroutine routine);
}