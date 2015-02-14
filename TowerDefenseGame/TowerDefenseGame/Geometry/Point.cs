using System;
using TowerDefenseGame.Models;

namespace TowerDefenseGame.Geometry
{
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

        public double CalculateDistance(Point target)
        {
            double distance = Math.Sqrt(Math.Pow(this.X - target.X, 2) + Math.Pow(this.Y - target.Y, 2));
            return distance;
        }

        public static void HandleMovement(Point objectPosition, Point targetPosition, int speed)
        {
            if (targetPosition.X > objectPosition.X && targetPosition.Y == objectPosition.Y)
            {
                objectPosition.X += speed; // Right
            }
            else if (targetPosition.X < objectPosition.X && targetPosition.Y == objectPosition.Y)
            {
                objectPosition.X -= speed; // Left
            }
            else if (targetPosition.X == objectPosition.X && targetPosition.Y < objectPosition.Y)
            {
                objectPosition.Y -= speed; // Top
            }
            else if (targetPosition.X == objectPosition.X && targetPosition.Y > objectPosition.Y)
            {
                objectPosition.Y += speed; // Bottom
            }
            else if (targetPosition.X > objectPosition.X && targetPosition.Y > objectPosition.Y)
            {
                objectPosition.Y += speed; // Bottom right
                objectPosition.X += speed;
            }
            else if (targetPosition.X < objectPosition.X && targetPosition.Y > objectPosition.Y)
            {
                objectPosition.Y += speed; // Bottom left
                objectPosition.X -= speed;
            }
            else if (targetPosition.X > objectPosition.X && targetPosition.Y < objectPosition.Y)
            {
                objectPosition.Y -= speed; // Top right
                objectPosition.X += speed;
            }
            else if (targetPosition.X < objectPosition.X && targetPosition.Y < objectPosition.Y)
            {
                objectPosition.Y -= speed; // Top left
                objectPosition.X -= speed;
            }
        }

        public bool IsInside(GameObject gameObject)
        {
            if (this.X >= gameObject.Coordinates.X && this.X <= gameObject.Coordinates.X + gameObject.Width &&
                this.Y >= gameObject.Coordinates.Y && this.Y <= gameObject.Coordinates.Y + gameObject.Height)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
