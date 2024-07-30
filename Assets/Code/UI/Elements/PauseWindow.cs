using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class PauseWindow : Window
{
    [SerializeField] private Button closeButton;
    [SerializeField] private Button continueButton;
    [SerializeField] private Button mainMenuButton;

    public PauseWindow Construct(UnityAction onClose, UnityAction onMainMenu)
    {
        closeButton.onClick.AddListener(onClose);
        continueButton.onClick.AddListener(onClose);
        mainMenuButton.onClick.AddListener(onMainMenu);
        return this;
    }
}