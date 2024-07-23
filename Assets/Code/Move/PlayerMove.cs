using DG.Tweening;
using UnityEngine;

[RequireComponent(typeof(IPlayerInput))]
public class PlayerMove : MonoBehaviour
{
    [SerializeField] private Vector2 horizontalBounds = new(-1.5f, 1.5f);
    [SerializeField] private float speed = 5.0f;

    private IPlayerInput _playerInput;
    private Tween _tween;

    private void Awake() => _playerInput = GetComponent<IPlayerInput>();
    private void OnEnable() => _playerInput.OnSwipe += MovePlayer;
    private void OnDisable() => _playerInput.OnSwipe -= MovePlayer;
    private void Update() => transform.position += new Vector3(0, 0, speed * Time.deltaTime);

    private void MovePlayer(Vector2 direction)
    {
        _tween?.Kill(complete: true);

        var xPosition = transform.position.x + direction.x;
        if (xPosition < horizontalBounds.x || xPosition > horizontalBounds.y) return;

        _tween = transform.DOMoveX(xPosition, 0.5f)
            .OnComplete(() => transform.position = new Vector3(xPosition, 0, transform.position.z))
            .SetEase(Ease.OutExpo)
            .Play();
    }
}