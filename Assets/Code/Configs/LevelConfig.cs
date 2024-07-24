using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Config/LevelData", fileName = "LevelData")]
public class LevelConfig : ScriptableObject
{
    [SerializeField] private int id;
    [SerializeField] private int maxStackAmount;
    [SerializeField] private ColorPurposeData[] colorsToComplete;

    public int ID => id;
    public int MaxStackAmount => maxStackAmount;
    public IReadOnlyCollection<ColorPurposeData> ColorsToComplete => colorsToComplete;

    public override string ToString() => $"{base.ToString()}, {nameof(id)}: {id}, {nameof(maxStackAmount)}: {maxStackAmount}, {nameof(colorsToComplete)}: {colorsToComplete}";
}

[System.Serializable]
public class ColorPurposeData
{
    [field: SerializeField] public Color Color { get; private set; }
    [field: SerializeField] public int Amount { get; private set; }
}