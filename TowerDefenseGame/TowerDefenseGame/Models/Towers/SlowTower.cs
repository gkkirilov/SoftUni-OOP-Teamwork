using System;
using System.Windows;
using System.Windows.Media.Imaging;

namespace TowerDefenseGame.Models.Towers
{
    using System.Windows.Media;
    using TowerDefenseGame.Core;

    public class SlowTower : Tower
    {
        private const int TowerSpeed = 20;
        private const int TowerRange = 250;
        private const int TowerDamage = 5;
        public const int TowerPrice = 35;

        private static readonly ImageBrush TowerImage =
            new ImageBrush(
                new CroppedBitmap(
                    new BitmapImage(
                        new Uri(@"..\..\Resources\towers.png", UriKind.Relative)
                        ),
                    new Int32Rect(108, 62, 55, 40)));

        public SlowTower(double x, double y)
            : base(
                x,
                y,
                Constants.FieldSegmentSize,
                Constants.FieldSegmentSize,
                TowerSpeed,
                TowerRange,
                TowerDamage,
                TowerImage,
                TowerPrice)
        {
        }
    }
}
