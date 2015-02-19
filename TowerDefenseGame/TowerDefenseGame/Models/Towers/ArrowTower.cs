using System;
using System.Windows;
using System.Windows.Media.Imaging;

namespace TowerDefenseGame.Models.Towers
{
    using System.Windows.Media;
    using TowerDefenseGame.Core;

    public class ArrowTower : Tower
    {
        private const int Speed = 25;
        private const int Range = 150;
        public const int Price = 25;
        private static readonly ImageBrush TowerImage = 
            new ImageBrush(
                new CroppedBitmap(
                    new BitmapImage(
                        new Uri(@"..\..\Resources\towers.png", UriKind.Relative)), new Int32Rect(115, 0, 46, 39)));

        public ArrowTower(double x, double y)
            : base(
                x,
                y,
                Constants.FieldSegmentSize,
                Constants.FieldSegmentSize, 
                Speed,
                Range,
                TowerImage,
                Price)
        {
        }
    }
}
