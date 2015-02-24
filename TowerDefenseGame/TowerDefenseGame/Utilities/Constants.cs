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
        public const int WaveEnemiesMaxCount = 3;

        // The time intervals for the different timers in milliseconds.   ((20 * 75) * 3) + (50 * 75)
        public const int EnemyGenerationDelay = 1500;
        public const int UpdateDelay = 75;
        public const int WaveDelay = 5000;

        public const int StartingMoney = 500;
        public const int PlayerStartingLife = 10;

        //Towwer information
        public const string ArrowTowerInformation = "Arrow Tower\nTower Damage: 10\nTower Range: 150\nTower Price: 50";
        public const string FireTowerInformation = "Fire Tower\nTower Damage: 30\nTower Range: 225\nTower Price: 125";
        public const string FreezeTowerInformation = "Slow Tower\nTower Damage: 5\nTower Range: 120\nTower Price: 150";
        public const string SniperTowerInformation = "Sniper Tower\nTower Damage: 70\nTower Range: 300\nTower Price: 400";
        //Towwer information
    }
}
