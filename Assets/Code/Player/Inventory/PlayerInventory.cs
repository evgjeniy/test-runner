using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class PlayerInventory : IInventory
{
    private readonly IStack _stack;
    private readonly GameLoopStateMachine _gameLoop;
    private readonly List<ColorTaskData> _colorsData;

    public event Action<ColorTaskData> ColorCollected = _ => {};

    public List<ColorTaskData> ColorsData => _colorsData;

    public PlayerInventory(LevelConfig config, IStack stack, GameLoopStateMachine gameLoop)
    {
        _stack = stack;
        _gameLoop = gameLoop;
        _colorsData = config.ColorsToComplete.Select(task => new ColorTaskData(task)).ToList();
    }

    public void Enable() => _stack.Collected += CollectCubes;
    public void Disable() => _stack.Collected -= CollectCubes;

    private void CollectCubes(ColorTaskConfig taskConfig, int amount)
    {
        var colorData = _colorsData.Find(data => data.Config == taskConfig);

        colorData.Collected = Mathf.Clamp(colorData.Collected + amount, 0, colorData.Config.Amount);
        ColorCollected(colorData);

        if (_colorsData.All(data => data.IsCollected))
            _gameLoop.Enter<GameWinState>();
    }
}