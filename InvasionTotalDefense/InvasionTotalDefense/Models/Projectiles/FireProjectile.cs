namespace TowerDefenseGame.Models.Projectiles
{
    using Debuffs;
    using Interfaces;
    using Resources;

    public class FireProjectile : Projectile
    {
         private const int ProjectileSpeed = 10;

        public FireProjectile(double x, double y, IEnemy target, int damage)
            : base(x, y, FireProjectile.ProjectileSpeed, target, SpritesManager.FireProjectile, damage, new IgniteDebuff(10 * damage / 100 < 1 ? 1 : 10 * damage / 100))
        {
        }
    }
}
