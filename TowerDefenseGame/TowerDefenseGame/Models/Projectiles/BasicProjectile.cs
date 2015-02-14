using System;
using System.Windows.Media;
using TowerDefenseGame.Controllers;
using TowerDefenseGame.Models.Enemies;

namespace TowerDefenseGame.Models.Projectiles
{
    public class BasicProjectile : Projectile
    {
        private const int Speed = 2;

        public BasicProjectile(double x, double y, Enemy target)
            : base(x, y, BasicProjectile.Speed, target, Brushes.Brown)
        {
        }
    }
}
