using System;
using UnityEngine;

public class StandaloneInputService : IInputService
{
    public event Action<Vector2> OnSwipe = _ => {};
    
    public void HandleSwipe()
    {
        var horizontal = Input.GetKeyDown(KeyCode.LeftArrow) ? -1 : Input.GetKeyDown(KeyCode.RightArrow) ? 1 : 0;
        var vertical = Input.GetKeyDown(KeyCode.DownArrow) ? -1 : Input.GetKeyDown(KeyCode.UpArrow) ? 1 : 0;
        var swipeDirection = new Vector2(horizontal, vertical);
        
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