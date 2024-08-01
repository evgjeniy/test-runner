public interface IConfigProvider : IService
{
    PlayerConfig GetPlayerConfig();
    LevelConfig GetLevelConfig(int index);
    TWindow GetWindowPrefab<TWindow>() where TWindow : Window;
    SpawnerConfig GetSpawnerConfig();
}