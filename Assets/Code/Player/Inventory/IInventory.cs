using System;

public interface IInventory
{
    event Action<ColorTaskConfig, int, int> ColorCollected;

    void Enable();
    void Disable();
}