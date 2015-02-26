namespace TowerDefenseGame.Models.Enemies
{
    using System.Windows.Media.Imaging;
    using Resources;
    using Utilities;

    public class Skeleton : Enemy
    {
        private const int EnemyLifePoints = 45;
        private const int EnemySpeed = 4;
        private const int EnemyBounty = 6;

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
                EnemyBounty)
        {
        }
    }
}
