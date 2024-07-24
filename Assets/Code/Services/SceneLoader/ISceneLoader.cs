using System;

public interface ISceneLoader : IService
{
    void Load(int index, Action onLoaded = null);
    void Load(string name, Action onLoaded = null);
}