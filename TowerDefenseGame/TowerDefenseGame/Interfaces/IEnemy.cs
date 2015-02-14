using System;
using System.Collections.Generic;
using TowerDefenseGame.Geometry;

namespace TowerDefenseGame.Interfaces
{
    interface IEnemy
    {
        List<Point> Beacons { get; }
        int EnemySpeed { get; }
        int EnemyLifePoints { get; }
        void SetBeacons(List<Point> beacons);
    }
}
