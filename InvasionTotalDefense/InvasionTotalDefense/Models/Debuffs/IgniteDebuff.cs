namespace TowerDefenseGame.Models.Debuffs
{
    public class IgniteDebuff : Debuff
    {
        private const int DebuffDuration = 10;
        private const double DebuffSpeedEffect = 0;

        public IgniteDebuff(int lifePointsEffect)
            : base(DebuffDuration, lifePointsEffect, DebuffSpeedEffect)
        {
        }
    }
}
