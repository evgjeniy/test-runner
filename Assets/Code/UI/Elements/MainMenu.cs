using UnityEngine;
using UnityEngine.UI;

public class MainMenu : Window
{
    [SerializeField] private Button startGameButton;

    public Button StartGameButton => startGameButton;
}