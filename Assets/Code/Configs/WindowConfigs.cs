using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Config/" + nameof(WindowConfigs), fileName = nameof(WindowConfigs))]
public class WindowConfigs : ScriptableObject
{
    [SerializeField] private List<Window> prefabs;

    public List<Window> Prefabs => prefabs;
}