using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class ConfigProvider : IConfigProvider
{
    private readonly List<LevelConfig> _levelConfigs;
    private readonly Dictionary<Type, Window> _windowConfigs;
    private readonly PlayerConfig _playerConfig;

    public ConfigProvider()
    {
        _playerConfig = Resources.Load<PlayerConfig>(Const.Resources.PlayerConfig);
        _levelConfigs = Resources.Load<LevelConfigs>(Const.Resources.LevelConfigs).Configs.ToList();
        _windowConfigs = Resources.Load<WindowConfigs>(Const.Resources.WindowConfigs).Prefabs.ToDictionary(x => x.GetType());
    }

    public PlayerConfig GetPlayerConfig() => _playerConfig;
    public LevelConfig GetLevelConfig(int index) => _levelConfigs[GetSaveIndex(index)];
    public TWindow GetWindowPrefab<TWindow>() where TWindow : Window => _windowConfigs.GetValueOrDefault(typeof(TWindow)) as TWindow;

    private int GetSaveIndex(int index) => index % _levelConfigs.Count;
}