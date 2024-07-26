using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ColorTask : MonoBehaviour
{
    [SerializeField] private Image colorImage;
    [SerializeField] private TMP_Text requiredCubesAmount;
    [SerializeField] private TMP_Text cubesToCollect;

    public void Construct(ColorPurposeData colorPurpose)
    {
        colorImage.color = colorPurpose.Color;
        requiredCubesAmount.text = $"{colorPurpose.Amount}";
        cubesToCollect.text = $"x{colorPurpose.Collect}";
    }
}