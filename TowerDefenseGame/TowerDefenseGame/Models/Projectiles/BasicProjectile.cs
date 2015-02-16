namespace TowerDefenseGame.Models.Projectiles
{
    using System;
    using System.Windows.Media;
    using TowerDefenseGame.Controllers;
    using TowerDefenseGame.Models.Enemies;

    public class BasicProjectile : Projectile
    {
        private const int ProjectileSpeed = 2;
        private const int ProjectileDamage = 20;

        public BasicProjectile(double x, double y, Enemy target)
            : base(x, y, BasicProjectile.ProjectileSpeed, target, Brushes.Brown, BasicProjectile.ProjectileDamage)
        {
        }
    }
}
