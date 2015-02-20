using System;
using System.ComponentModel.Design.Serialization;
using System.Windows;
using System.Windows.Media.Imaging;

namespace TowerDefenseGame.Models.Towers
{
    using System.Windows.Media;
    using TowerDefenseGame.Core;

    public class FireTower : Tower
    {
        private const int Speed = 50;
        private const int Range = 200;
        public const int Price = 30;
        private static readonly ImageBrush TowerImage =
            new ImageBrush(
                new CroppedBitmap(
                    new BitmapImage(
                        new Uri(@"..\..\Resources\FireTower.png", UriKind.Relative)
                        ),
                    new Int32Rect(0, 0, 45, 27)));
        public FireTower(double x, double y)
            : base(x, y, Constants.FieldSegmentSize, Constants.FieldSegmentSize, FireTower.Speed, FireTower.Range, TowerImage, Price)
        {
        }
    }
}
