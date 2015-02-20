using System;
using System.Windows;
using System.Windows.Media.Imaging;

namespace TowerDefenseGame.Models.Enemies
{
    using System.Windows.Media;
    using Resources;
    using TowerDefenseGame.Core;

    public class Skeleton : Enemy
    {
        private const int EnemyLifePoints = 50;
        private const int EnemySpeed = 3;
        private const int bounty = 10;


        private static readonly CroppedBitmap[][] EnemySprites = SpritesManager.SkeletonSprites;

        public Skeleton(double x, double y)
            : base(
                x, y, Constants.FieldSegmentSize, Constants.FieldSegmentSize, Skeleton.EnemyLifePoints, Skeleton.EnemySpeed,
                EnemySprites, bounty)
        {

        }
    }
}
