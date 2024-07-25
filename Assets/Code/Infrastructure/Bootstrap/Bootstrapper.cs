using System.Collections;
using UnityEngine;

public class Bootstrapper : MonoBehaviour, ICoroutineRunner
{
    private GameStateMachine _gameStateMachine;

    private void Awake()
    {
        _gameStateMachine = new GameStateMachine(Services.All, this);
        _gameStateMachine.Enter<BootstrapState>();

        DontDestroyOnLoad(this);
    }

    private void Update() => _gameStateMachine.Update();
    private void OnDestroy() => _gameStateMachine.Enter<CleanupState>();
    private void OnApplicationQuit() => _gameStateMachine.Enter<CleanupState>();
}

public interface ICoroutineRunner : IService
{
    Coroutine StartCoroutine(IEnumerator routine);
    void StopCoroutine(Coroutine routine);
}