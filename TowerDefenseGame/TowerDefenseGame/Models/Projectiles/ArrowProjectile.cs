using TowerDefenseGame.Resources;

namespace TowerDefenseGame.Models.Projectiles
{
    using System;
    using System.Windows;
    using System.Windows.Media;
    using System.Windows.Media.Imaging;
    using Debuffs;
    using Interfaces;

    class ArrowProjectile : Projectile
    {
        private const int ProjectileSpeed = 10;

        public ArrowProjectile(double x, double y, IEnemy target, int damage)
            : base(x, y, ArrowProjectile.ProjectileSpeed, target, SpritesManager.ArrowProjectile, damage, new NullDebuff())
        {
        }
    }
}
