using UnityEngine;

public class GamePlayState : IState
{
    private readonly GameLoopState _gameLoop;
    private readonly IInputService _inputService;
    private GameHud _gameHud;

    public GamePlayState(GameLoopState gameLoop, IInputService inputService)
    {
        _gameLoop = gameLoop;
        _inputService = inputService;
    }

    public void Update()
    {
        _inputService.HandleSwipe();
    }
}