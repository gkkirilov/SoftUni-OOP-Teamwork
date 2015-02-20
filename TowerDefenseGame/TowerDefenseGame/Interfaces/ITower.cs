namespace TowerDefenseGame.Interfaces
{
    public interface ITower : IGameObject
    {
        int Speed { get; }
        int Range { get; }
        IEnemy Target { get; }
        int Price { get; }
        int Level { get; }
        int Damage { get; }
        void Upgrade();
    }
}
