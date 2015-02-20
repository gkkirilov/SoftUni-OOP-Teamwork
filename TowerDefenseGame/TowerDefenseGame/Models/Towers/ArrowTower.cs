using System;
using System.Windows;
using System.Windows.Media.Imaging;
using TowerDefenseGame.Enumerations;
using TowerDefenseGame.Resources;

namespace TowerDefenseGame.Models.Towers
{
    using System.Windows.Media;
    using TowerDefenseGame.Core;

    public class ArrowTower : Tower
    {
        private const int TowerSpeed = 25;
        private const int TowerRange = 150;
        private const int TowerDamage = 5;
        public const int TowerPrice = 25;

        private static readonly ImageBrush TowerImage = SpritesManager.ArrowTower;

        private static ProjectileSelection ProjectileType = ProjectileSelection.ArrowProjectile;
        public ArrowTower(double x, double y)
            : base(
                x,
                y,
                Constants.FieldSegmentSize,
                Constants.FieldSegmentSize,
                TowerSpeed,
                TowerRange,
                TowerDamage,
                TowerImage,
                TowerPrice,
                ProjectileType)
        {
        }
    }
}
