using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class MainMenu : Window
{
    [SerializeField] private Button startGameButton;
    [SerializeField] private TMP_Text levelText;

    public MainMenu Construct(int currentLevel, UnityAction onStart)
    {
        levelText.text = $"Level {currentLevel}";
        startGameButton.onClick.AddListener(onStart);
        return this;
    }
}