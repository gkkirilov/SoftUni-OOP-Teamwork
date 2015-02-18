namespace TowerDefenseGame.Models.Effects.Debuffs
{
    using System;
    using TowerDefenseGame.Interfaces;

    public abstract class Debuff : Effect, IDebuff
    {
        private double lifePointsEffect;
        private double speedEffect;

        protected Debuff(int duration, double lifePointsEffect, double speedEffect)
            : base(duration)
        {
            this.LifePointsEffect = lifePointsEffect;
            this.SpeedEffect = speedEffect;
        }

        public double LifePointsEffect
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

        public double SpeedEffect
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
