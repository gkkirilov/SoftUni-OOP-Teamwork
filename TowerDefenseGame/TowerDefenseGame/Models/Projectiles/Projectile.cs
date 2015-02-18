namespace TowerDefenseGame.Models.Projectiles
{
    using System;
    using System.Windows.Media;
    using TowerDefenseGame.Core;
    using TowerDefenseGame.Geometry;
    using TowerDefenseGame.Interfaces;
    using TowerDefenseGame.Models.Enemies;

    public abstract class Projectile : GameObject, IProjectile, IRotateable
    {
        private int speed;
        private IEnemy target;
        private int damage;
        private IDebuff inflictionDebuff;
        private double playerAngle = 0;
        private double lastAngle;
        private double rotationBlendFactor = 0.05;

        protected Projectile(double x, double y, int speed, IEnemy target, Brush fillType, int damage, IDebuff inflictionDebuff)
            : base(x, y, Constants.ProjectileSize, Constants.ProjectileSize, fillType)
        {
            this.Target = target;
            this.Speed = speed;
            this.Damage = damage;
            this.InflictionDebuff = inflictionDebuff;
        }

        public int Damage
        {
            get
            {
                return this.damage;
            }
            private set
            {
                if (value < 0)
                {
                    throw new ArgumentException("The damage of the projectiles cannot be negative");
                }

                this.damage = value;
            }
        }

        public int Speed
        {
            get
            {
                return this.speed;
            }

            private set
            {
                if (value < 0)
                {
                    throw new ArgumentException("The speed cannot be a negative number.");
                }

                this.speed = value;
            }
        }

        public IEnemy Target
        {
            get
            {
                return this.target;
            }

            private set
            {
                if (value == null)
                {
                    throw new ArgumentException("The target of the projectile cannot be null");
                }

                this.target = value;
            }
        }

        public IDebuff InflictionDebuff
        {
            get
            {
                return this.inflictionDebuff;
            }
            private set
            {
                if (value == null)
                {
                    throw new ArgumentNullException("The value cannot be null");
                }

                this.inflictionDebuff = value;
            }
        }

        public override void Update()
        {
            Point.HandleMovement(this.Coordinates, this.Target.Coordinates, this.Speed);

            if (this.Target.IsDying || !this.Target.Exists)
            {
                this.Exists = false;
            }

            if (this.Intersects(this.Target))
            {
                this.Target.TakeDamage(this.Damage);
                this.Target.Debuff = this.InflictionDebuff;
                this.Exists = false;
            }
            CalculateRotationAngle();
            RotateTransform rotateTransform = new RotateTransform(90.0 - (this.playerAngle * 180 / Math.PI), Constants.FieldSegmentSize / 2, Constants.FieldSegmentSize / 2);
            this.Model.RenderTransform = rotateTransform;
        }

        public void CalculateRotationAngle()
        {
            if (this.Target == null)
            {
                return;
            }
            double deltaX = (this.Coordinates.X + Constants.FieldSegmentSize / 2) -
                (this.Target.Coordinates.X + Constants.FieldSegmentSize / 2);

            double deltaY = (this.Coordinates.Y + Constants.FieldSegmentSize / 2) -
                (this.Target.Coordinates.Y + Constants.FieldSegmentSize / 2);

            double angle = Math.Atan2(deltaX, deltaY);

            if (this.lastAngle < -2.0 && angle > 2.0)
            {
                this.playerAngle += Math.PI * 2.0;
            }
            else if (this.lastAngle > 2.0 && angle < -2.0)
            {
                this.playerAngle -= Math.PI * 2.0;
            }
            this.lastAngle = angle;
            this.playerAngle = angle * this.rotationBlendFactor + this.playerAngle * (1 - this.rotationBlendFactor);
        }
    }
}
