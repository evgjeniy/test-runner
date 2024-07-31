using System.Collections.Generic;

public interface IInventory
{
    public IReadOnlyList<Cube> Cubes { get; }
    void Collect(Cube cube);
    void DestroyLast();
}