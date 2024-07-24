public interface IConfigProvider : IService
{
    PlayerConfig GetPlayerConfig();
    LevelConfig GetLevelConfig(int id);
}