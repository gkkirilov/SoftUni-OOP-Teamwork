using System;
using System.Collections.Generic;
using TowerDefenseGame.Geometry;

namespace TowerDefenseGame.Interfaces
{
    interface IEnemy
    {
        List<Point> Beacons { get; }
        int Speed { get; }
        int LifePoints { get; }
        bool Update();
        void SetBeacons(List<Point> beacons);
    }
}
