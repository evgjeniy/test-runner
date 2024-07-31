public static class Const
{
    public const int TempLevelIndex = 0;
    
    public static class Scenes
    {
        public static class Boot
        {
            public const string Name = nameof(Boot);
            public const int Index = 0;
        }

        public static class Game
        {
            public const string Name = nameof(Game);
            public const int Index = 1;
        }
    }

    public static class Saves
    {
        public const string Level = nameof(Level);
    }

    public static class Resources
    {
        public const string LevelConfigs = "Levels";
        public const string WindowConfigs = "Windows";
        public const string PlayerConfig = "PlayerConfig";
    }
}