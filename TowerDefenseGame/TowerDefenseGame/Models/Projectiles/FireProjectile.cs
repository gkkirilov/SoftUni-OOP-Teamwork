namespace TowerDefenseGame.Models.Projectiles
{
    using System;
    using System.Windows;
    using System.Windows.Media;
    using System.Windows.Media.Imaging;
    using Debuffs;
    using Interfaces;

    class FireProjectile : Projectile
    {
         private const int ProjectileSpeed = 10;

        public FireProjectile(double x, double y, IEnemy target, int damage)
            : base(x, y, FireProjectile.ProjectileSpeed, target, new ImageBrush(new CroppedBitmap(new BitmapImage(
             new Uri(@"..\..\Resources\Images\ProjectilesStyleOne.png", UriKind.Relative)), new Int32Rect(1027, 1233, 26, 31))), damage, new IgniteDebuff(10 * damage / 100 < 1 ? 1 : 10 * damage / 100))
        {
        }
    }
}
