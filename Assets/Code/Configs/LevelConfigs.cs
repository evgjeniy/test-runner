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
    [SerializeField] private ColorPurposeData[] colorsToComplete;

    public int MaxStackAmount => maxStackAmount;
    public IReadOnlyCollection<ColorPurposeData> ColorsToComplete => colorsToComplete;
}

[System.Serializable]
public class ColorPurposeData
{
    [field: SerializeField] public Color Color { get; private set; }
    [field: SerializeField] public int Amount { get; private set; }
}