namespace TowerDefenseGame.Core
{
    public static class Constants
    {
        public const int FieldRows = 20;
        public const int FieldCols = 30;

        // The different size values of the objects in the game
        public const int FieldSegmentSize = 30;
        public const int ProjectileSize = 20;

        public const int EnemyStartCol = 22;
        public const int EnemyStartRow = 10;
        public const int WaveEnemiesMaxCount = 3;

        // The time intervals for the different timers in milliseconds.
        public const int EnemyGenerationDelay = 20;
        public const int UpdateDelay = 75;
        public const int WaveDelay = 50;
    }
}
