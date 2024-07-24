using DG.Tweening;
using UnityEngine;

public class PlayerMovement : IMovement
{
    private readonly IInputService _input;
    private readonly PlayerConfig _config;
    private readonly Transform _transform;
    private Tween _tween;

    public PlayerMovement(IInputService input, PlayerConfig config, Transform playerTransform)
    {
        _input = input;
        _config = config;
        _transform = playerTransform;
    }

    public void Enable() => _input.OnSwipe += Move;
    public void Disable() => _input.OnSwipe -= Move;
    public void MoveForward() => _transform.position += new Vector3(0, 0, _config.Speed * Time.deltaTime);

    private void Move(Vector2 direction)
    {
        _tween?.Kill(complete: true);

        var xPosition = _transform.position.x + direction.x;
        if (xPosition < _config.HorizontalBounds.x || xPosition > _config.HorizontalBounds.y) return;

        _tween = _transform.DOMoveX(xPosition, 0.5f)
            .OnComplete(() => _transform.position = new Vector3(xPosition, 0, _transform.position.z))
            .SetEase(Ease.OutExpo)
            .Play();
    }
}