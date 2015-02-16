namespace TowerDefenseGame.Interfaces
{
    public interface IEffect
    {
        int Duration { get; }
        bool HasElapsed { get; }
        void Update();
    }
}
