namespace TowerDefenseGame.Models.Enemies
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Windows.Media;
    using System.Windows.Media.Imaging;
    using System.Windows.Shapes;
    using TowerDefenseGame.Geometry;
    using TowerDefenseGame.Interfaces;
using TowerDefenseGame.Models.Effects.Debuffs;

    public abstract class Enemy : GameObject, IEnemy
    {
        private double speed;
        private double lifePoints;
        private List<Point> beacons = new List<Point>();
        private IDebuff debuff = new NullDebuff();

        protected Enemy(double x, double y, int width, int height, double lifePoints, double speed, Brush fillType)
            : base(x, y, width, height, fillType)
        {
            this.LifePoints = lifePoints;
            this.Speed = speed;
        }

        public List<Point> Beacons
        {
            get
            {
                return this.beacons;
            }

            private set
            {
                this.beacons = value;
            }
        }

        public double Speed
        {
            get
            {
                return this.speed;
            }

            private set
            {
                if (value < 0)
                {
                    throw new ArgumentException("The speed cannot be a negative number");
                }

                this.speed = value;
            }
        }

        public double LifePoints
        {
            get
            {
                return this.lifePoints;
            }

            private set
            {
                this.lifePoints = value;
            }
        }

        public IDebuff Debuff 
        {
            get
            {
                return this.debuff;
            }
            set
            {
                if (value == null)
                {
                    throw new ArgumentNullException("The value cannot be null");
                }
                this.debuff = value;
            }
        }

        public override void Update()
        {
            this.Debuff.Update();
            if (this.Debuff.HasElapsed)
            {
                this.Debuff = new NullDebuff();
            }

            this.LifePoints -= this.Debuff.LifePointsEffect;

            if (this.Beacons.Count == 0)
            {
                this.Exists = false;
                return;
            }
            else if (this.LifePoints <= 0) 
            {
                this.Exists = false;
            }

            Point.HandleMovement(this.Coordinates, this.Beacons[0], this.Speed - this.Debuff.SpeedEffect);

            if (this.Beacons[0].IsInside(this))
            {
                this.Beacons.RemoveAt(0);
                this.Update();
            }  
        }

        public void SetBeacons(List<Point> beacons)
        {
            this.Beacons = beacons;
        }

        public void TakeDamage(int damage)
        {
            this.LifePoints -= damage;
        }
    }
}
