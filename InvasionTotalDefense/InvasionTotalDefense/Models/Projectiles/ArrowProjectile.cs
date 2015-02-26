namespace TowerDefenseGame.Models.Projectiles
{
    using Debuffs;
    using Interfaces;
    using Resources;

    public class ArrowProjectile : Projectile
    {
        private const int ProjectileSpeed = 10;

        public ArrowProjectile(double x, double y, IEnemy target, int damage)
            : base(x, y, ArrowProjectile.ProjectileSpeed, target, SpritesManager.ArrowProjectile, damage, new NullDebuff())
        {
        }
    }
}
