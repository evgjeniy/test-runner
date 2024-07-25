public interface IConfigProvider : IService
{
    PlayerConfig GetPlayerConfig();
    LevelConfig GetLevelConfig(int index);
    WindowConfig GetWindowConfig(WindowType type);
}