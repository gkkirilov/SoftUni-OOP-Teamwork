using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using TowerDefenseGame.Models.Effects.Debuffs;
using TowerDefenseGame.Models.Enemies;

namespace TowerDefenseGame.Models.Projectiles
{
    using Interfaces;

    class SniperProjectile : Projectile
    {
        private const int ProjectileSpeed = 10;

        public SniperProjectile(double x, double y, IEnemy target, int damage)
            : base(x, y, SniperProjectile.ProjectileSpeed, target, new ImageBrush(new CroppedBitmap(new BitmapImage(
             new Uri(@"..\..\Resources\Images\ProjectilesStyleOne.png", UriKind.Relative)), new Int32Rect(1027, 1233, 26, 31))), damage, new BasicDebuff())
        {
        }
    }
}
