using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Config/Windows", fileName = "Windows")]
public class WindowConfigs : ScriptableObject
{
    [SerializeField] private List<WindowConfig> configs;

    public List<WindowConfig> Configs => configs;
}

[System.Serializable]
public class WindowConfig
{
    [SerializeField] private WindowType windowType;
    [SerializeField] private Window prefab;

    public WindowType WindowType => windowType;
    public Window Prefab => prefab;
}

public enum WindowType { None, MainMenu, GameHud }