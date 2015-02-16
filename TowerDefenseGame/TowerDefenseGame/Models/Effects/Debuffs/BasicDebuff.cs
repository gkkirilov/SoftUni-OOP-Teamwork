using System;

namespace TowerDefenseGame.Models.Effects.Debuffs
{
    public class BasicDebuff : Debuff
    {
        private const int DebuffDuration = 5;
        private const int DebuffLifePointsEffect = 5;
        private const int DebuffSpeedEffect = 1;

        public BasicDebuff()
            : base(DebuffDuration, DebuffLifePointsEffect, DebuffSpeedEffect)
        {
        }
    }
}
