using System;
using UnityEngine;
using UnityEngine.InputSystem;
using Zenject;

public class PlayerMobileInput : IPlayerInput, IInitializable, IDisposable
{
    private readonly PlayerInputActions _playerInput = new();
    private readonly float _minSwipeMagnitude;

    private Vector2 _swipeDirection;

    public event Action<Vector2> OnPlayerMove = _ => { };

    public PlayerMobileInput(float minSwipeMagnitude) => _minSwipeMagnitude = minSwipeMagnitude;

    public void Initialize()
    {
        _playerInput.Enable();
        _playerInput.Player.Swipe.performed += Swipe;
        _playerInput.Player.Touch.canceled += Touch;
    }

    public void Dispose()
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
        if (Mathf.Abs(_swipeDirection.magnitude) < _minSwipeMagnitude) return;

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