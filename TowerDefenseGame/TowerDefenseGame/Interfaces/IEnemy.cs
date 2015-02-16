namespace TowerDefenseGame.Interfaces
{
    using System.Collections.Generic;
    using TowerDefenseGame.Geometry;

    public interface IEnemy
    {
        List<Point> Beacons { get; }

        int EnemySpeed { get; }

        int EnemyLifePoints { get; }
        
        void SetBeacons(List<Point> beacons);
    }
}
