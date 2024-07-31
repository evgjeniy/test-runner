using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class PlayerInventory : IInventory
{
    private readonly IStack _stack;
    private readonly GameLoopStateMachine _gameLoop;
    private readonly Dictionary<ColorTaskConfig, int> _needToCollectColors;
    private readonly Dictionary<ColorTaskConfig, int> _collectedColors;

    public PlayerInventory(LevelConfig config, IStack stack, GameLoopStateMachine gameLoop)
    {
        _stack = stack;
        _gameLoop = gameLoop;
        _needToCollectColors = config.ColorsToComplete.ToDictionary(task => task, task => task.Amount);
        _collectedColors = config.ColorsToComplete.ToDictionary(task => task, _ => 0);
    }

    public void Enable() => _stack.Collected += CollectCubes;
    public void Disable() => _stack.Collected -= CollectCubes;

    private void CollectCubes(ColorTaskConfig task, int amount)
    {
        _collectedColors[task] = Mathf.Clamp(_collectedColors[task] + amount, 0, _needToCollectColors[task]);

        if (_collectedColors.All(pair => pair.Value == _needToCollectColors[pair.Key]))
            _gameLoop.Enter<GameWinState>();
    }
}