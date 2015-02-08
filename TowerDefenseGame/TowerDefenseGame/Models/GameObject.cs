using System;
using System.Windows.Media;
using System.Windows.Shapes;
using TowerDefenseGame.Geometry;
using TowerDefenseGame.Interfaces;

namespace TowerDefenseGame.Models
{
    abstract class GameObject : IGameObject
    {
        private Point coordinates;
        private int width;
        private int height;
        private Rectangle model;

        protected GameObject(int x, int y, int width, int height)
        {
            this.Coordinates = new Point(x, y);
            this.Model = new Rectangle();
            this.Width = width;
            this.Height = height;

            this.Model.Height = height;
            this.Model.Width = width;
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

        public Rectangle Model
        {
            get 
            { 
                return this.model; 
            }
            set
            {
                this.model = value;
            }
        }
    }
}
