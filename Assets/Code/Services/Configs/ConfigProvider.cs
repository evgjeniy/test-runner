using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class ConfigProvider : IConfigProvider
{
    private const string LevelConfigsPath = "Levels";
    private const string WindowConfigsPath = "Windows";
    private const string PlayerConfigPath = "PlayerConfig";
    private readonly List<LevelConfig> _levelConfigs;
    private readonly Dictionary<WindowType, WindowConfig> _windowConfigs;
    private readonly PlayerConfig _playerConfig;

    public ConfigProvider()
    {
        _playerConfig = Resources.Load<PlayerConfig>(PlayerConfigPath);
        _levelConfigs = Resources.Load<LevelConfigs>(LevelConfigsPath).Configs.ToList();
        _windowConfigs = Resources.Load<WindowConfigs>(WindowConfigsPath).Configs.ToDictionary(x => x.WindowType);
    }

    public PlayerConfig GetPlayerConfig() => _playerConfig;
    public LevelConfig GetLevelConfig(int index) => _levelConfigs[index];
    public WindowConfig GetWindowConfig(WindowType type) => _windowConfigs.GetValueOrDefault(type);
}