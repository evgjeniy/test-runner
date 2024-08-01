using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Config/" + nameof(LevelConfigs), fileName = nameof(LevelConfigs))]
public class LevelConfigs : ScriptableObject
{
    [SerializeField] private List<LevelConfig> configs;

    public List<LevelConfig> Configs => configs;
}

[System.Serializable]
public class LevelConfig
{
    [SerializeField] private int maxStackAmount;
    [SerializeField] private ColorTaskConfig[] colorsToComplete;

    public int MaxStackAmount => maxStackAmount;
    public IReadOnlyCollection<ColorTaskConfig> ColorsToComplete => colorsToComplete;
}

[System.Serializable]
public class ColorTaskConfig
{
    [field: SerializeField] public Color Color { get; private set; }
    [field: SerializeField] public int Amount { get; private set; }
    [field: SerializeField] public int Collect { get; private set; }
}

public class ColorTaskData // Model
{
    public ColorTaskConfig Config { get; private set; }
    public int Collected { get; set; }
    public int Required => Config.Amount;
    public bool IsCollected => Collected == Config.Amount;

    public ColorTaskData(ColorTaskConfig colorTask) => Config = colorTask;
}