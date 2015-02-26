namespace TowerDefenseGame.Interfaces
{
    using System.Windows.Media;

    public interface ITower : IGameObject
    {
        int Speed { get; }

        int Range { get; }

        IEnemy Target { get; }

        int Price { get; }

        int Level { get; }

        int Damage { get; }

        Brush ProfileImage { get; }

        IProjectile FireProjectile();

        void Upgrade();
    }
}
