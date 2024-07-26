using UnityEngine;
using UnityEngine.UI;

public class PauseWindow : Window
{
    [SerializeField] private Button closeButton;
    [SerializeField] private Button continueButton;
    [SerializeField] private Button mainMenuButton;

    public Button Close => closeButton;
    public Button Continue => continueButton;
    public Button MainMenu => mainMenuButton;
}