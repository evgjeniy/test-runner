using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class LoseWindow : Window
{
    [SerializeField] private Button restartButton;

    public LoseWindow Construct(UnityAction onRestart)
    {
        restartButton.onClick.AddListener(onRestart);
        return this;
    }
}