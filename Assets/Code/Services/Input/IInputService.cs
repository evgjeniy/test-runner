using System;
using UnityEngine;

public interface IInputService : IService
{
    event Action<Vector2> OnSwipe;
    void HandleSwipe();
}