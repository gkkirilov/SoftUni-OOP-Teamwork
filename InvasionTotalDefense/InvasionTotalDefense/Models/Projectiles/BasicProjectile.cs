﻿using System;
using System.Windows;
using System.Windows.Media.Imaging;

namespace TowerDefenseGame.Models.Projectiles
{
    using System.Windows.Media;
    using Interfaces;
    using TowerDefenseGame.Models.Effects.Debuffs;

    public class BasicProjectile : Projectile
    {
        private const int ProjectileSpeed = 6;

        public BasicProjectile(double x, double y, IEnemy target, int damage)
            : base(x, y, BasicProjectile.ProjectileSpeed, target, new ImageBrush(new CroppedBitmap(new BitmapImage(
             new Uri(@"..\..\Resources\ProjectilesStyleOne.png", UriKind.Relative)), new Int32Rect(1293, 1317, 33, 29))), damage, new BasicDebuff())
        {
        }
    }
}
