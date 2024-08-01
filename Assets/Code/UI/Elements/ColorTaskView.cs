using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ColorTaskView : MonoBehaviour
{
    [SerializeField] private Image colorImage;
    [SerializeField] private Image collectedIcon;
    [SerializeField] private TMP_Text requiredCubesAmount;
    [SerializeField] private TMP_Text cubesToCollect;

    public ColorTaskView Construct(ColorTaskConfig colorTask)
    {
        colorImage.color = colorTask.Color;
        requiredCubesAmount.text = $"{colorTask.Amount}";
        cubesToCollect.text = $"x{colorTask.Collect}";
        return this;
    }

    public void UpdateView(int collected, int required)
    { 
        collectedIcon.gameObject.SetActive(required == collected);
        requiredCubesAmount.gameObject.SetActive(required != collected);
        requiredCubesAmount.text = $"{required - collected}";
    }
}