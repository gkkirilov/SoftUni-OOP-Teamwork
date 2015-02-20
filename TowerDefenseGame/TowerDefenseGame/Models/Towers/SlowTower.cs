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
        private const int TowerSpeed = 20;
        private const int TowerRange = 250;
        private const int TowerDamage = 5;
        public const int TowerPrice = 35;

    

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
