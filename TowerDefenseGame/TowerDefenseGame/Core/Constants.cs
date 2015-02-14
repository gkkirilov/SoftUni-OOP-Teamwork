using System;
using System.Collections.Generic;
using System.Windows.Shapes;
using TowerDefenseGame.Geometry;
using TowerDefenseGame.Models.Enemies;

namespace TowerDefenseGame.Core
{
    static class Constants
    {
        public const int FieldRows = 12;
        public const int FieldCols = 22;

        // The different size values of the objects in the game
        public const int FieldSegmentSize = 50;
        public const int ProjectileSize = 20;

        public const int EnemyStartCol = 22;
        public const int EnemyStartRow = 10;
        public const int WaveEnemiesMaxCount = 3;

        // The time intervals for the different timers in milliseconds.
        public const int EnemyGenerationDelay = 2000;
        public const int UpdateDelay = 10;
        public const int RenderDelay = 10;
        public const int WaveDelay = 1000;
    }
}
