using System;
using System.Windows;
using System.Windows.Media.Imaging;

namespace TowerDefenseGame.Models.Projectiles
{
    using System.Windows.Media;
    using TowerDefenseGame.Models.Effects.Debuffs;
    using TowerDefenseGame.Models.Enemies;

    public class BasicProjectile : Projectile
    {
        private const int ProjectileSpeed = 6;
        private const int ProjectileDamage = 2;

        public BasicProjectile(double x, double y, Enemy target)
            : base(x, y, BasicProjectile.ProjectileSpeed, target, new ImageBrush(new CroppedBitmap(new BitmapImage(
             new Uri(@"..\..\Resources\ProjectilesStyleOne.png", UriKind.Relative)), new Int32Rect(1293, 1317, 33, 29))), BasicProjectile.ProjectileDamage, new BasicDebuff())
        {
        }
    }
}
