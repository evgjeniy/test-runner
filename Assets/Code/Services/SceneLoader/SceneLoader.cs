using System;
using System.Collections;
using UnityEngine.SceneManagement;

public class SceneLoader : ISceneLoader
{
    private readonly ICoroutineRunner _coroutineRunner;

    public SceneLoader(ICoroutineRunner coroutineRunner)
    {
        _coroutineRunner = coroutineRunner;
    }

    public void Load(int index, Action onLoaded = null)
    {
        _coroutineRunner.StartCoroutine(LoadScene(index, onLoaded));
    }

    public void Load(string name, Action onLoaded = null)
    {
        _coroutineRunner.StartCoroutine(LoadScene(name, onLoaded));
    }

    private static IEnumerator LoadScene(int index, Action onLoaded = null)
    {
        var loadSceneAsyncOperation = SceneManager.LoadSceneAsync(index);

        while (!loadSceneAsyncOperation.isDone)
            yield return null;

        onLoaded?.Invoke();
    }

    private static IEnumerator LoadScene(string name, Action onLoaded = null)
    {
        var loadSceneAsyncOperation = SceneManager.LoadSceneAsync(name);

        while (!loadSceneAsyncOperation.isDone)
            yield return null;

        onLoaded?.Invoke();
    }
}