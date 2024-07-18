using DG.Tweening;
using DG.Tweening.Core;
using DG.Tweening.Plugins.Options;
using UnityEngine;
using Zenject;

public class PlayerMove : MonoBehaviour
{
    [SerializeField] private Vector2 horizontalBounds = new(-1.5f, 1.5f);
    [SerializeField] private float speed = 5.0f;
    [Inject] private IPlayerInput _playerInput;

    private TweenerCore<Vector3, Vector3, VectorOptions> _tween;

    private void OnEnable() => _playerInput.OnPlayerMove += MovePlayer;
    private void OnDisable() => _playerInput.OnPlayerMove -= MovePlayer;
    private void Update() => transform.position += new Vector3(0, 0, speed * Time.deltaTime);

    private void MovePlayer(Vector2 moveDirection)
    {
        _tween?.Kill(complete: true);

        var newPositionX = transform.position.x + moveDirection.x;
        if (newPositionX < horizontalBounds.x || newPositionX > horizontalBounds.y) return;

        _tween = transform.DOMoveX(newPositionX, 0.5f)
            .OnComplete(() => transform.position = new Vector3(newPositionX, 0, transform.position.z))
            .SetEase(Ease.OutBack)
            .Play();
    }
}