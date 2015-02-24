namespace TowerDefenseGame.Geometry
{
    using System;
    using System.Windows.Media;
    using System.Windows.Shapes;
    using Utilities;

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
            double distance = Math.Sqrt(Math.Pow(target.X - currentPoint.X, 2) +
                Math.Pow(target.Y - currentPoint.Y, 2));

            return distance;
        }

        public static void RotateModel(Rectangle model, double angleInRadians)
        {
            RotateTransform rotateTransform =
                new RotateTransform(
                    90.0 - (angleInRadians * 180 / Math.PI),
                    (double)Constants.FieldSegmentSize / 2,
                    (double)Constants.FieldSegmentSize / 2);

            model.RenderTransform = rotateTransform;
        }
    }
}
