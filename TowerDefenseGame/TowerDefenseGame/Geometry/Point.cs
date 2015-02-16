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

        public static void HandleMovement(Point objectPosition, Point targetPosition, double speed)
        {
            //Point temp = new Point(objectPosition.X, objectPosition.Y + 5);
            //
            //double sideA = Math.Sqrt(Math.Pow(temp.X - targetPosition.X, 2) + Math.Pow(temp.Y - targetPosition.Y, 2));
            //double sideB = Math.Sqrt(Math.Pow(objectPosition.X - targetPosition.X, 2) + Math.Pow(objectPosition.Y - targetPosition.Y, 2));
            //double sideC = Math.Sqrt(Math.Pow(temp.X - objectPosition.X, 2) + Math.Pow(temp.Y - objectPosition.Y, 2));
            //// cos A = ( b^2 + c^2 - a^2 ) / ( 2 bc )
            //double angle = Math.Acos((Math.Pow(sideB, 2) + Math.Pow(sideC, 2) - Math.Pow(sideA, 2)) / (2 * sideB * sideC)) * 180 / Math.PI;
            //
            //if (angle == 90) 
            //{
            //    if (objectPosition.X > targetPosition.X)
            //    {
            //        objectPosition.X -= speed;
            //    }
            //    else
            //    {
            //        objectPosition.X += speed;
            //    }
            //}
            //else if (angle == 180) 
            //{
            //    if (objectPosition.Y > targetPosition.Y)
            //    {
            //        objectPosition.Y -= speed;
            //    }
            //    else
            //    {
            //        objectPosition.Y += speed;
            //    }
            //}
            //else if (angle < 90) 
            //{
            //    if (objectPosition.X > targetPosition.X)
            //    {
            //        objectPosition.X -= speed;
            //        objectPosition.Y += (double)angle * 90 / 10000 * speed;
            //    }
            //    else
            //    {
            //        objectPosition.X += speed;
            //        objectPosition.Y += (double)angle * 90 / 10000 * speed;
            //    }
            //}
            //else
            //{
            //    if (objectPosition.Y > targetPosition.Y)
            //    {
            //        objectPosition.Y -= speed;
            //        objectPosition.X += (double)(angle - 90) * 90 / 10000 * speed;
            //    }
            //    else
            //    {
            //        objectPosition.Y += speed;
            //        objectPosition.X += (double)(angle - 90) * 90 / 10000 * speed;
            //    }
            //}
            //
            //return;
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

        public double CalculateDistance(Point target)
        {
            double distance = Math.Sqrt(Math.Pow(this.X - target.X, 2) + Math.Pow(this.Y - target.Y, 2));
            return distance;
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
