using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using TowerDefenseGame.Geometry;
using TowerDefenseGame.Interfaces;

namespace TowerDefenseGame.Models.Enemies
{
    public abstract class Enemy : GameObject, IEnemy
    {
        private int speed;
        private int lifePoints;
        private List<Point> beacons = new List<Point>();

        protected Enemy(double x, double y, int width, int height, int lifePoints, int speed, Brush fillType)
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
                    throw new ArgumentException("The speed cannot be a negative number");
                }
                this.speed = value;
            }
        }

        public int LifePoints
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

        public bool Update()
        {
            if (this.Beacons.Count == 0)
            {
                return true;
            }

            if (this.Beacons[0].X > this.Coordinates.X && this.Beacons[0].Y == this.Coordinates.Y)
            {
                this.Coordinates.X += this.Speed; // Right
            }
            else if (this.Beacons[0].X < this.Coordinates.X && this.Beacons[0].Y == this.Coordinates.Y)
            {
                this.Coordinates.X -= this.Speed; // Left
            }
            else if (this.Beacons[0].X == this.Coordinates.X && this.Beacons[0].Y < this.Coordinates.Y)
            {
                this.Coordinates.Y -= this.Speed; // Top
            }
            else if (this.Beacons[0].X == this.Coordinates.X && this.Beacons[0].Y > this.Coordinates.Y)
            {
                this.Coordinates.Y += this.Speed; // Bottom
            }
            else
            {
                this.Beacons.RemoveAt(0);
                this.Update();
            }

            return false;
        }

        public void SetBeacons(List<Point> beacons)
        {
            this.Beacons = beacons;
        }
    }
}
