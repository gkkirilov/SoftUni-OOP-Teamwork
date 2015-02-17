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

        public ArrowTower(double x, double y)
            : base(x, y, Constants.FieldSegmentSize, Constants.FieldSegmentSize, ArrowTower.Speed, ArrowTower.Range, new ImageBrush(new CroppedBitmap(new BitmapImage(
             new Uri(@"..\..\Common\towers.png", UriKind.Relative)), new Int32Rect(115, 0, 46, 39))))
        {
        }
    }
}
