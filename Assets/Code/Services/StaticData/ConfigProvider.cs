using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class ConfigProvider : IConfigProvider
{
    private const string ConfigsPath = "Levels";
    private const string PlayerConfigPath = "PlayerConfig";
    private readonly Dictionary<int, LevelConfig> _configs;
    private readonly PlayerConfig _playerConfig;

    public ConfigProvider()
    {
        _configs = Resources.LoadAll<LevelConfig>(ConfigsPath).ToDictionary(x => x.ID);
        _playerConfig = Resources.Load<PlayerConfig>(PlayerConfigPath);
    }

    public LevelConfig GetLevelConfig(int id) => _configs.GetValueOrDefault(id);

    public PlayerConfig GetPlayerConfig() => _playerConfig;
}