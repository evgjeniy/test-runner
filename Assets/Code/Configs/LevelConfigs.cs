using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Config/Levels", fileName = "Levels")]
public class LevelConfigs : ScriptableObject
{
    [SerializeField] private List<LevelConfig> configs;

    public List<LevelConfig> Configs => configs;
}

[System.Serializable]
public class LevelConfig
{
    [SerializeField] private int maxStackAmount;
    [SerializeField] private ColorTaskData[] colorsToComplete;

    public int MaxStackAmount => maxStackAmount;
    public IReadOnlyCollection<ColorTaskData> ColorsToComplete => colorsToComplete;
}

[System.Serializable]
public class ColorTaskData
{
    [field: SerializeField] public Color Color { get; private set; }
    [field: SerializeField] public int Amount { get; private set; }
    [field: SerializeField] public int Collect { get; private set; }
}