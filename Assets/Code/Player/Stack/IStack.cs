using System.Collections.Generic;

public interface IStack : IObservable<IStack>
{
    event System.Action<ColorTaskData, int> Collected;
    
    IStack IObservable<IStack>.Value => this;
    
    public IReadOnlyList<Cube> Cubes { get; }
    void Collect(Cube cube);
    void DestroyLast();
}