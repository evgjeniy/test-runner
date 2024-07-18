using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Scriptable/LevelData", fileName = "LevelData")]
public class LevelData : ScriptableObject
{
    [SerializeField] private int maxStackAmount;
    [SerializeField] private ColorPurposeData[] colorsToComplete;

    public int MaxStackAmount => maxStackAmount;
    public IReadOnlyCollection<ColorPurposeData> ColorsToComplete => colorsToComplete;
}

[System.Serializable]
public class ColorPurposeData
{
    [SerializeField] private Material cubeMaterial;
    [SerializeField] private int amount;

    public Material CubeMaterial => cubeMaterial;
    public int Amount => amount;
}