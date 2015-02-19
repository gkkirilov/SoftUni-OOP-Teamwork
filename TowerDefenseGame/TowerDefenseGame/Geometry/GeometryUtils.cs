namespace TowerDefenseGame.Geometry
{
    using System;
    using System.Windows.Media;
    using Core;
    using System.Windows.Shapes;

    public static class GeometryUtils
    {
        public static void HandleMovement(Point objectPosition, Point targetPosition, double speed)
        {
            if (CalculateDistance(objectPosition, targetPosition) < speed)
            {
                objectPosition.X = targetPosition.X;
                objectPosition.Y = targetPosition.Y;
            }
            double deltaX = targetPosition.X - objectPosition.X;
            double deltaY = targetPosition.Y - objectPosition.Y;
            double angle = Math.Atan2(deltaY, deltaX);
            objectPosition.X += speed * Math.Cos(angle);
            objectPosition.Y += speed * Math.Sin(angle);
        }

        public static double CalculateDistance(Point currentPoint, Point target)
        {
            double distance = Math.Sqrt(Math.Pow(currentPoint.X - target.X, 2) +
                Math.Pow(currentPoint.Y - target.Y, 2));
            return distance;
        }

        public static void RotateModel(Rectangle model, double angleInRadians)
        {
            RotateTransform rotateTransform =
                new RotateTransform(
                    90.0 - (angleInRadians * 180 / Math.PI),
                    Constants.FieldSegmentSize / 2,
                    Constants.FieldSegmentSize / 2);

            model.RenderTransform = rotateTransform;
        }
    }
}
