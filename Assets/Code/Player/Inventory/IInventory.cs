using System;
using System.Collections.Generic;

public interface IInventory
{
    event Action<ColorTaskData> ColorCollected;
    List<ColorTaskData> ColorsData { get; }

    void Enable();
    void Disable();
}