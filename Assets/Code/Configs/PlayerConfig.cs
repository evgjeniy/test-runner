using UnityEngine;

[CreateAssetMenu(menuName = "Config/" + nameof(PlayerConfig), fileName = nameof(PlayerConfig))]
public class PlayerConfig : ScriptableObject
{
    [SerializeField] private Player playerPrefab;

    [Header("Input")]
    [SerializeField, Range(0, 1)] private float swipeThresholdScreenPercent = 0.3f;

    [Header("Movement")]
    [SerializeField] private Vector2 horizontalBounds = new(-1.5f, 1.5f);
    [SerializeField] private float speed = 5.0f;

    public Player Prefab => playerPrefab;
    public float SwipeThresholdScreenPercent => swipeThresholdScreenPercent;
    public Vector2 HorizontalBounds => horizontalBounds;
    public float Speed => speed;
}