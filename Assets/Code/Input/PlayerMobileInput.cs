using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMobileInput : MonoBehaviour, IPlayerInput
{
    [SerializeField] private float minimumSwipeMagnitude = 5.0f;

    private PlayerInputActions _playerInput;
    private Vector2 _swipeDirection;

    public event Action<Vector2> OnPlayerMove = _ => { };

    private void Awake() => _playerInput = new PlayerInputActions();

    private void OnEnable()
    {
        _playerInput.Enable();
        _playerInput.Player.Swipe.performed += Swipe;
        _playerInput.Player.Touch.canceled += Touch;
    }

    private void OnDisable()
    {
        _playerInput.Player.Touch.canceled -= Touch;
        _playerInput.Player.Swipe.performed -= Swipe;
        _playerInput.Disable();
    }

    private void Swipe(InputAction.CallbackContext context)
    {
        _swipeDirection = context.ReadValue<Vector2>();
    }

    private void Touch(InputAction.CallbackContext context)
    {
        if (Mathf.Abs(_swipeDirection.magnitude) < minimumSwipeMagnitude) return;

        var moveDirection = Vector2.zero;

        moveDirection.x = _swipeDirection.x switch
        {
            > 0 => 1,
            < 0 => -1,
            _ => 0
        };

        moveDirection.y = _swipeDirection.y switch
        {
            > 0 => 1,
            < 0 => -1,
            _ => 0
        };

        OnPlayerMove(moveDirection);
    }
}