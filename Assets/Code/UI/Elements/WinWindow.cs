using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class WinWindow : Window
{
    [SerializeField] private Button continueButton;

    public WinWindow Construct(UnityAction onContinue)
    {
        continueButton.onClick.AddListener(onContinue);
        return this;
    }
}