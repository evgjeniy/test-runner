using UnityEngine;
using UnityEngine.UI;

public class GameHud : Window
{
    [SerializeField] private Button pauseButton;

    public Button Pause => pauseButton;
}