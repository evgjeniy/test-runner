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

    private static IEnumerator LoadScene(string sceneName, Action onLoaded = null)
    {
        if (SceneManager.GetActiveScene().name == sceneName)
        {
            onLoaded?.Invoke();
            yield break;
        }

        var loadSceneAsyncOperation = SceneManager.LoadSceneAsync(sceneName);

        while (!loadSceneAsyncOperation.isDone)
            yield return null;

        onLoaded?.Invoke();
    }

    private static IEnumerator LoadScene(int nextScene, Action onLoaded = null)
    {
        if (SceneManager.GetActiveScene().buildIndex == nextScene)
        {
            onLoaded?.Invoke();
            yield break;
        }

        var loadSceneAsyncOperation = SceneManager.LoadSceneAsync(nextScene);

        while (!loadSceneAsyncOperation.isDone)
            yield return null;

        onLoaded?.Invoke();
    }
}