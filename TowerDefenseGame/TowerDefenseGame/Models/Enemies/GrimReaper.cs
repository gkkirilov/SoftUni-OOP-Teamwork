namespace TowerDefenseGame.Models.Enemies
{
    using System.Windows.Media.Imaging;
    using Resources;
    using Utilities;

    public class GrimReaper : Enemy
    {
        private const int EnemyLifePoints = 200;
        private const int EnemySpeed = 2;
        private const int Bounty = 35;


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
                Bounty)
        {

        }
    }
}
