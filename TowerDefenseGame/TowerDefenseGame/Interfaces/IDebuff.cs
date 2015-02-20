namespace TowerDefenseGame.Interfaces
{
    public interface IDebuff
    {
        double LifePointsEffect { get; }
        double SpeedEffect { get; }
        int Duration { get; }
        bool HasElapsed { get; }
        void Update();
    }
}
