using UnityEngine;

public class LoadLevelState : IPayloadState<LevelConfig>
{
    private readonly IGameStateMachine _gameStateMachine;

    public LoadLevelState(IGameStateMachine gameStateMachine)
    {
        _gameStateMachine = gameStateMachine;
    }

    public void Enter(LevelConfig levelConfig)
    {
        Object.FindObjectOfType<Player>(true).Initialize(levelConfig);
    }
}