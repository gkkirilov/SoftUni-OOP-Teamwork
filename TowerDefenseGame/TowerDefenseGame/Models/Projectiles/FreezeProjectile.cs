namespace TowerDefenseGame.Models.Projectiles
{
    using System;
    using System.Windows;
    using System.Windows.Media.Imaging;
    using System.Windows.Media;
    using Debuffs;
    using Interfaces;

    public class FreezeProjectile : Projectile
    {
        private const int ProjectileSpeed = 6;

        public FreezeProjectile(double x, double y, IEnemy target, int damage)
            : base(x, y, FreezeProjectile.ProjectileSpeed, target, new ImageBrush(new CroppedBitmap(new BitmapImage(
             new Uri(@"..\..\Resources\Images\ProjectilesStyleOne.png", UriKind.Relative)), new Int32Rect(973, 897, 79, 52))), damage, new FreezeDebuff())
        {
        }
    }
}
