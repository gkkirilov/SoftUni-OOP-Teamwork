namespace TowerDefenseGame.Models.Effects.Debuffs
{
    using System;
    using TowerDefenseGame.Interfaces;

    public abstract class Debuff : Effect, IDebuff
    {
        private int lifePointsEffect;
        private int speedEffect;

        public Debuff(int duration, int lifePointsEffect, int speedEffect)
            : base(duration)
        {
            this.LifePointsEffect = lifePointsEffect;
            this.SpeedEffect = speedEffect;
        }

        public int LifePointsEffect
        {
            get
            {
                return this.lifePointsEffect;
            }
            private set
            {
                if (value < 0)
                {
                    throw new ArgumentException("The value cannot be negative");
                }
                this.lifePointsEffect = value;
            }
        }

        public int SpeedEffect
        {
            get
            {
                return this.speedEffect;
            }
            private set
            {
                if (value < 0)
                {
                    throw new ArgumentException("The value cannot be negative");
                }
                this.speedEffect = value;
            }
        }
    }
}
