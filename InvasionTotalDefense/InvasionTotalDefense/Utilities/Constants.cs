namespace TowerDefenseGame.Utilities
{
    public static class Constants
    {
        public const int FieldRows = 20;
        public const int FieldCols = 30;

        // The different size values of the objects in the game
        public const int FieldSegmentSize = 30;
        public const int ProjectileSize = 20;

        public const int EnemyStartCol = 29;
        public const int EnemyStartRow = 16;
        public const int WaveEnemiesMaxCount = 10;

        // The time intervals for the different timers in milliseconds.
        public const int EnemyGenerationDelay = 3000;
        public const int UpdateDelay = 75;
        public const int WaveDelay = 15000;

        public const int StartingMoney = 450;
        public const int PlayerStartingLife = 10;

        // Tower information
        public const string ArrowTowerInformation = "Arrow Tower\nTower Damage: 5\nTower Range: 100\nTower Speed: Fast\nTower Price: 50";
        public const string FireTowerInformation = "Fire Tower\nTower Damage: 20\nTower Range: 150\nTower Speed: Regular\nTower Price: 125";
        public const string FreezeTowerInformation = "Freeze Tower\nTower Damage: 15\nTower Range: 150\nTower Speed: Regular\nTower Price: 125";
        public const string SniperTowerInformation = "Sniper Tower\nTower Damage: 70\nTower Range: 350\nTower Speed: Slow\nTower Price: 300";
    }
}
