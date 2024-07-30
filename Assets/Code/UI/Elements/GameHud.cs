using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class GameHud : Window
{
    [SerializeField] private Button pauseButton;

    [Header("Color Tasks")]
    [SerializeField] private Transform colorTasksRoot;
    [SerializeField] private ColorTask colorTaskPrefab;

    [Header("Stack")]
    [SerializeField] private Slider stackSlider;
    [SerializeField] private TMP_Text maxAmountText;
    [SerializeField] private TMP_Text currentAmountText;
    [SerializeField] private VerticalLayoutGroup stackCubesRoot;
    [SerializeField] private GameObject linePrefab;

    public GameHud Construct(LevelConfig config, UnityAction onPause)
    {
        foreach (var colorPurposeData in config.ColorsToComplete)
            Instantiate(colorTaskPrefab, colorTasksRoot).Construct(colorPurposeData);

        CreateStackSlider(config);
        pauseButton.onClick.AddListener(onPause);
        return this;
    }

    public void OnSliderValueChanged(float value) => currentAmountText.text = $"{value}";

    private void CreateStackSlider(LevelConfig config)
    {
        stackSlider.maxValue = config.MaxStackAmount;
        stackSlider.value = 0.0f;

        if (stackSlider.transform is RectTransform sliderRect)
            sliderRect.sizeDelta = new Vector2(sliderRect.sizeDelta.x, config.MaxStackAmount * 100);

        var padding = config.MaxStackAmount * 50 / config.MaxStackAmount;
        stackCubesRoot.padding.top = stackCubesRoot.padding.bottom = padding;

        for (var i = 1; i < config.MaxStackAmount; i++)
            Instantiate(linePrefab, stackCubesRoot.transform);

        maxAmountText.text = $"MAX\n{config.MaxStackAmount}";
    }
}