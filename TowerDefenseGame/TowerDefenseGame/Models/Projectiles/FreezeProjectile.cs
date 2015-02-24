using TowerDefenseGame.Resources;

namespace TowerDefenseGame.Models.Projectiles
{
    using System;
    using System.Windows;
    using System.Windows.Media.Imaging;
    using System.Windows.Media;
    using Debuffs;
    using Interfaces;

    public class FreezeProjectile : Projectile
    {
        private const int ProjectileSpeed = 6;

        public FreezeProjectile(double x, double y, IEnemy target, int damage)
            : base(x, y, FreezeProjectile.ProjectileSpeed, target, SpritesManager.FreezeProjectile, damage, new FreezeDebuff())
        {
        }
    }
}
