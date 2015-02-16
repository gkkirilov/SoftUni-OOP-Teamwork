using System;
using System.Windows;
using System.Windows.Media.Imaging;

namespace TowerDefenseGame.Models.Enemies
{
    using System.Windows.Media;
    using TowerDefenseGame.Core;

    public class BasicEnemy : Enemy
    {
        private const int LifePoints = 50;
        
        private const int Speed = 1;

        public BasicEnemy(double x, double y)
            : base(
                x, y, Constants.FieldSegmentSize, Constants.FieldSegmentSize, BasicEnemy.LifePoints, BasicEnemy.Speed,
                new ImageBrush(new CroppedBitmap(new BitmapImage(
                    new Uri(@"..\..\Common\goblinsword.png",
                        UriKind.Relative)), new Int32Rect(13, 197, 38, 53))))
        {
        }
    }
}
