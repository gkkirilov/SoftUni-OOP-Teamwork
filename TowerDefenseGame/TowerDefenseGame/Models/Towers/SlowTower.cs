using System;
using System.Windows;
using System.Windows.Media.Imaging;
using TowerDefenseGame.Resources;

namespace TowerDefenseGame.Models.Towers
{
    using System.Windows.Media;
    using TowerDefenseGame.Core;

    public class SlowTower : Tower
    {
        private const int Speed = 20;
        private const int Range = 250;
        public const int Price = 35;

    

        public SlowTower(double x, double y)
            : base(
                x,
                y,
                Constants.FieldSegmentSize,
                Constants.FieldSegmentSize,
                Speed,
                Range,
                SpritesManager.SlowTower,
                Price)
        {
        }
    }
}
