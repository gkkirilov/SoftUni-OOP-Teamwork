using TowerDefenseGame.Models.Enemies;
namespace TowerDefenseGame.Interfaces
{
    public interface IProjectile
    {
        int Damage { get; }
        int Speed { get; }
        Enemy Target { get; }
    }
}
