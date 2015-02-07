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
        public const int EnemyStartCol = 22;
        public const int EnemyStartRow = 10;
        public const int FieldRectangeSize = 50;
        
        public static List<Point> GetEnemyBeacons() 
        {
            List<Point> beacons = new List<Point> 
            { 
                new Point(2 * Constants.FieldRectangeSize, 10 * Constants.FieldRectangeSize),
                new Point(2 * Constants.FieldRectangeSize, 1 * Constants.FieldRectangeSize),
                new Point(7 * Constants.FieldRectangeSize, 1 * Constants.FieldRectangeSize)
            };

            return beacons;
        }
    }
}
