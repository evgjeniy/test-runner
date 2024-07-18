using System;
using UnityEngine;

public interface IPlayerInput
{
    public event Action<Vector2> OnPlayerMove;
}