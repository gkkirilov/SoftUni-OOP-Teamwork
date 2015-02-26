namespace TowerDefenseGame.Models.Projectiles
{
    using Debuffs;
    using Interfaces;
    using Resources;

    public class FreezeProjectile : Projectile
    {
        private const int ProjectileSpeed = 6;

        public FreezeProjectile(double x, double y, IEnemy target, int damage)
            : base(x, y, FreezeProjectile.ProjectileSpeed, target, SpritesManager.FreezeProjectile, damage, new FreezeDebuff())
        {
        }
    }
}
