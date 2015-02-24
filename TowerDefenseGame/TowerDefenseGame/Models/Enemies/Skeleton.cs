namespace TowerDefenseGame.Models.Enemies
{
    using System.Windows.Media.Imaging;
    using Resources;
    using Utilities;

    public class Skeleton : Enemy
    {
        private const int EnemyLifePoints = 50;
        private const int EnemySpeed = 3;
        private const int Bounty = 10;


        private static readonly CroppedBitmap[][] EnemySprites = SpritesManager.SkeletonSprites;

        public Skeleton(double x, double y)
            : base(
                x,
                y,
                Constants.FieldSegmentSize,
                Constants.FieldSegmentSize,
                EnemyLifePoints,
                EnemySpeed,
                EnemySprites,
                Bounty)
        {

        }
    }
}
