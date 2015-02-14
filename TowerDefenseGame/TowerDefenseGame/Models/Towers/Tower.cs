using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Documents;
using System.Windows.Media;
using TowerDefenseGame.Controllers;
using TowerDefenseGame.Geometry;
using TowerDefenseGame.Interfaces;
using TowerDefenseGame.Models.Enemies;
using TowerDefenseGame.Models.Projectiles;


namespace TowerDefenseGame.Models.Towers
{
    public abstract class Tower : GameObject
    {
        private int towerSpeed;
        private int towerRange;
        private int frameCount = 0;
        private Enemy target;
        // private string TowerEffect; - We shall implement this when we make the Effects class

        protected Tower(double x, double y, int width, int height, int towerSpeed, int towerRange, Brush fillBrush)
            : base(x, y, width, height, fillBrush)
        {
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
                if (value == null)
                {
                    throw new ArgumentNullException("The target cannot be null.");
                }
                this.target = value;
            }
        }

        public override void Update()
        {
            if (this.Target == null || !this.Target.Exists || this.Coordinates.CalculateDistance(this.Target.Coordinates) > this.TowerRange)
            {
                this.GetTarget();
            }

            if (this.Target != null && this.frameCount >= this.TowerSpeed)
            {
                this.frameCount = 0;
                // TODO: Change the projectile according to the tower type
                ProjectileController.Projectiles.Add(new BasicProjectile(this.Coordinates.X, this.Coordinates.Y, this.Target));
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
                .OrderBy(e => this.Coordinates.CalculateDistance(e.Coordinates))
                .First();

            this.Target = targetSelected;
        }
    }
}