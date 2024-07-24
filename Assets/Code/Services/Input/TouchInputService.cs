using System;
using UnityEngine;

public class TouchInputService : IInputService
{
    private readonly PlayerConfig _config;
    private Vector2 _swipeDirection;
    private Vector2 _startTouchPosition;
    private Vector2 _endTouchPosition;

    public event Action<Vector2> OnSwipe = _ => { };

    public TouchInputService(IConfigProvider configProvider)
    {
        _config = configProvider.GetPlayerConfig();
    }

    public void HandleSwipe()
    {
        if (Input.touchCount <= 0) return;
        var touch = Input.GetTouch(0);

        if (touch.phase == TouchPhase.Began)
        {
            _startTouchPosition = touch.position;
        }
        else if (touch.phase == TouchPhase.Ended)
        {
            _endTouchPosition = touch.position;

            var swipeDirection = _endTouchPosition - _startTouchPosition;
            var threshold = _config.SwipeThresholdScreenPercent * Screen.currentResolution.width;
            
            if (swipeDirection.magnitude < threshold) return;
            if (Mathf.Abs(swipeDirection.x) > Mathf.Abs(swipeDirection.y))
            {
                swipeDirection.x = swipeDirection.x switch
                {
                    > 0 => 1,
                    < 0 => -1,
                    _ => 0
                };
            }
            else
            {
                swipeDirection.y = swipeDirection.y switch
                {
                    > 0 => 1,
                    < 0 => -1,
                    _ => 0
                };
            }

            OnSwipe(swipeDirection);
        }
    }
}