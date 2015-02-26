namespace TowerDefenseGame.Models.Enemies
{
    using System.Windows.Media.Imaging;
    using Resources;
    using Utilities;

    public class GrimReaper : Enemy
    {
        private const int EnemyLifePoints = 180;
        private const int EnemySpeed = 3;
        private const int EnemyBounty = 24;

        private static readonly CroppedBitmap[][] EnemySprites = SpritesManager.GrimReaperSprites;

        public GrimReaper(double x, double y)
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
