namespace TowerDefenseGame.Models.Towers
{
    using System;
    using System.Linq;
    using System.Windows.Media;
    using Geometry;
    using Enumerations;
    using Controllers;
    using Projectiles;
    using Interfaces;
    using Utilities;

    public abstract class Tower : GameObject, ITower
    {
        private int towerSpeed;
        private int towerRange;
        private int damage;
        private int level = 1;
        protected int levelBonus = 0;
        private IEnemy target;
        private int price;
        private readonly ProjectileSelection projectileType;

        private int frameCount = 0;

        // Variables used for the calculation of the tower rotation
        private double towerAngle = 0;
        private double lastAngle;
        private const double RotationBlendFactor = 0.2f;

        protected Tower(
            double x,
            double y,
            int width,
            int height,
            int towerSpeed,
            int towerRange,
            int damage,
            Brush fillBrush,
            Brush profileImageBrush,
            int price,
            ProjectileSelection projectileType)
                : base(x, y, width, height, fillBrush)
        {
            this.Speed = towerSpeed;
            this.Range = towerRange;
            this.Price = price;
            this.Damage = damage;
            this.projectileType = projectileType;
            this.ProfileImage = profileImageBrush;
        }

        public int Price
        {
            get
            {
                return this.price;
            }

            private set
            {
                if (value <= 0)
                {
                    throw new ArgumentException("Price cannot be negative or zero");
                }
                this.price = value;
            }
        }
        public int Speed
        {
            get
            {
                return this.towerSpeed;
            }

            private set
            {
                this.towerSpeed = value;
            }
        }

        public int Range
        {
            get
            {
                return this.towerRange;
            }

            private set
            {
                this.towerRange = value;
            }
        }

        public int Damage
        {
            get
            {
                return this.damage + this.levelBonus;
            }

            private set
            {
                if (value < 0)
                {
                    throw new ArgumentOutOfRangeException("The damage of the tower cannot be negative");
                }

                this.damage = value;
            }
        }

        public int Level
        {
            get
            {
                return this.level;
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
                this.target = value;
            }
        }

        public Brush ProfileImage
        {
            get;
            private set;
        }

        public override void Update()
        {
            if (this.Target == null ||
                !this.Target.Exists ||
                this.Target.IsDying ||
                GeometryUtils.CalculateDistance(this.Coordinates, this.Target.Coordinates) > this.Range)
            {
                this.GetTarget();
            }

            CalculateRotationAngle();
            GeometryUtils.RotateModel(this.Model, this.towerAngle);

            FireProjectile();
        }

        public void Upgrade()
        {
            this.level++;
            this.Price += this.Price / 2;
            this.SetLevelBonus();
        }

        private void FireProjectile()
        {
            if (this.Target != null && this.Target.Exists && this.frameCount >= this.Speed)
            {
                this.frameCount = 0;

                if (Math.Abs(this.lastAngle - this.towerAngle) < 1)
                {
                    switch (this.projectileType)
                    {
                        case ProjectileSelection.ArrowProjectile:
                            ProjectileController.Projectiles.Add(
                                new ArrowProjectile(
                                    this.Coordinates.X,
                                    this.Coordinates.Y,
                                    this.Target,
                                    this.Damage));
                            break;
                        case ProjectileSelection.FireProjectile:
                            ProjectileController.Projectiles.Add(
                                new FireProjectile(
                                    this.Coordinates.X,
                                    this.Coordinates.Y,
                                    this.Target,
                                    this.Damage));
                            break;
                        case ProjectileSelection.FreezeProjectile:
                            ProjectileController.Projectiles.Add(
                                new FreezeProjectile(
                                    this.Coordinates.X,
                                    this.Coordinates.Y,
                                    this.Target,
                                    this.Damage));
                            break;
                        case ProjectileSelection.SniperProjectile:
                            ProjectileController.Projectiles.Add(
                                new SniperProjectile(
                                    this.Coordinates.X,
                                    this.Coordinates.Y,
                                    this.Target,
                                    this.Damage));
                            break;
                    }
                }
            }
            else
            {
                this.frameCount++;
            }
        }

        private void GetTarget()
        {
            if (EnemyController.Enemies.Count == 0)
            {
                return;
            }

            var targetSelected = EnemyController.Enemies
                .OrderBy(e => GeometryUtils.CalculateDistance(this.Coordinates, e.Coordinates))
                .First();

            if (targetSelected != null && GeometryUtils.CalculateDistance(this.Coordinates, targetSelected.Coordinates) > this.Range)
            {
                this.Target = null;
                return;
            }
            this.Target = targetSelected;
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

            if (this.lastAngle < -1.5 && angle > 1.5)
            {
                this.towerAngle += Math.PI * 2.0;
            }
            else if (this.lastAngle > 1.5 && angle < -1.5)
            {
                this.towerAngle -= Math.PI * 2.0;
            }

            this.lastAngle = angle;
            this.towerAngle = angle * RotationBlendFactor + this.towerAngle * (1 - RotationBlendFactor);
        }

        protected abstract void SetLevelBonus();
    }
}