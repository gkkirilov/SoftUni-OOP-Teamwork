using System;
using System.Windows.Media;
using TowerDefenseGame.Core;
using TowerDefenseGame.Models.Enemies;

namespace TowerDefenseGame.Models.Projectiles
{
    public abstract class Projectile : GameObject
    {
        private int speed;
        private Enemy target;

        public Projectile(double x, double y, int speed, Enemy target, Brush fillType)
            : base(x, y, Constants.ProjectileSize, Constants.ProjectileSize, fillType)
        {
            this.Target = target;
            this.Speed = speed;
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

        public void Update()
        {
            if (this.Target.Coordinates.X > this.Coordinates.X && this.Target.Coordinates.Y == this.Coordinates.Y)
            {
                this.Coordinates.X += this.Speed; // Right
            }
            else if (this.Target.Coordinates.X < this.Coordinates.X && this.Target.Coordinates.Y == this.Coordinates.Y)
            {
                this.Coordinates.X -= this.Speed; // Left
            }
            else if (this.Target.Coordinates.X == this.Coordinates.X && this.Target.Coordinates.Y < this.Coordinates.Y)
            {
                this.Coordinates.Y -= this.Speed; // Top
            }
            else if (this.Target.Coordinates.X == this.Coordinates.X && this.Target.Coordinates.Y > this.Coordinates.Y)
            {
                this.Coordinates.Y += this.Speed; // Bottom
            }
            else if (this.Target.Coordinates.X > this.Coordinates.X && this.Target.Coordinates.Y > this.Coordinates.Y) 
            {
                this.Coordinates.Y += this.Speed; // Bottom right
                this.Coordinates.X += this.Speed;
            }
            else if (this.Target.Coordinates.X < this.Coordinates.X && this.Target.Coordinates.Y > this.Coordinates.Y)
            {
                this.Coordinates.Y += this.Speed; // Bottom left
                this.Coordinates.X -= this.Speed;
            }
            else if (this.Target.Coordinates.X > this.Coordinates.X && this.Target.Coordinates.Y < this.Coordinates.Y)
            {
                this.Coordinates.Y -= this.Speed; // Top right
                this.Coordinates.X += this.Speed;
            }
            else if (this.Target.Coordinates.X < this.Coordinates.X && this.Target.Coordinates.Y < this.Coordinates.Y)
            {
                this.Coordinates.Y -= this.Speed; // Top left
                this.Coordinates.X -= this.Speed;
            }
            else
            {
                throw new ArgumentException();
            }
        }
    }
}
