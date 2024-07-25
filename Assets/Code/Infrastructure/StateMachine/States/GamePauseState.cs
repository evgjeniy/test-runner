using UnityEngine;

public class GamePauseState : IState
{
    public void Enter()
    {
        Time.timeScale = 0.0f;
        // Init pause HUD
    }

    public void Exit()
    {
        Time.timeScale = 1.0f;
        // Destroy pause HUD
    }
}