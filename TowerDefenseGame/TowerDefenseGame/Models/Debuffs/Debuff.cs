namespace TowerDefenseGame.Models.Effects.Debuffs
{
    using System;
    using TowerDefenseGame.Interfaces;

    public abstract class Debuff : IDebuff
    {
        private double lifePointsEffect;
        private double speedEffect;

        private int duration;
        private int timeToLive;
        private bool hasElapsed = false;

        protected Debuff(int duration, double lifePointsEffect, double speedEffect)
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

        public int Duration
        {
            get
            {
                return this.duration;
            }
            private set
            {
                if (value < 0)
                {
                    throw new ArgumentException("The duration cannot be a negative value");
                }
                this.duration = value;
            }
        }

        public bool HasElapsed
        {
            get
            {
                return this.hasElapsed;
            }
            private set
            {
                this.hasElapsed = value;
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

        public void Update()
        {
            this.timeToLive--;
            if (this.timeToLive <= 0)
            {
                this.HasElapsed = true;
            }
        }
    }
}
