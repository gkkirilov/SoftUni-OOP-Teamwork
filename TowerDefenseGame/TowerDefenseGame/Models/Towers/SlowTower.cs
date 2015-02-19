﻿using System;
using System.Windows;
using System.Windows.Media.Imaging;

namespace TowerDefenseGame.Models.Towers
{
    using System.Windows.Media;
    using TowerDefenseGame.Core;

    public class SlowTower : Tower
    {
        private const int Speed = 20;
        private const int Range = 250;
        public const int Price = 35;

        private static readonly ImageBrush TowerImage =
            new ImageBrush(
                new CroppedBitmap(
                    new BitmapImage(
                        new Uri(@"..\..\Resources\towers.png", UriKind.Relative)
                        ),
                    new Int32Rect(108, 62, 55, 40)));

        public SlowTower(double x, double y)
            : base(
                x,
                y,
                Constants.FieldSegmentSize,
                Constants.FieldSegmentSize,
                Speed,
                Range,
                TowerImage,
                Price)
        {
        }
    }
}
