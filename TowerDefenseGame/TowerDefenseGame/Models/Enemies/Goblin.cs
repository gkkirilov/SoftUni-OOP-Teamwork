namespace TowerDefenseGame.Models.Enemies
{
    using System.Windows.Media.Imaging;
    using Resources;
    using Utilities;

    public class Goblin : Enemy
    {
        private const int EnemyLifePoints = 85;
        private const int EnemySpeed = 3;
        private const int EnemyBounty = 10;


        private static readonly CroppedBitmap[][] EnemySprites = SpritesManager.GoblinSprites;

        public Goblin(double x, double y)
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
