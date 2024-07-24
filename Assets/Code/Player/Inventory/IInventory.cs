public interface IInventory
{
    int Amount { get; }
    void Collect(Cube cube);
    void DestroyLast();
}