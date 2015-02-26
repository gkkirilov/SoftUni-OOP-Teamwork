namespace TowerDefenseGame.Geometry
{
    using System;
    using TowerDefenseGame.Models;

    public class Point
    {
        private double x;
        private double y;
        
        public Point(double x, double y)
        {
            this.x = x;
            this.y = y;
        }

        public double X
        {
            get
            {
                return this.x;
            }

            set
            {
                this.x = value;
            }
        }

        public double Y
        {
            get
            {
                return this.y;
            }

            set
            {
                this.y = value;
            } 
        }

        public bool IsInside(GameObject gameObject)
        {
            if (this.X >= gameObject.Coordinates.X && this.X <= gameObject.Coordinates.X + gameObject.Width &&
                this.Y >= gameObject.Coordinates.Y && this.Y <= gameObject.Coordinates.Y + gameObject.Height)
            {
                return true;
            }

            return false;
        }
    }
}
