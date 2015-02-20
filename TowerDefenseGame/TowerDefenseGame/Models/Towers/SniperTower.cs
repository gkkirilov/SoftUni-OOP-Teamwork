using System;
using System.Windows;
using System.Windows.Media.Imaging;

namespace TowerDefenseGame.Models.Towers
{
    using System.Windows.Media;
    using TowerDefenseGame.Core;

    public class SniperTower : Tower
    {
        private const int TowerSpeed = 150;
        private const int TowerRange = 300;
        private const int TowerDamage = 5;
        public const int TowerPrice = 40;

        private static readonly ImageBrush TowerImage =
            new ImageBrush(
                new CroppedBitmap(
                    new BitmapImage(
                        new Uri(@"..\..\Resources\towers.png", UriKind.Relative)
                        ),
                    new Int32Rect(115, 0, 46, 39)));

        public SniperTower(double x, double y)
            : base(x, y, Constants.FieldSegmentSize, Constants.FieldSegmentSize, TowerSpeed, TowerRange, TowerDamage, TowerImage, TowerPrice)
        {
        }
    }
}
