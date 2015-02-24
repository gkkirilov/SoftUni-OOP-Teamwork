using TowerDefenseGame.Resources;

namespace TowerDefenseGame.Models.Projectiles
{
    using System;
    using System.Windows;
    using System.Windows.Media;
    using System.Windows.Media.Imaging;
    using Debuffs;
    using Interfaces;

    class SniperProjectile : Projectile
    {
        private const int ProjectileSpeed = 20;

        public SniperProjectile(double x, double y, IEnemy target, int damage)
            : base(x, y, ProjectileSpeed, target,SpritesManager.SniperProjectile , damage, new NullDebuff())
        {
        }
    }
}
