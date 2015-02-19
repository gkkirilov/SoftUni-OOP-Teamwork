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
    class FireProjectile : Projectile
    {
         private const int ProjectileSpeed = 10;
        private const int ProjectileDamage = 10;

        public FireProjectile(double x, double y, Enemy target)
            : base(x, y, FireProjectile.ProjectileSpeed, target, new ImageBrush(new CroppedBitmap(new BitmapImage(
             new Uri(@"..\..\Resources\ProjectilesStyleOne.png", UriKind.Relative)), new Int32Rect(1027, 1233,26, 31))), FireProjectile.ProjectileDamage, new BasicDebuff())
        {
        }
    }
}
