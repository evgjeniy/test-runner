using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Config/Windows", fileName = "Windows")]
public class WindowConfigs : ScriptableObject
{
    [SerializeField] private List<Window> prefabs;

    public List<Window> Prefabs => prefabs;
}