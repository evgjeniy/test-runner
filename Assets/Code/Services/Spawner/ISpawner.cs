public interface ISpawner : IService
{
    Pattern SpawnNext(Player component);
    void Add(Pattern pattern);
    void Remove(Pattern pattern);
}