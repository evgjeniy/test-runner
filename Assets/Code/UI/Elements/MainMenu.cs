using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class MainMenu : Window
{
    [SerializeField] private Button startGameButton;
    [SerializeField] private TMP_Text levelText;

    public Button StartGameButton => startGameButton;
    public void SetLevelText(int levelNumber) => levelText.text = $"Level {levelNumber}";
}