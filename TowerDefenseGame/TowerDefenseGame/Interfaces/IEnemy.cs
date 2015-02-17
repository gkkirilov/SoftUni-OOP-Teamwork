namespace TowerDefenseGame.Interfaces
{
    using System.Collections.Generic;
    using TowerDefenseGame.Geometry;

    public interface IEnemy : IGameObject
    {
        List<Point> Beacons { get; }

        double Speed { get; }
      
        double LifePoints { get; }
        IDebuff Debuff { get; set; }
        bool IsDying { get; }

        void SetBeacons(List<Point> beacons);
        void TakeDamage(int damage);
    }
}
