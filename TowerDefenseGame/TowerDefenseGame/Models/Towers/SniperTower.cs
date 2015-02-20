using System;
using System.Windows;
using System.Windows.Media.Imaging;
using TowerDefenseGame.Enumerations;
using TowerDefenseGame.Resources;

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
        private const int Speed = 150;
        private const int Range = 50;
        public const int Price = 40;

        private static readonly ImageBrush TowerImage = SpritesManager.SniperTower;

        private static ProjectileSelection ProjectileType = ProjectileSelection.SniperProjectile;

        public SniperTower(double x, double y)
            : base(x, y, Constants.FieldSegmentSize, Constants.FieldSegmentSize, TowerSpeed, TowerRange, TowerDamage, TowerImage, TowerPrice, ProjectileType)
        {
        }
    }
}
