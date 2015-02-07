using System;
using System.Collections.Generic;
using System.Windows.Media;
using System.Windows.Shapes;
using TowerDefenseGame.Geometry;

namespace TowerDefenseGame.Models.Enemies
{
    abstract class Enemy : GameObject
    {
        private int speed;
        private int lifePoints;
        private Rectangle model;
        private List<Point> beacons = new List<Point>();

        protected Enemy(int x, int y, int width, int height, int lifePoints, int speed)
            : base(x, y, width, height)
        {
            this.LifePoints = lifePoints;
            this.Speed = speed;
            this.Model = new Rectangle();
            this.Model.Fill = Brushes.Aquamarine;
            this.Model.Width = this.Width;
            this.Model.Height = this.Height;
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

        public Rectangle Model
        {
            get
            {
                return this.model;
            }
            private set
            {
                this.model = value;
            }
        }

        public override int Update()
        {
            if (this.Beacons.Count == 0)
            {
                return 1;
            }

            if (this.Beacons[0].X > this.Coordinates.X && this.Beacons[0].Y == this.Coordinates.Y)
            {
                this.Coordinates.X += this.Speed;
                return 0;
            }
            else if (this.Beacons[0].X < this.Coordinates.X && this.Beacons[0].Y == this.Coordinates.Y)
            {
                this.Coordinates.X -= this.Speed;
                return 0;
            }
            else if (this.Beacons[0].X == this.Coordinates.X && this.Beacons[0].Y < this.Coordinates.Y)
            {
                this.Coordinates.Y -= this.Speed;
                return 0;
            }
            else if (this.Beacons[0].X == this.Coordinates.X && this.Beacons[0].Y > this.Coordinates.Y)
            {
                this.Coordinates.Y += this.Speed;
                return 0;
            }
            else
            {
                this.Beacons.RemoveAt(0);
                return 0;
            }
            
        }

        public void SetBeacons(List<Point> beacons)
        {
            this.Beacons = beacons;
        }
    }
}
