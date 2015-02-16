namespace TowerDefenseGame.Models.Projectiles
{
    using System;
    using System.Windows.Media;
    using TowerDefenseGame.Core;
    using TowerDefenseGame.Geometry;
    using TowerDefenseGame.Models.Enemies;

    public abstract class Projectile : GameObject
    {
        private int speed;
        private Enemy target;
        private int damage;

        public Projectile(double x, double y, int speed, Enemy target, Brush fillType, int damage)
            : base(x, y, Constants.ProjectileSize, Constants.ProjectileSize, fillType)
        {
            this.Target = target;
            this.ProjectileSpeed = speed;
            this.Damage = damage;
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

        public int ProjectileSpeed
        {
            get
            {
                return this.speed;
            }

            private set
            {
                this.speed = value;
            }
        }

        public Enemy Target
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

        public override void Update()
        {
            Point.HandleMovement(this.Coordinates, this.Target.Coordinates, this.ProjectileSpeed);
            if (this.Intersects(this.Target))
            {
                this.Target.InflictDamage(this.Damage);
                this.Exists = false;
            }
        }
    }
}
