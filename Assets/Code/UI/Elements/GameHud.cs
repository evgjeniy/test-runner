using UnityEngine;
using UnityEngine.UI;

public class GameHud : Window
{
    [SerializeField] private Button pauseButton;
    [SerializeField] private Transform colorTasksRoot;
    [SerializeField] private ColorTask colorTaskPrefab;

    public Button Pause => pauseButton;

    public void Construct(LevelConfig config)
    {
        foreach (var colorPurposeData in config.ColorsToComplete)
        {
            var colorTaskInstance = Instantiate(colorTaskPrefab, colorTasksRoot);
            colorTaskInstance.Construct(colorPurposeData);
        }
    }
}