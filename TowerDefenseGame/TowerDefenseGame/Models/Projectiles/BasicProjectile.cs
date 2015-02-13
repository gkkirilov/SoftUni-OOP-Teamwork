using System;
using System.Windows.Media;
using TowerDefenseGame.Controllers;

namespace TowerDefenseGame.Models.Projectiles
{
    public class BasicProjectile : Projectile
    {
        private const int BasicProjectileSpeed = 9;

        public BasicProjectile(double x, double y)
            : base(x, y, BasicProjectile.BasicProjectileSpeed, EnemyController.Enemies[0], Brushes.BlanchedAlmond)
        {
        }
    }
}
