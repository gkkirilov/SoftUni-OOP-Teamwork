namespace TowerDefenseGame.Models.Towers
{
    using System;
    using System.Linq;
    using System.Windows.Media;
    using TowerDefenseGame.Controllers;
    using TowerDefenseGame.Core;
    using TowerDefenseGame.Models.Enemies;
    using TowerDefenseGame.Models.Projectiles;
    using TowerDefenseGame.Interfaces;

    public abstract class Tower : GameObject, IRotateable
    {
        private int towerSpeed;
        private int towerRange;
        private int frameCount = 0;
        private Enemy target;
        private double playerAngle = 0;
        private double lastAngle;
        private const double RotationBlendFactor = 0.05;

        // private string TowerEffect; - We shall implement this when we make the Effects class
        protected Tower(double x, double y, int width, int height, int towerSpeed, int towerRange, Brush fillBrush)
            : base(x, y, width, height, fillBrush)
        {
            // For debugging reasons - mihayloff
             //new ImageBrush(new CroppedBitmap(new BitmapImage(
             //new Uri(@"D:\Programming\Repositories\SoftAvengers Game\Images\heart.png", UriKind.Relative)), new Int32Rect(0, 0, 10, 10)))
            this.TowerSpeed = towerSpeed;
            this.TowerRange = towerRange;
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
                this.Coordinates.CalculateDistance(this.Target.Coordinates) > this.TowerRange)
            {
                this.GetTarget();
            }


            if (this.Target != null && this.Target.Exists && this.frameCount >= this.TowerSpeed)
            {
                this.frameCount = 0;

                // TODO: Change the projectile according to the tower type
                ProjectileController.Projectiles.Add(new BasicProjectile(this.Coordinates.X, this.Coordinates.Y, this.Target));
            }
            else
            {
                this.frameCount++;
            }

            this.CalculateRotationAngle();
            RotateModel();
        }

        private void RotateModel()
        {
            RotateTransform rotateTransform =
                new RotateTransform(
                    90.0 - (this.playerAngle * 180 / Math.PI),
                    Constants.FieldSegmentSize / 2,
                    Constants.FieldSegmentSize / 2);

            this.Model.RenderTransform = rotateTransform;
        }

        private void GetTarget()
        {
            if (EnemyController.Enemies.Count == 0)
            {
                return;
            }

            var targetSelected = EnemyController.Enemies
                .OrderBy(e => this.Coordinates.CalculateDistance(e.Coordinates))
                .First();

            if (targetSelected != null && this.Coordinates.CalculateDistance(targetSelected.Coordinates) > this.TowerRange)
            {
                this.Target = null;
                return;
            }
            this.Target = targetSelected;
        }

        public void CalculateRotationAngle()
        {
            if (this.Target == null)
            {
                return;
            }
            double deltaX = (this.Coordinates.X + (float)Constants.FieldSegmentSize / 2) -
                (this.Target.Coordinates.X + (float)Constants.FieldSegmentSize / 2);

            double deltaY = (this.Coordinates.Y + (float)Constants.FieldSegmentSize / 2) -
                (this.Target.Coordinates.Y + (float)Constants.FieldSegmentSize / 2);

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
            this.playerAngle = angle * RotationBlendFactor + this.playerAngle * (1 - RotationBlendFactor);
        }
    }
}