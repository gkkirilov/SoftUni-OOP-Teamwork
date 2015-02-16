namespace TowerDefenseGame.Interfaces
{
    public interface IDebuff : IEffect
    {
        double LifePointsEffect { get; }
        double SpeedEffect { get; }
    }
}
