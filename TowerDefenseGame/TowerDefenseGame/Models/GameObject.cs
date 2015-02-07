using System;
using System.Windows.Media;
using TowerDefenseGame.Geometry;

namespace TowerDefenseGame.Models
{
    abstract class GameObject
    {
        private Point coordinates;
        private int width;
        private int height;

        protected GameObject(int x, int y, int width, int height)
        {
            this.Coordinates = new Point(x, y);
            this.Width = width;
            this.Height = height;
        }

        public Point Coordinates
        {
            get
            {
                return this.coordinates;
            }
            set
            {
                this.coordinates = value;
            }
        }

        public int Width
        {
            get
            {
                return this.width;
            }
            set 
            {
                if (value < 0)
                {
                    throw new ArgumentException("The width cannot be negative");
                }
                this.width = value;
            }
        }

        public int Height
        {
            get
            {
                return this.height;
            }
            set
            {
                if (value < 0)
                {
                    throw new ArgumentException("The height cannot be negative.");
                }
                this.height = value;
            }
        }

        public abstract int Update();
    }
}
