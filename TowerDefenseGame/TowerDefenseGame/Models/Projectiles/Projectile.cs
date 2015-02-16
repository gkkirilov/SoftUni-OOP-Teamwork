namespace TowerDefenseGame.Models.Projectiles
{
    using System;
    using System.Windows.Media;
    using TowerDefenseGame.Core;
    using TowerDefenseGame.Geometry;
    using TowerDefenseGame.Interfaces;
    using TowerDefenseGame.Models.Enemies;

    public abstract class Projectile : GameObject, IProjectile
    {
        private int speed;
        private IEnemy target;
        private int damage;
        private IDebuff inflictionDebuff;

        public Projectile(double x, double y, int speed, IEnemy target, Brush fillType, int damage, IDebuff inflictionDebuff)
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
            if (this.Intersects(this.Target))
            {
                this.Target.TakeDamage(this.Damage);
                this.Exists = false;
            }
        }

        private void InflictDebuff()
        {

        }
    }
}
