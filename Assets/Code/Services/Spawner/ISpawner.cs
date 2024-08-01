public interface ISpawner : IService
{
    Pattern SpawnNext(Pattern current, Player component);
    void Add(Pattern pattern);
    void Remove(Pattern pattern);
}