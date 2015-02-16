namespace TowerDefenseGame.Interfaces
{
    public interface IDebuff : IEffect
    {
        int LifePointsEffect { get; }
        int SpeedEffect { get; }
    }
}
