using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ColorTask : MonoBehaviour
{
    [SerializeField] private Image colorImage;
    [SerializeField] private TMP_Text requiredCubesAmount;
    [SerializeField] private TMP_Text cubesToCollect;

    public ColorTask Construct(ColorTaskData colorTask)
    {
        colorImage.color = colorTask.Color;
        requiredCubesAmount.text = $"{colorTask.Amount}";
        cubesToCollect.text = $"x{colorTask.Collect}";
        return this;
    }
}