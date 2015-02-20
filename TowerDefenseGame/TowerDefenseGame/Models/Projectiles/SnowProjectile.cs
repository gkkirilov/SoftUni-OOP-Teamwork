using System;
using System.Windows;
using System.Windows.Media.Imaging;

namespace TowerDefenseGame.Models.Projectiles
{
    using System.Windows.Media;
    using Interfaces;
    using TowerDefenseGame.Models.Effects.Debuffs;
    using TowerDefenseGame.Models.Enemies;

    public class SnowProjectile : Projectile
    {
        private const int ProjectileSpeed = 6;

        public SnowProjectile(double x, double y, IEnemy target, int damage)
            : base(x, y, SnowProjectile.ProjectileSpeed, target, new ImageBrush(new CroppedBitmap(new BitmapImage(
             new Uri(@"..\..\Resources\Images\ProjectilesStyleOne.png", UriKind.Relative)), new Int32Rect(973, 897, 79, 52))), damage, new BasicDebuff())
        {
        }
    }
}
