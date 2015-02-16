namespace TowerDefenseGame.Models.Effects
{
    using System;
    using TowerDefenseGame.Interfaces;

    public abstract class Effect : IEffect
    {
        private int duration;
        private int timeToLive;
        private bool hasElapsed = false;

        public Effect(int duration)
        {
            this.Duration = duration;
            this.timeToLive = this.Duration;
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
