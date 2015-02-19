namespace TowerDefenseGame.Models.Towers
{
    using System;
    using System.Linq;
    using System.Windows.Media;
    using Geometry;
    using TowerDefenseGame.Controllers;
    using TowerDefenseGame.Core;
    using TowerDefenseGame.Models.Enemies;
    using TowerDefenseGame.Models.Projectiles;
    using TowerDefenseGame.Interfaces;

    public abstract class Tower : GameObject
    {
        private int towerSpeed;
        private int towerRange;
        private int frameCount = 0;
        private Enemy target;
        public int price;

        // Variables used for the calculation of the tower rotation
        private double towerAngle = 0;
        private double lastAngle;
        private const double RotationBlendFactor = 0.2f;

        protected Tower(double x, double y, int width, int height, int towerSpeed, int towerRange, Brush fillBrush,int price)
            : base(x, y, width, height, fillBrush)
        {
            this.TowerSpeed = towerSpeed;
            this.TowerRange = towerRange;
            this.TowerPrice = price;
        }

        public int TowerPrice
        {
            get { return this.price; }
            set
            {
                if (value <= 0)
                {
                    throw new ArgumentException("Price cannot be negative or zero");
                }
                this.price = value;
            }
        }
        public int TowerSpeed
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

        public int TowerRange
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

        public Enemy Target
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

        public override void Update()
        {
            if (this.Target == null ||
                !this.Target.Exists ||
                this.Target.IsDying ||
                GeometryUtils.CalculateDistance(this.Coordinates, this.Target.Coordinates) > this.TowerRange)
            {
                this.GetTarget();
            }

            CalculateRotationAngle();
            GeometryUtils.RotateModel(this.Model, this.towerAngle);

            if (this.Target != null && this.Target.Exists && this.frameCount >= this.TowerSpeed)
            {
                this.frameCount = 0;

                // TODO: Change the projectile according to the tower type
                if (Math.Abs(this.lastAngle - this.towerAngle) < 0.5)
                {
                    ProjectileController.Projectiles.Add(new BasicProjectile(this.Coordinates.X, this.Coordinates.Y, this.Target));   
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

            if (targetSelected != null && GeometryUtils.CalculateDistance(this.Coordinates, targetSelected.Coordinates) > this.TowerRange)
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

            if (this.lastAngle < -2.0 && angle > 2.0)
            {
                this.towerAngle += Math.PI * 2.0;
            }
            else if (this.lastAngle > 2.0 && angle < -2.0)
            {
                this.towerAngle -= Math.PI * 2.0;
            }
            this.lastAngle = angle;
            this.towerAngle = angle * RotationBlendFactor + this.towerAngle * (1 - RotationBlendFactor);
        }
    }
}