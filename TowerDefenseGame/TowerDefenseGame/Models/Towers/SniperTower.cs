using System;
using System.Windows;
using System.Windows.Media.Imaging;
using TowerDefenseGame.Resources;

namespace TowerDefenseGame.Models.Towers
{
    using System.Windows.Media;
    using TowerDefenseGame.Core;

    public class SniperTower : Tower
    {
        private const int Speed = 150;
        private const int Range = 50;
        public const int Price = 40;
  

        public SniperTower(double x, double y)
            : base(x, y, Constants.FieldSegmentSize, Constants.FieldSegmentSize, SniperTower.Speed, SniperTower.Range, SpritesManager.SniperTower, Price)
        {
        }
    }
}
