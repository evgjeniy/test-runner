using System;
using UnityEngine;

public class StandaloneInputService : IInputService
{
    public event Action<Vector2> OnSwipe = _ => {};
    
    public void HandleSwipe()
    {
        var swipeDirection = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
        
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