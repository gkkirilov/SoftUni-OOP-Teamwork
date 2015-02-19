namespace TowerDefenseGame.Interfaces
{
    using System.Collections.Generic;
    using TowerDefenseGame.Geometry;

    public interface IEnemy : IGameObject
    {

        double Speed { get; }
      
        double LifePoints { get; }
        IDebuff Debuff { get; set; }
        bool IsDying { get; }

        void TakeDamage(int damage);
    }
}
