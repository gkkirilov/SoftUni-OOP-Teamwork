namespace TowerDefenseGame.Models.Projectiles
{
    using Debuffs;
    using Interfaces;
    using Resources;

    public class SniperProjectile : Projectile
    {
        private const int ProjectileSpeed = 20;

        public SniperProjectile(double x, double y, IEnemy target, int damage)
            : base(
                x,
                y,
                ProjectileSpeed,
                target,
                SpritesManager.SniperProjectile,
                damage,
                new NullDebuff())
        {
        }
    }
}
