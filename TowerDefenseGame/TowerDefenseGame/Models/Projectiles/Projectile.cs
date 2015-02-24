namespace TowerDefenseGame.Models.Projectiles
{
    using System;
    using System.Windows.Media;
    using Debuffs;
    using Geometry;
    using Interfaces;
    using Utilities;

    public abstract class Projectile : GameObject, IProjectile
    {
        private int speed;
        private IEnemy target;
        private int damage;
        private IDebuff inflictionDebuff;
        private double projectileAngle = 0;
        private double lastAngle;

        protected Projectile(double x, double y, int speed, IEnemy target, Brush fillType, int damage, IDebuff inflictionDebuff)
            : base(x, y, Constants.ProjectileSize, Constants.ProjectileSize, fillType)
        {
            CalculateRotationAngle();
            GeometryUtils.RotateModel(this.Model, this.projectileAngle);
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
            GeometryUtils.HandleMovement(this.Coordinates, this.Target.Coordinates, this.Speed);

            if (this.Target.IsDying || !this.Target.Exists)
            {
                this.Exists = false;
            }

            if (this.Intersects(this.Target))
            {
                this.Target.TakeDamage(this.Damage);
                if (this.Target.Debuff is NullDebuff)
                {
                    this.Target.Debuff = this.InflictionDebuff;
                }
                this.Exists = false;
            }

            CalculateRotationAngle();
            GeometryUtils.RotateModel(this.Model, this.projectileAngle);
        }

        private void CalculateRotationAngle()
        {
            if (this.Target == null)
            {
                return;
            }
            double deltaX = (this.Coordinates.X + (double)Constants.FieldSegmentSize / 2) -
                (this.Target.Coordinates.X + (double)Constants.FieldSegmentSize / 2);

            double deltaY = (this.Coordinates.Y + (double)Constants.FieldSegmentSize / 2) -
                (this.Target.Coordinates.Y + (double)Constants.FieldSegmentSize / 2);

            double angle = Math.Atan2(deltaX, deltaY);

            if (this.lastAngle < -2.0 && angle > 2.0)
            {
                this.projectileAngle += Math.PI * 2.0;
            }
            else if (this.lastAngle > 2.0 && angle < -2.0)
            {
                this.projectileAngle -= Math.PI * 2.0;
            }
            this.lastAngle = angle;
            this.projectileAngle = angle;
        }
    }
}
