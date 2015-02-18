namespace TowerDefenseGame.Models.Effects.Debuffs
{
    public class BasicDebuff : Debuff
    {
        private const int DebuffDuration = 200;
        private const double DebuffLifePointsEffect = 0;
        private const double DebuffSpeedEffect = 0.75;

        public BasicDebuff()
            : base(DebuffDuration, DebuffLifePointsEffect, DebuffSpeedEffect)
        {
        }
    }
}
