namespace TowerDefenseGame.Models.Projectiles
{
    using System.Windows.Media;
    using TowerDefenseGame.Models.Effects.Debuffs;
    using TowerDefenseGame.Models.Enemies;

    public class BasicProjectile : Projectile
    {
        private const int ProjectileSpeed = 2;
        private const int ProjectileDamage = 2;

        public BasicProjectile(double x, double y, Enemy target)
            : base(x, y, BasicProjectile.ProjectileSpeed, target, Brushes.Brown, BasicProjectile.ProjectileDamage, new BasicDebuff())
        {
        }
    }
}
