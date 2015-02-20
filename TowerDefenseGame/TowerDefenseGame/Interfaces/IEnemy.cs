namespace TowerDefenseGame.Interfaces
{
    using System.Collections.Generic;
using System.Windows.Controls;
using TowerDefenseGame.Geometry;

    public interface IEnemy : IGameObject
    {

        double Speed { get; }
      
        double LifePoints { get; }
        IDebuff Debuff { get; set; }

        ProgressBar HealthBar { get; }

        bool IsDying { get; }

        void TakeDamage(int damage);
    }
}
