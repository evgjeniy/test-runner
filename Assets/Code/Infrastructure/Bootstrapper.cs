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
}

public interface ICoroutineRunner : IService
{
    Coroutine StartCoroutine(IEnumerator routine);
    void StopCoroutine(Coroutine routine);
}