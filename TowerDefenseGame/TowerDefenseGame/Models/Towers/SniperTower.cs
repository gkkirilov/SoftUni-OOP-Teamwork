using System;
using System.Windows;
using System.Windows.Media.Imaging;

namespace TowerDefenseGame.Models.Towers
{
    using System.Windows.Media;
    using TowerDefenseGame.Core;

    public class SniperTower : Tower
    {
        private const int Speed = 150;
        private const int Range = 50;
        public const int Price = 40;
        private static readonly ImageBrush TowerImage =
            new ImageBrush(
                new CroppedBitmap(
                    new BitmapImage(
                        new Uri(@"..\..\Resources\SniperTower.png", UriKind.Relative)
                        ),
                    new Int32Rect(0, 0, 51, 36)));

        public SniperTower(double x, double y)
            : base(x, y, Constants.FieldSegmentSize, Constants.FieldSegmentSize, SniperTower.Speed, SniperTower.Range, TowerImage, Price)
        {
        }
    }
}
